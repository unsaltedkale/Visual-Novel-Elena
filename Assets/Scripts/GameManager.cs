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
    public struct ConDot
    {
    public ConDot(int id, string dia, string charactername, bool buttonbool, string leftchoice, string rightchoice)
        {
            Id = id;
            Dia = dia;
            CharacterName = charactername;
            ButtonBool = buttonbool;
            LeftChoice = leftchoice;
            RightChoice = rightchoice;
        }

        public int Id { get; }
        public string Dia { get; }
        public string CharacterName { get; }
        public bool ButtonBool { get; }
        public string LeftChoice { get; }
        public string RightChoice { get; }

        public override string ToString() => $"(Id: {Id}, Dia: {Dia}, CharacterName: {CharacterName}, ButtonBool: {ButtonBool}, LeftChoice: {LeftChoice}, RightChoice: {RightChoice})";
    }

    public ConDot test1 = new ConDot(100, "hello", "Alex", true, "Good Baby", "Evil Baby");

    public ConDot currentConDot;

    public TextMeshProUGUI diaText;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;

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

        print(test1);
        currentConDot = test1;
        Render();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Render()
    {
        diaText.text = currentConDot.Dia;
        characterNameText.text = currentConDot.CharacterName;

        if (currentConDot.ButtonBool == true)
        {
            leftButtonText.text = currentConDot.LeftChoice;
            rightButtonText.text = currentConDot.RightChoice;
        }
            
    }
}
