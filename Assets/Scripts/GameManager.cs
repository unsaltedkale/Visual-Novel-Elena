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

        public int FlagIdToBeSet { get => flagIdToBeSet; set => flagIdToBeSet = value; }
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
    public GameObject leftImage;
    public GameObject rightImage;
    public GameObject speakerRectangle;
    public GameObject background;
    public Color32 color137 = new Color32(137, 137, 137, 255);
    public int prevCountOfVoidEnter;
    public FFlag endingNightGardenCompleted = new FFlag(001, FlagState.NotSet);
    public FFlag endingSisterTeaSisterCompleted = new FFlag(002, FlagState.NotSet);
    public FFlag endingSisterTeaHostileCompleted = new FFlag(003, FlagState.NotSet);
    public FFlag endingHostileTeaSisterCompleted = new FFlag(004, FlagState.NotSet);
    public FFlag endingHostileTeaHostileCompleted = new FFlag(005, FlagState.NotSet);
    public ConDotBank conDotBank;
    public Holder breakfast;

    // flowbers: lavender (LGBTQ), green carnations (homosexual), rose (gay men), violets (lesbian and bi women)
    // lily (yuri, lesbians), trillium (bisexuality), watermelon (abrosexual), orchid (intersex)
    // Coltsfoot (justice shall be done)

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
        ImageBankObject = GameObject.Find("Image Bank");
        leftImage = GameObject.Find("Left Image");
        rightImage = GameObject.Find("Right Image");
        speakerRectangle = GameObject.Find("Speaker Rectangle");
        background = GameObject.Find("Background");

        background.GetComponent<UnityEngine.UI.Image>().color = color137;

        breakfast = ScriptableObject.CreateInstance<Holder>();

        StartCoroutine(afterAwake());

    }

    public IEnumerator afterAwake()
    {

        fflaglist.Add(endingNightGardenCompleted);
        fflaglist.Add(endingSisterTeaSisterCompleted);
        fflaglist.Add(endingSisterTeaHostileCompleted);
        fflaglist.Add(endingHostileTeaSisterCompleted);
        fflaglist.Add(endingHostileTeaHostileCompleted);

        
        ImageBank imageBankScript = ImageBankObject.GetComponent<ImageBank>();
        imagelist = imageBankScript.imagelist;

        conDotBank = GameObject.Find("ConDot Bank").GetComponent<ConDotBank>();



        //currentConDot = prolouge1;

        Triangle.SetActive(false);
        leftImage.SetActive(false);
        rightImage.SetActive(false);

        StartCoroutine(conDotBank.Load());


        //StartCoroutine(Dialogue());

        yield break;
    }

    public IEnumerator echoLoad(Holder daholder)
    {
        print("echo Called");

        foreach (ConDotSO cdSO in conDotBank.temporaryListOfConDotSOToTransfer)
        {
            print("called");
            daholder.list.Add(cdSO);
        }

        conDotBank.temporaryListOfConDotSOToTransfer.Clear();
        yield break;
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
        
        yield return new WaitForSeconds(0.1f);

        Triangle.SetActive(true);

        if (currentConDot.ButtonBool == false)
        {
            print("can press space or hold F now");

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

        if (currentConDot.FlagIdToReadForNextConDot != 0)
        {
            foreach (FFlag f in fflaglist)
            {
                if (f.Id == currentConDot.FlagIdToReadForNextConDot)
                {
                    targetFFlag = f;
                    break;
                }
            }
        }

        if (targetFFlag.FlagState == FlagState.True)
            {
                targetConDotId = currentConDot.ConDotIfFlagTrue;
            }

        if (targetFFlag.FlagState == FlagState.False)
            {
                targetConDotId = currentConDot.ConDotIfFlagFalse;
            }


        if (targetConDotId != 9999)
        {
            foreach (ConDot cd in cdlist)
            {
                if (cd.Id == targetConDotId)
                {
                    nextConDot = cd;
                    break;
                }
            }
        }

        else if (targetConDotId == 9999)
        {
            yield return StartCoroutine(EnterVoidCalc());
        }
        
        currentConDot = nextConDot;

        print(currentConDot);

        StartCoroutine(Dialogue());

        yield break;
    }

    public IEnumerator EnterVoidCalc()
    {
        // if id = 9999 count the number of unique ending flag that says yes and enter that place

        int i = 0;

        foreach (FFlag fflag in fflaglist)
        {
            if (fflag.Id == endingNightGardenCompleted.Id && fflag.FlagState == FlagState.True)
            {
                i++;
            }
            else if (fflag.Id == endingSisterTeaSisterCompleted.Id && fflag.FlagState == FlagState.True)
            {
                i++;
            }
            else if (fflag.Id == endingSisterTeaHostileCompleted.Id && fflag.FlagState == FlagState.True)
            {
                i++;
            }
            else if (fflag.Id == endingHostileTeaSisterCompleted.Id && fflag.FlagState == FlagState.True)
            {
                i++;
            }
            else if (fflag.Id == endingHostileTeaHostileCompleted.Id && fflag.FlagState == FlagState.True)
            {
                i++;
            }
        }

        if (i == prevCountOfVoidEnter)
        {
            targetConDotId = 88001;
        }

        else if (i == 1)
        {
            targetConDotId = 11001;

            prevCountOfVoidEnter = 1;
        }
        else if (i == 2)
        {
            targetConDotId = 12001;

            prevCountOfVoidEnter = 2;
        }
        else if (i == 3)
        {
            targetConDotId = 13001;

            prevCountOfVoidEnter = 3;
        }
        else if (i == 4)
        {
            targetConDotId = 14001;

            prevCountOfVoidEnter = 4;
        }
        else if (i == 5)
        {
            targetConDotId = 15001;

            prevCountOfVoidEnter = 5;
        }

        foreach (ConDot cd in cdlist)
            {
                if (cd.Id == targetConDotId)
                {
                    nextConDot = cd;
                    break;
                }
            }

        yield break;
    }
    IEnumerator SetFlags()
    {
        print("A");
        if (currentConDot.FlagIdToBeSet != 0)
        {
            print("aa");

            foreach (FFlag f in fflaglist)
            {
                if (f.Id == currentConDot.FlagIdToBeSet)
                {
                    int i = fflaglist.IndexOf(f);
                    print(i);
                    FFlag g = fflaglist[i];
                    g.FlagState = currentConDot.FlagIdStateToBeSet;
                    fflaglist[i] = g;
                    break;
                }
            }

            //FFlag o = fflaglist[setFlagsi];
            //o.FlagState = currentConDot.FlagIdStateToBeSet;
        }

        yield break;
    }
    IEnumerator WaitForSpace()
    {
        bool b = false;

        while (b == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.F))
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

        if (currentConDot.CharacterName == "")
        {
            speakerRectangle.SetActive(false);
        }

        else
        {
            speakerRectangle.SetActive(true);
        }

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

        if (currentConDot.IdForLeftImage != 0)
        {
            if (currentConDot.IdForLeftImage == 1)
            {
                leftImage.SetActive(false);
            }

            else
            {
                leftImage.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[currentConDot.IdForLeftImage];
                leftImage.SetActive(true);
            }

        }

        if (currentConDot.IdForRightImage != 0)
        {
            if (currentConDot.IdForRightImage == 1)
            {
                rightImage.SetActive(false);
            }

            else
            {
                rightImage.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[currentConDot.IdForRightImage];
                rightImage.SetActive(true);
            }
        }

        if (currentConDot.Id == 4001)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[9];
        }

        if (currentConDot.Id == 6025)
        {
            background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[10];
            background.GetComponent<UnityEngine.UI.Image>().color = color137;
        }

        if (currentConDot.Id == 8001)
        {
            background.GetComponent<UnityEngine.UI.Image>().color = color137;
            background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[11];
        }



        if (currentConDot.Id == 5002 || currentConDot.Id == 5102 || currentConDot.Id == 7023)
        {
            background.GetComponent<UnityEngine.UI.Image>().color = Color.black;
        }

    }
}
