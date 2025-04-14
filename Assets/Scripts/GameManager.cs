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
    public GameObject leftImage;
    public GameObject rightImage;
    

    public ConDot prolouge1 = new ConDot(1001, "Welcome to the Kingdom of Carisia.", "", false, "", "", 1002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot prolouge2 = new ConDot(1002, "You, Princess Elena I, are the youngest princess of Carisia.", "", false, "", "", 1003, 0, 0, FlagState.NotSet, 0, 0, 0, 2, 0);
    public ConDot prolouge3 = new ConDot(1003, "Your dear Father, King William IV, and your dear Mother, Queen Katherine XXII, are the rulers of Carisia.", "", false, "", "", 1004, 0, 0, FlagState.NotSet, 0, 0, 0, 6, 5);
    public ConDot prolouge4 = new ConDot(1004, "And your lovely older sister, Princess Theodora VI, is second in line to the throne.", "", false, "", "", 1005, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 3);
    public ConDot prolouge5 = new ConDot(1005, "Your oldest sister, Crown Princess Katherine XXIII, has gone on a long voyage to find a fair prince for the Kingdom of Carisia. You miss her greatly.", "", false, "", "", 1006, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 4);
    public ConDot prolouge6 = new ConDot(1006, "But now is not the time to worry yourself sick about dear Kat. Now, it is time for breakfast.", "", false, "", "", 2001, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 1);

    public ConDot breakfast001 = new ConDot(2001, "The church bells ring in the distance. Ding! Ding! Ding!", "", false, "", "", 2002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast002 = new ConDot(2002, "The royal family is gathered, alongside all the nobles and high society to dine.", "", false, "", "", 2003, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast003 = new ConDot(2003, "Your Father stands and raises his cup. You and everyone else follow.", "", false, "", "", 2004, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 6);
    public ConDot breakfast004 = new ConDot(2004, "May the Lord in His grace protect our harvest, our Crown Princess, and our scared Kingdom, Carisia!", "Father", false, "", "", 2005, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast005 = new ConDot(2005, "Amen! Here here! Thank the lord!", "Crowd", false, "", "", 2006, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast006 = new ConDot(2006, "Your Father sits down and everyone else follows suit. Breakfast begins and everyone starts to talk.", "", false, "", "", 2007, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);                                                    
    public ConDot breakfast007 = new ConDot(2007, "Why, isn't this just the best? Everyone gathered in merriment, what joy!", "Mother", true, "Act Nice", "Act Annoyed", 2008, 2009, 0, FlagState.NotSet, 0, 0, 0, 2, 5);
    public ConDot breakfast008 = new ConDot(2008, "Yes, it's very nice, Mother. The food is very rich.", "You", false, "", "", 2010, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast009 = new ConDot(2009, "You say that every morning, Mother...", "You", false, "", "", 2011, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast010 = new ConDot(2010, "Yes, it's all so nice! Wouldn't you agree, Theodora?", "Mother", false, "", "", 2012, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast011 = new ConDot(2011, "Oh, how rude! Even your sister wouldn't be so rude to her Mother! Right, Theodora?", "You", false, "", "", 2012, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast012 = new ConDot(2012, "Your sister's head whips around and she blinks a few times.", "", false, "", "", 2013, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot breakfast013 = new ConDot(2013, "Uh.. yeah, of course, Mother.", "Theodora", false, "", "", 2014, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast014 = new ConDot(2014, "Your Mother starts rambling on about something or other but you keep looking at Theodora.", "", false, "", "", 2015, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 5);
    public ConDot breakfast015 = new ConDot(2015, "She seems to be... zoned out.", "", false, "", "", 2016, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot breakfast016 = new ConDot(2016, "She is not usually zoned out.", "", false, "", "", 2017, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast017 = new ConDot(2017, "Something seems wrong...", "", true, "Act Secretively", "Act Agressively", 2018, 2027, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast018 = new ConDot(2018, "You whisper in a low tone, so no one else can hear you. You poke her and she jumps again.", "", false, "", "", 2019, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast019 = new ConDot(2019, "Psst! Theo! What's going on?", "You", false, "", "", 2020, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast020 = new ConDot(2020, "Huh? What?", "Theodora", false, "", "", 2021, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast021 = new ConDot(2021, "You seem... off, you know? What's up?", "You", false, "", "", 2022, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast022 = new ConDot(2022, "Oh. I'm... I'm fine, don't worry about me. I'm just tired.", "Theodora", true, "Let it Go", "Pressure Her", 2023, 2026, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast023 = new ConDot(2023, "Okay, okay. Just wanted to ask, Theo.", "You", false, "", "", 2024, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast024 = new ConDot(2024, "Mhmm...", "Theodora", false, "", "", 2025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast025 = new ConDot(2025, "She zones back out again.", "", false, "", "", 2025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast026 = new ConDot(2026, "No, really Theo, what's going on?", "You", false, "", "", 2027, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    //public ConDot breakfast0 = new ConDot(200x, "Dia", "Speaker", false, "", "", next id, 0, 0, FlagState.NotSet, 0, 0, 0, leftimage, rightimage);

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
        ImageBankObject = GameObject.Find("Image Bank");
        leftImage = GameObject.Find("Left Image");
        rightImage = GameObject.Find("Right Image");

        cdlist.Add(prolouge1);
        cdlist.Add(prolouge2);
        cdlist.Add(prolouge3);
        cdlist.Add(prolouge4);
        cdlist.Add(prolouge5);
        cdlist.Add(prolouge6);

        cdlist.Add(breakfast001);
        cdlist.Add(breakfast002);
        cdlist.Add(breakfast003);
        cdlist.Add(breakfast004);
        cdlist.Add(breakfast005);
        cdlist.Add(breakfast006);
        cdlist.Add(breakfast007);
        cdlist.Add(breakfast008);
        cdlist.Add(breakfast009);
        cdlist.Add(breakfast010);
        cdlist.Add(breakfast011);
        cdlist.Add(breakfast012);
        cdlist.Add(breakfast013);
        cdlist.Add(breakfast014);
        cdlist.Add(breakfast015);
        cdlist.Add(breakfast016);
        cdlist.Add(breakfast017);


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
    }
}
