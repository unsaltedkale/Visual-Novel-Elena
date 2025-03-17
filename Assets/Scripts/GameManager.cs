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

    // Properties to allow access in code (if needed)
        public int Id { get => id; set => id = value; }
        public string Dia { get => dia; set => dia = value; }
        public string CharacterName { get => characterName; set => characterName = value; }
        public bool ButtonBool { get => buttonBool; set => buttonBool = value; }
        public string LeftChoice { get => leftChoice; set => leftChoice = value; }
        public string RightChoice { get => rightChoice; set => rightChoice = value; }

    // Constructor
        public ConDot(int Id, string Dia, string CharacterName, bool ButtonBool, string LeftChoice, string RightChoice)
        {
            id = Id;
            dia = Dia;
            characterName = CharacterName;
            buttonBool = ButtonBool;
            leftChoice = LeftChoice;
            rightChoice = RightChoice;
        }

        // Optional: ToString method
        public override string ToString() => $"(Id: {id}, Dia: {dia}, CharacterName: {characterName}, ButtonBool: {buttonBool}, LeftChoice: {leftChoice}, RightChoice: {rightChoice})";
    
    }

    [SerializeField] public List<ConDot> cdlist;
    public ConDot currentConDot;
    public TextMeshProUGUI diaText;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;
    public GameObject LeftButton;
    public GameObject RightButton;
    public ConDot a = new ConDot(0, "Hello", "Kale", false, "", "");

    public ConDot b = new ConDot(1, "Hai~!", "Nim", false, "", "");

    public ConDot c = new ConDot(2, "God has fallen, only the sinners remain. Will you rise against the dark, knowing there will be no heaven, or will you fall like the cowards before you?", "Nim", true, "Stand", "Fall");
    public int index;

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

        cdlist[0] = a;
        cdlist[1] = b;
        cdlist[2] = c;

        index = 0;

        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Test()
    {
        currentConDot = cdlist[index];

        Render();
        
        yield return new WaitForSeconds(0.5f);

        print("can press space now");

        if (currentConDot.ButtonBool = true)
        {
            yield return StartCoroutine(WaitForSpace());
        }

        else
        {
            yield return StartCoroutine(WaitForPress());
        }

        index++;

        StartCoroutine(Test());

        yield break;
    }

    IEnumerator WaitForSpace()
    {
        bool b = false;

        while (b == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                b = true;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator WaitForPress()
    {
        bool b = false;

        int i = 0;

        while (b == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                i = 1
                b = true;
                yield break;
            }

            if (LeftButton.)
            {
                i = 2
                b = true;
                yield break;
            }

            yield return null;
        }
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
