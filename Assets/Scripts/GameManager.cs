using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Assertions.Comparers;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    // battles have been waged here. great evils have been propogated here
    [System.Serializable]
    public struct ConDot
    {
        [SerializeField] private int id;
        [SerializeField] private string dia;
        [SerializeField] private string characterName;
        [SerializeField] private bool buttonBool;
        [SerializeField] private string leftChoice;
        [SerializeField] private string rightChoice;
        [SerializeField] private int leftConDot;
        [SerializeField] private int rightConDot;

    // Properties to allow access in code (if needed)
        public int Id { get => id; set => id = value; }
        public string Dia { get => dia; set => dia = value; }
        public string CharacterName { get => characterName; set => characterName = value; }
        public bool ButtonBool { get => buttonBool; set => buttonBool = value; }
        public string LeftChoice { get => leftChoice; set => leftChoice = value; }
        public string RightChoice { get => rightChoice; set => rightChoice = value; }
        public int LeftConDot { get => leftConDot; set => leftConDot = value; }
        public int RightConDot { get => rightConDot; set => rightConDot = value; }
        [SerializeField] private int flagIdToBeSet;
        // 0  if no flag to be set
        [SerializeField] private FlagState flagIdStateToBeSet;
        // unknown if no flag to be set
        [SerializeField] private int flagIdToReadForNextConDot;
        // 0 if no flag to read
        [SerializeField] private int conDotIfFlagTrue;
        [SerializeField] private int conDotIfFlagFalse;

        public int FlagIdToBeSet{ get => flagIdToBeSet; set => flagIdToBeSet = value; }
        public FlagState FlagIdStateToBeSet { get => flagIdStateToBeSet; set => flagIdStateToBeSet = value; }
        public int FlagIdToReadForNextConDot { get => flagIdToReadForNextConDot; set => flagIdToReadForNextConDot = value; }
        public int ConDotIfFlagTrue { get => conDotIfFlagTrue; set => conDotIfFlagTrue = value; }
        public int ConDotIfFlagFalse { get => conDotIfFlagFalse; set => conDotIfFlagFalse = value; }

         [SerializeField] private int idForLeftImage;
        // 0 if same as before
        [SerializeField] private int idForRightImage;
        // 0 if same as before
        // Properties to allow access in code (if needed)
        public int IdForLeftImage { get => idForLeftImage; set => idForLeftImage = value; }
        public int IdForRightImage { get => idForRightImage; set => idForRightImage = value; }
    
    // Constructor
        public ConDot(int Id, string Dia, string CharacterName, bool ButtonBool, string LeftChoice, string RightChoice, int LeftConDot, int RightConDot, int FlagIdToSet, FlagState FlagIdStateToBeSet, int FlagIdToReadForNextConDot, int ConDotIfFlagTrue, int ConDotIfFlagFalse, int IdForLeftImage, int IdForRightImage) : this()
        {
            id = Id;
            dia = Dia;
            characterName = CharacterName;
            buttonBool = ButtonBool;
            leftChoice = LeftChoice;
            rightChoice = RightChoice;
            leftConDot = LeftConDot;
            rightConDot = RightConDot;
            flagIdToBeSet = FlagIdToBeSet;
            flagIdStateToBeSet = FlagIdStateToBeSet;
            flagIdToReadForNextConDot = FlagIdToReadForNextConDot;
            conDotIfFlagTrue = ConDotIfFlagTrue;
            conDotIfFlagFalse = ConDotIfFlagFalse;
            idForLeftImage = IdForLeftImage;
            idForRightImage = IdForRightImage;
        }

        // Optional: ToString method
        public override string ToString() => $"(Id: {id}, Dia: {dia}, CharacterName: {characterName}, ButtonBool: {buttonBool}, LeftChoice: {leftChoice}, RightChoice: {rightChoice}, LeftConDot: {LeftConDot}, RightConDot: {RightConDot}, FlagIdToBeSet: {flagIdToBeSet}, FlagIdStateToBeSet: {flagIdStateToBeSet}, FlagIdToReadForNextConDot: {flagIdToReadForNextConDot}, ConDotIfFlagTrue: {conDotIfFlagTrue}, ConDotIfFlagFalse: {conDotIfFlagFalse}, IdForLeftImage: {idForLeftImage}, IdForRightImage: {idForRightImage})";
    
    }

    [System.Serializable]
    public enum FlagState
    {
        NotSet,
        True,
        False
    }

    [System.Serializable]
    public struct FFlag
    {
        [SerializeField] private int id;
        [SerializeField] private FlagState flagState;

        // Properties to allow access in code (if needed)
        public int Id { get => id; set => id = value; }
        public FlagState FlagState { get => flagState; set => flagState = value; }

        public FFlag(int Id, FlagState FlagState) : this()
        {
            id = Id;
            flagState = FlagState;
        }

        public override string ToString() => $"(Id: {id}, FlagState: {flagState})";
    }


    [SerializeField] public List<ConDot> cdlist;
    [SerializeField] public List<FFlag> fflaglist;
    [SerializeField] public List<Sprite> imagelist;
    public GameObject ImageBankObject;
    public ConDot currentConDot;
    public TextMeshProUGUI diaText;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject Triangle;
    // public String pname = "Riley";
    // public GameObject textInputField;
    // public TextMeshProUGUI textInputFieldText;
    public GameObject leftImage;
    public GameObject rightImage;
    /*public ConDot nnull = new ConDot (0, "You are not supposed to be here. Go home.", "", false, "", "", 0, 0, new FlagHold(), new ImageHold());
    public ConDot a = new ConDot(1, "Hello", "Kale", false, "", "", 2, 0, new FlagHold (0, FlagState.NotSet, 0, 0, 0), new ImageHold(2, 0));
    public ConDot b = new ConDot(2, "Hai~!", "Nim", false, "", "", 3, 0, new FlagHold (0, FlagState.NotSet, 0, 0, 0), new ImageHold(0, 3));
    public ConDot c = new ConDot(3, "God has fallen, only the sinners remain. Will you rise against the dark, knowing there will be no heaven, or will you fall like the cowards before you?", "Nim", true, "Stand", "Fall", 4, 5, new FlagHold (0, FlagState.NotSet, 0, 0, 0), new ImageHold());
    public ConDot d = new ConDot(4, "It is the only thing you can do. You wish to be replace God.", "Nim", false, "", "", 6, 0, new FlagHold (1, FlagState.True, 0, 0, 0), new ImageHold());
    public ConDot e = new ConDot(5, "It is the only thing you can do. You can only dig yourself deeper.", "Nim", false, "", "", 6, 0, new FlagHold (1, FlagState.False, 0, 0, 0), new ImageHold());
    public ConDot f = new ConDot(6, "Hhmpf.", "Nim", false, "", "", 0, 0, new FlagHold (0, FlagState.NotSet, 1, 7, 8), new ImageHold());
    public ConDot g = new ConDot(7, "The Sun will rise again; it just won't be shining upon *you*.", "Kale", false, "", "", 0, 0, new FlagHold(0, FlagState.NotSet, 0, 0, 0), new ImageHold());
    public ConDot h = new ConDot(8, "I'm going to dig myself out of the bottom. From Hell to Purgatory.", "Kale", false, "", "", 0, 0, new FlagHold(), new ImageHold());
    public FFlag fcHasRisen = new FFlag(1, FlagState.NotSet);*/

    public ConDot prolouge1 = new ConDot(1001, "Welcome to the Kingdom of Carisia.", "", false, "", "", 1002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot prolouge2 = new ConDot(1002, "You, Princess Riley I, are the youngest princess of Carisia.", "", false, "", "", 1003, 0, 0, FlagState.NotSet, 0, 0, 0, 2, 0);
    public ConDot prolouge3 = new ConDot(1003, "Your dear father, King William IV, and your dear mother, Queen Katherine XXII, are the rulers of Carisia.", "", false, "", "", 1004, 0, 0, FlagState.NotSet, 0, 0, 0, 6, 5);
    public ConDot prolouge4 = new ConDot(1004, "And your lovely older sister, Princess Theodoria I, is second in line to the throne.", "", false, "", "", 1005, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 3);
    public ConDot prolouge5 = new ConDot(1005, "Your oldest sister, Crown Princess Katherine XXIII, has gone on a long voyage to find a fair prince for the Kingdom or Carisia. You miss her greatly.", "", false, "", "", 1006, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 4);
    public ConDot prolouge6 = new ConDot(1006, "But now is not the time to worry yourself sick about dear Kat. Now, it is time for dinner.", "", false, "", "", 1005, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 1);

    public ConDot breakfast1 = new ConDot(2001, "Ring ring ring", "", false, "", "", 2002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    //public ConDot breakfast2 = new ConDot(2002, "Dia", "Speaker", false, "", "", next id, 0, new FlagHold(), new ImageHold());


    //public ConDot name = new ConDot(ID, "Dia", "Speaker", false, "", "", next id, 0, new FlagHold(), new ImageHold())

    // Start is called before the first frame update
    void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }

        diaText = GameObject.Find("Dia Text").GetComponent<TextMeshProUGUI>();
        characterNameText = GameObject.Find("Character Name Text").GetComponent<TextMeshProUGUI>();
        leftButtonText = GameObject.Find("Left Button Text").GetComponent<TextMeshProUGUI>();
        rightButtonText = GameObject.Find("Right Button Text").GetComponent<TextMeshProUGUI>();
        LeftButton = GameObject.Find("Left Button");
        RightButton = GameObject.Find("Right Button");
        Triangle = GameObject.Find("Triangle");
        // textInputField = GameObject.Find("Text Input Field");
        // textInputFieldText = GameObject.Find("Text Input Field Text").GetComponent<TextMeshProUGUI>();
        ImageBankObject = GameObject.Find("Image Bank");
        leftImage = GameObject.Find("Left Image");
        rightImage = GameObject.Find("Right Image");

        cdlist.Add(prolouge1);
        cdlist.Add(prolouge2);
        cdlist.Add(prolouge3);
        cdlist.Add(prolouge4);
        cdlist.Add(prolouge5);
        cdlist.Add(prolouge6);


        ImageBank imageBankScript = ImageBankObject.GetComponent<ImageBank>();
        imagelist = imageBankScript.imagelist;

        currentConDot = prolouge1;

        Triangle.SetActive(false);
        leftImage.SetActive(false);
        rightImage.SetActive(false);

        StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ifortyping;

    public IEnumerator WaitForTyping()
    {
        bool b = false;

        while (b == false)
        {
            if (ifortyping == 1)
            {
                b = true;
                yield break;
            }
            yield return null;
        }
    }

    public void FinishedTyping()
    {
        ifortyping = 1;
    }

    public IEnumerator Dialogue()
    {
        Render();
        
        yield return new WaitForSeconds(0.5f);

        Triangle.SetActive(true);

        if (currentConDot.ButtonBool == false)
        {
            print("can press space now");

            yield return StartCoroutine(WaitForSpace());
        }

        else if (currentConDot.ButtonBool == true)
        {
            iforpress = 0;

            print("can press button now");

            yield return StartCoroutine(WaitForPress());
        }

        if (iforpress == 1)
        {
            print("left button pressed");
        }

        if (iforpress == 2)
        {
            print("right button pressed");
        }

        Triangle.SetActive(false);

        StartCoroutine(DetermineNextCondot());

        yield break;
    }

    public ConDot nextConDot;
    public int targetConDotId;
    public FFlag targetFFlag;

    IEnumerator DetermineNextCondot()
    {
        yield return StartCoroutine(SetFlags());

        if (currentConDot.ButtonBool == true)
        {
            if (iforpress == 1)
            {
                targetConDotId = currentConDot.LeftConDot;
            }

            else if (iforpress == 2)
            {
                targetConDotId = currentConDot.RightConDot;
            }
        }

        else if (currentConDot.ButtonBool == false)
        {
            targetConDotId = currentConDot.LeftConDot;
        }

        targetFFlag.FlagState = FlagState.NotSet;

        if (currentConDot.FlagHold.FlagIdToReadForNextConDot != 0)
        {
            foreach (FFlag f in fflaglist)
            {
                if (f.Id == currentConDot.FlagHold.FlagIdToReadForNextConDot)
                {
                    targetFFlag = f;
                    break;
                }
            }
        }

        if (targetFFlag.FlagState == FlagState.True)
            {
                targetConDotId = currentConDot.FlagHold.ConDotIfFlagTrue;
            }

        if (targetFFlag.FlagState == FlagState.False)
            {
                targetConDotId = currentConDot.FlagHold.ConDotIfFlagFalse;
            }

        foreach (ConDot cd in cdlist)
            {
                if (cd.Id == targetConDotId)
                {
                    nextConDot = cd;
                    break;
                }
            }
        
        currentConDot = nextConDot;

        print(currentConDot);

        StartCoroutine(Dialogue());

        yield break;
    }

    IEnumerator SetFlags()
    {
        print("A");
        if (currentConDot.FlagHold.FlagIdToBeSet != 0)
        {
            print("aa");

            foreach (FFlag f in fflaglist)
            {
                if (f.Id == currentConDot.FlagHold.FlagIdToBeSet)
                {
                    int i = fflaglist.IndexOf(f);
                    print(i);
                    FFlag g = fflaglist[i];
                    g.FlagState = currentConDot.FlagHold.FlagIdStateToBeSet;
                    fflaglist[i] = g;
                    break;
                }
            }

            //FFlag o = fflaglist[setFlagsi];
            //o.FlagState = currentConDot.FlagHold.FlagIdStateToBeSet;
        }

        yield break;
    }
    IEnumerator WaitForSpace()
    {
        bool b = false;

        while (b == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                b = true;
                yield break;
            }
            yield return null;
        }
    }

    public int iforpress;
    IEnumerator WaitForPress()
    {
        bool b = false;

        while (b == false)
        {
            if (iforpress == 1)
            {
                b = true;
                yield break;
            }

            if (iforpress == 2)
            {
                b = true;
                yield break;
            }

            yield return null;
        }
    }

    public void LeftButtonPress()
    {
        iforpress = 1;
    }

    public void RightButtonPress()
    {
        iforpress = 2;
    }

    public void Render()
    {
        diaText.text = currentConDot.Dia;
        characterNameText.text = currentConDot.CharacterName;

        if (currentConDot.ButtonBool == true)
        {
            LeftButton.SetActive(true);
            RightButton.SetActive(true);
            leftButtonText.text = currentConDot.LeftChoice;
            rightButtonText.text = currentConDot.RightChoice;
        }

        else
        {
            LeftButton.SetActive(false);
            RightButton.SetActive(false);
        }
        
        if (currentConDot.ImageHold.IdForLeftImage != 0)
        {
            if (currentConDot.ImageHold.IdForLeftImage == 1)
            {
                leftImage.SetActive(false);
            }

            else
            {
                leftImage.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[currentConDot.ImageHold.IdForLeftImage];
                leftImage.SetActive(true);
            }
            
        }

        if (currentConDot.ImageHold.IdForRightImage != 0)
        {
            if (currentConDot.ImageHold.IdForRightImage == 1)
            {
                rightImage.SetActive(false);
            }

            else
            {
                rightImage.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[currentConDot.ImageHold.IdForRightImage];
                rightImage.SetActive(true);
            }
        }
    }
}
