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
        [SerializeField] private FlagHold flagHold;

    // Properties to allow access in code (if needed)
        public int Id { get => id; set => id = value; }
        public string Dia { get => dia; set => dia = value; }
        public string CharacterName { get => characterName; set => characterName = value; }
        public bool ButtonBool { get => buttonBool; set => buttonBool = value; }
        public string LeftChoice { get => leftChoice; set => leftChoice = value; }
        public string RightChoice { get => rightChoice; set => rightChoice = value; }
        public int LeftConDot { get => leftConDot; set => leftConDot = value; }
        public int RightConDot { get => rightConDot; set => rightConDot = value; }
        public FlagHold FlagHold { get => flagHold; set => flagHold = value; }
    
    // Constructor
        public ConDot(int Id, string Dia, string CharacterName, bool ButtonBool, string LeftChoice, string RightChoice, int LeftConDot, int RightConDot, FlagHold FlagHold) : this()
        {
            id = Id;
            dia = Dia;
            characterName = CharacterName;
            buttonBool = ButtonBool;
            leftChoice = LeftChoice;
            rightChoice = RightChoice;
            leftConDot = LeftConDot;
            rightConDot = RightConDot;
            flagHold = FlagHold;
        }

        // Optional: ToString method
        public override string ToString() => $"(Id: {id}, Dia: {dia}, CharacterName: {characterName}, ButtonBool: {buttonBool}, LeftChoice: {leftChoice}, RightChoice: {rightChoice}, LeftConDot: {LeftConDot}, RightConDot: {RightConDot}, FlagHold: {flagHold})";
    
    }

    [System.Serializable]
    public struct FlagHold
    {
        [SerializeField] private int flagIdToBeSet;
        // 0  if no flag to be set
        [SerializeField] private FlagState flagIdStateToBeSet;
        // unknown if no flag to be set
        [SerializeField] private int flagIdToReadForNextConDot;
        // 0 if no flag to read
        [SerializeField] private int conDotIfFlagTrue;
        [SerializeField] private int conDotIfFlagFalse;

        // Properties to allow access in code (if needed)
        public int FlagIdToBeSet{ get => flagIdToBeSet; set => flagIdToBeSet = value; }
        public FlagState FlagIdStateToBeSet { get => flagIdStateToBeSet; set => flagIdStateToBeSet = value; }
        public int FlagIdToReadForNextConDot { get => flagIdToReadForNextConDot; set => flagIdToReadForNextConDot = value; }
        public int ConDotIfFlagTrue { get => conDotIfFlagTrue; set => conDotIfFlagTrue = value; }
        public int ConDotIfFlagFalse { get => conDotIfFlagFalse; set => conDotIfFlagFalse = value; }
    
        // Constructor
        public FlagHold(int FlagIdToSet, FlagState FlagIdStateToBeSet, int FlagIdToReadForNextConDot, int ConDotIfFlagTrue, int ConDotIfFlagFalse) : this()
        {
            flagIdToBeSet = FlagIdToBeSet;
            flagIdStateToBeSet = FlagIdStateToBeSet;
            flagIdToReadForNextConDot = FlagIdToReadForNextConDot;
            conDotIfFlagTrue = ConDotIfFlagTrue;
            conDotIfFlagFalse = ConDotIfFlagFalse;
        }
    
        // Optional: ToString method
        public override string ToString() => $"(FlagIdToBeSet: {flagIdToBeSet}, FlagIdStateToBeSet: {flagIdStateToBeSet}, FlagIdToReadForNextConDot: {flagIdToReadForNextConDot}, ConDotIfFlagTrue: {conDotIfFlagTrue}, ConDotIfFlagFalse: {conDotIfFlagFalse})";
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
    public ConDot currentConDot;
    public TextMeshProUGUI diaText;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject Triangle;
    public ConDot nnull = new ConDot (0, "You are not supposed to be here. Go home.", "", false, "", "", 0, 0, new FlagHold());
    public ConDot a = new ConDot(1, "Hello", "Kale", false, "", "", 2, 0, new FlagHold (0, FlagState.NotSet, 0, 0, 0));
    public ConDot b = new ConDot(2, "Hai~!", "Nim", false, "", "", 3, 0, new FlagHold (0, FlagState.NotSet, 0, 0, 0));
    public ConDot c = new ConDot(3, "God has fallen, only the sinners remain. Will you rise against the dark, knowing there will be no heaven, or will you fall like the cowards before you?", "Nim", true, "Stand", "Fall", 4, 5, new FlagHold (0, FlagState.NotSet, 0, 0, 0));
    public ConDot d = new ConDot(4, "It is the only thing you can do. You wish to be replace God.", "", false, "", "", 6, 0, new FlagHold (1, FlagState.True, 0, 0, 0));
    public ConDot e = new ConDot(5, "It is the only thing you can do. You can only dig yourself deeper.", "", false, "", "", 6, 0, new FlagHold (1, FlagState.False, 0, 0, 0));
    public ConDot f = new ConDot(6, "Hhmpf.", "Nim", false, "", "", 0, 0, new FlagHold (0, FlagState.NotSet, 1, 7, 8));
    public ConDot g = new ConDot(7, "The Sun will rise; it won't be shining upon *you*", "Kale", false, "", "", 0, 0, new FlagHold(0, FlagState.NotSet, 0, 0, 0));
    public ConDot h = new ConDot(8, "I'm going to dig myself out of the bottom.", "Kale", false, "", "", 0, 0, new FlagHold());
    public FFlag fcHasRisen = new FFlag(1, FlagState.NotSet);
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

        cdlist.Add(a);
        cdlist.Add(b);
        cdlist.Add(c);
        cdlist.Add(d);
        cdlist.Add(e);
        cdlist.Add(f);
        cdlist.Add(g);
        cdlist.Add(h);
        cdlist.Add(nnull);

        fflaglist.Add(fcHasRisen);

        currentConDot = a;

        Triangle.SetActive(false);

        StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public FFlag setFlagsFFlag;
    IEnumerator SetFlags()
    {
        if (currentConDot.FlagHold.FlagIdToBeSet != 0)
        {
            foreach (FFlag f in fflaglist)
            {
                if (f.Id == currentConDot.FlagHold.FlagIdToBeSet)
                {
                    setFlagsFFlag = f;
                    break;
                }
            }

            setFlagsFFlag.FlagState = currentConDot.FlagHold.FlagIdStateToBeSet;
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
            
    }
}
