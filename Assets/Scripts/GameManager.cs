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
    public GameObject speakerRectangle;
    public GameObject background;

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
    public ConDot breakfast017 = new ConDot(2017, "Something seems wrong...", "", false, "", "", 2018, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast018 = new ConDot(2018, "You whisper in a low tone, so no one else can hear you. You poke her and she jumps again.", "", false, "", "", 2019, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast019 = new ConDot(2019, "Psst! Theo! What's going on?", "You", false, "", "", 2020, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast020 = new ConDot(2020, "Huh? What?", "Theodora", false, "", "", 2021, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast021 = new ConDot(2021, "You seem... off, you know? What's up?", "You", false, "", "", 2022, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast022 = new ConDot(2022, "Oh. I'm... I'm fine, don't worry about me. I'm just tired.", "Theodora", true, "Let it Go", "Pressure Her", 2023, 2026, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast023 = new ConDot(2023, "Okay, okay. Just wanted to ask, Theo.", "You", false, "", "", 2024, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast024 = new ConDot(2024, "Mhmm...", "Theodora", false, "", "", 2025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast025 = new ConDot(2025, "She zones back out again.", "", false, "", "", 3001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast026 = new ConDot(2026, "No, really Theo, what's going on?", "You", false, "", "", 2027, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast027 = new ConDot(2027, "I'm-- fine, okay?! Just leave me alone...", "Theodora", false, "", "", 2028, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast028 = new ConDot(2028, "It seems like this isn't going anywhere.", "", false, "", "", 2029, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast029 = new ConDot(2029, "You side-eye her. She sticks her tongue out at you.", "", false, "", "", 2030, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast030 = new ConDot(2030, "You make a mean face at her. She does it back.", "", false, "", "", 2031, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast031 = new ConDot(2031, "Why don't you--?!", "You", false, "", "", 2032, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast032 = new ConDot(2032, "CHILDREN!", "Mother", false, "", "", 2033, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 5);
    public ConDot breakfast033 = new ConDot(2033, "Children, both of you! You will sit and eat like proper ladys of the court!", "Mother", false, "", "", 2034, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfast034 = new ConDot(2034, "Something tightens in your chest and you look down at your food. You try eating it again, but it doesn't seem as appetizing.", "", false, "", "", 3001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 1);
    public ConDot breakfastend001 = new ConDot (3001, "The rest of breakfast is uneventful.", "", false, "", "", 3002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 1);
    public ConDot breakfastend002 = new ConDot (3002, "Your Father stands and taps his fork against his glass to get the crowd's attention.", "", false, "", "", 3003, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 6);
    public ConDot breakfastend003 = new ConDot (3003, "This breakfast is offically over. Everyone is free to go. Court will be in session in an hour.", "Father", false, "", "", 3004, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend004 = new ConDot (3004, "He sits back down and people begin to leave. Others stay to finish their meal. One of your teachers walks up to you and Theodora.", "", false, "", "", 3005, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot breakfastend005 = new ConDot (3005, "Remember, after your meals, you must report to the stables for your horse-back riding lessons, okay?", "Teacher", false, "", "", 3006, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend006 = new ConDot (3006, "Okay...", "You & Theodora", false, "", "", 3007, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend007 = new ConDot (3007, "Be more merry, Princesses! Today will be very exciting. You are going to learn how to make your horses jump!", "Teacher", false, "", "", 3008, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend008 = new ConDot (3008, "Mhm...", "You & Theodora", false, "", "", 3009, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend009 = new ConDot (3009, "You both know it will not be very exciting.", "", false, "", "", 3010, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend010 = new ConDot (3010, "Your teacher gets called away by a Lady-in-Waiting to discuss something you can't care about.", "", false, "", "", 3011, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend011 = new ConDot (3011, "After sitting for a few seconds, Theodora gets up and leaves.", "", false, "", "", 3012, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend012 = new ConDot (3012, "She seems to be going to the stables, but you notice at the last second she turns in the wrong direction.", "", false, "", "", 3013, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend013 = new ConDot (3013, "You quickly get up and follow her, peeking around the corner to see where she is going.", "", false, "", "", 3014, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend014 = new ConDot (3014, "Your sister turns one more corner and steps outside. She's going to the garden.", "", false, "", "", 3015, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend015 = new ConDot (3015, "She does not go to the garden randomly.", "", false, "", "", 3016, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend016 = new ConDot (3016, "She does not skip class. That's your job.", "", false, "", "", 3017, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend017 = new ConDot (3017, "Something is definitely wrong.", "", false, "", "", 3018, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot breakfastend018 = new ConDot (3018, "You follow her into the garden.", "", false, "", "", 4001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden001 = new ConDot(4001, "The Royal Gardens contain a while variety of plants across Carisia.", "", false, "", "", 4002, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 1);
    public ConDot garden002 = new ConDot(4002, "Some beautiful, some tasty, some very toxic.", "", false, "", "", 4003, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden003 = new ConDot(4003, "Theodora is trudging around the garden grounds, dress getting progressively more muddy, seeming searching for some kind of plant.", "", false, "", "", 4004, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot garden004 = new ConDot(4004, "She hasn't noticed you yet.", "", false, "Act Accusatory", "Act Kindly", 4005, 00, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    //add choice here for apporach kindly if have time

    public ConDot garden005 = new ConDot(4005, "Theodora, what are you doing here?!", "You", false, "", "", 4006, 0, 0, FlagState.NotSet, 0, 0, 0, 2, 0);
    public ConDot garden006 = new ConDot(4006, "She turns to look at you. For a second, you see her face full of fear before it hardens into anger.", "", false, "", "", 4007, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden007 = new ConDot(4007, "I could ask the same of you! What are you doing here, Elena?", "Theodora", false, "", "", 4008, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden008 = new ConDot(4008, "You know, just following after my sister who has seemingly *forgotten* how to get to the stables even though she's been getting lessons there since she was five--", "You", false, "", "", 4009, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden009 = new ConDot(4009, "Stay in your own lane, Elena! I don't care about any of that shit!", "Theodora", false, "", "", 4010, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden010 = new ConDot(4010, "You stare at her.", "", false, "", "", 4011, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden011 = new ConDot(4011, "She stares back at you. There's something behind it, though.", "", true, "Why are you so angry? (Unconcerned)", "Why are you so scared? (Concerned)", 4012, 4023, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden012 = new ConDot(4012, "Why are you so angry? Why are you like this all of the sudden?", "You", false, "", "", 4013, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden013 = new ConDot(4013, "You wouldn't care, Elena! No one here at this airheaded castle does!", "Theodora", false, "", "", 4014, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden014 = new ConDot(4014, "All these stupid horseback riding lessons and dancing lessons and courting lessons and all this stuff on how to be a *good little princess*-- it doesn't matter!", "Theodora", false, "", "", 4015, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden015 = new ConDot(4015, "None of it matters. It's all just things our parents made up.", "Theodora", false, "", "", 4016, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden016 = new ConDot(4016, "What?", "You", false, "", "", 4017, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden017 = new ConDot(4017, "You wouldn't get it. You don't care.", "Theodora", false, "", "", 4018, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden018 = new ConDot(4018, "Wait, I--", "You", false, "", "", 4019, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden019 = new ConDot(4019, "Theodora hikes up her skirts and petticoats.", "", false, "", "", 4020, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden020 = new ConDot(4020, "Just wait and see what some *real* royalty can do.", "Theodora", false, "", "", 4021, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden021 = new ConDot(4021, "Theodora turns and heads down a secert path you've never seen before. When you try to follow her, she's gone without a trace. The path she took is already hidden again.", "", false, "", "", 4022, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 1);
    public ConDot garden022 = new ConDot(4022, "There's no use in staying here. There's nothing left to say.", "", false, "", "", 5001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden023 = new ConDot(4023, "Why are you scared? Is something wrong, Theo?", "You", false, "", "", 4024, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden024 = new ConDot(4024, "Something in Theodora's guise breaks a little.", "", false, "", "", 4025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden025 = new ConDot(4025, "Scared? What-- What are you talking about, Elena?!", "Theodora", false, "", "", 4026, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden026 = new ConDot(4026, "Theodora's trying to be angry, but you can tell she's just terrified.", "", false, "", "", 4027, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden027 = new ConDot(4027, "Theo I-- look, I'm sorry for following you, I just want to make sure you're okay. You don't seem well.", "You", false, "", "", 4028, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden028 = new ConDot(4028, "Theodora is silent. Her eyes start watering. She turns her face away from you.", "", false, "", "", 4029, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden029 = new ConDot(4029, "Her voice turns low and careful.", "", false, "", "", 4030, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden030 = new ConDot(4030, "Meet me here when the moon is empty and the night is it's darkest. I need you there.", "Theodora", false, "", "", 4031, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden031 = new ConDot(4031, "You're taken aback.", "", false, "", "", 4032, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden032 = new ConDot(4032, "But Theo is your sister.", "", false, "", "", 4033, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden033 = new ConDot(4033, "It's for her. Always for her.", "", false, "", "", 4034, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden034 = new ConDot(4034, "You sharply nod your head.", "", false, "", "", 4035, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden035 = new ConDot(4035, "Theodora does the same back.", "", false, "", "", 4036, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden036 = new ConDot(4036, "I need to gather things. You need to go back. If only one of us are gone Father and Mother won't worry as much.", "Theodora", false, "", "", 4037, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden037 = new ConDot(4037, "You simply nod your head again and turn to leave.", "", false, "", "", 4038, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden038 = new ConDot(4038, "After a split second, Theodora stops you.", "", false, "", "", 4039, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden039 = new ConDot(4039, "Wait-- wait one more moment.", "Theodora", false, "", "", 4040, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden040 = new ConDot(4040, "You look back.", "", false, "", "", 4041, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden041 = new ConDot(4041, "...", "Theodora", false, "", "", 4042, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden042 = new ConDot(4042, "Thank you, Ellie. Thank you.", "Theodora", false, "", "", 4043, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden043 = new ConDot(4043, "You smile at her.", "", false, "", "", 4044, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden044 = new ConDot(4044, "Of course, Theo. Anything for you.", "You", false, "", "", 4045, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot garden045 = new ConDot(4045, "You turn and leave the garden.", "", false, "", "", 5101, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    public ConDot hostileGardenEnd001 = new ConDot(5001, "You trudge back into the castle, already late for lessons.", "", false, "", "", 5002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot hostileGardenEnd002 = new ConDot(5002, "Your teacher reprimands you for being late and having a dirty dress.", "", false, "", "", 5003, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot hostileGardenEnd003 = new ConDot(5003, "Your teacher doesn't take notice of Theodora's abscence at all.", "", false, "", "", 5004, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 0);
    public ConDot hostileGardenEnd004 = new ConDot(5004, "You do.", "", false, "", "", 8001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    public ConDot sisterGardenEnd001 = new ConDot(5101, "You return to the castle, already late for lessons.", "", false, "", "", 5102, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot sisterGardenEnd002 = new ConDot(5102, "Your teacher reprimands you for being late and having a dirty dress.", "", false, "", "", 5103, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot sisterGardenEnd003 = new ConDot(5103, "Your teacher doesn't even mention Theodora's absence.", "", false, "", "", 5104, 0, 0, FlagState.NotSet, 0, 0, 0, 1, 0);
    public ConDot sisterGardenEnd004 = new ConDot(5104, "You stay quiet.", "", false, "", "", 5105, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot sisterGardenEnd005 = new ConDot(5105, "Anything for your sisters.", "", false, "", "", 6001, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);



    public ConDot nightGarden001 = new ConDot(6001, "Theodora reappears by midday for lunch in a freshly cleaned dress. No one comments on her disappearence. You don't either, to keep the secret.", "", false, "", "", 6002, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot nightGarden002 = new ConDot(6002, "Days pass. Everything seems normal again...", "", false, "", "", 6003, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 1);
    public ConDot nightGarden003 = new ConDot(6003, "... until tonight.", "", false, "", "", 6004, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden004 = new ConDot(6004, "You're about lie down and sleep when you notice the moonlight that usually shines through your bedchambers' window is dim.", "", false, "", "", 6005, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden005 = new ConDot(6005, "You approach the window. You remember it's a new moon tonight. The astrological oracle that your Father and Mother loves was blabbering on about it today.", "", false, "", "", 6006, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden006 = new ConDot(6006, "Then it hits you.", "", false, "", "", 6007, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden007 = new ConDot(6007, "An empty moon.", "", false, "", "", 6008, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden008 = new ConDot(6008, "The darkest night.", "", false, "", "", 6009, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden009 = new ConDot(6009, "Curses. You need to get out to the garden. Fast.", "", false, "", "", 6010, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden010 = new ConDot(6010, "You look to the door. Curses again. The Guards stationed outside of your bedchamber would never allow that.", "", false, "", "", 6011, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden011 = new ConDot(6011, "Maybe there's... another way...", "", false, "", "", 6012, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden012 = new ConDot(6012, "You ever-so-carefully lean out the window.", "", false, "", "", 6013, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden013 = new ConDot(6013, "You quickly lean back into your bedchamber. Nope nope nope. Even with insane acrobatics, you can't survive a drop from your bedchamber tower.", "", false, "", "", 6014, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden014 = new ConDot(6014, "You sigh and dramatically lay down on the floor. If only there was a distraction...", "", false, "", "", 6015, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden015 = new ConDot(6015, "Abruptly, the wood floor trembles and lurches as at least eleven cannons discharge one after the other and shake the foundations of the castle.", "", false, "", "", 6016, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden016 = new ConDot(6016, "You hear the muffled voices of your guards through your bedchamber door.", "", false, "", "", 6017, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden017 = new ConDot(6017, "A danger for the princess! We must go promptly!", "Guard 1", false, "", "", 6018, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden018 = new ConDot(6018, "But we cannot protect the princess if we are not near her!", "Guard 2", false, "", "", 6019, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden019 = new ConDot(6019, "Forsooth, however, we must think long term. If we let the danger come to us, the enemy will be fully prepared!", "Guard 1", false, "", "", 6020, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden020 = new ConDot(6020, "Verily. We must proceed at once!", "Guard 2", false, "", "", 6021, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden021 = new ConDot(6021, "Guard 1 and Guard 2 rush off, full plate armor clanking loudly as they leave.", "", false, "", "", 6022, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden022 = new ConDot(6022, "After a few moment of silence, you get up and creak open the door.", "", false, "", "", 6023, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden023 = new ConDot(6023, "All of the torches are blown out. The halls are deserted. Seemingly everyone hurried towards the noise.", "", false, "", "", 6024, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden024 = new ConDot(6024, "You easily sneak out of your bedchambers, through the halls, and into the garden.", "", false, "", "", 6025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden025 = new ConDot(6025, "The garden takes on an eerie tone as you walk through it. You can barley see a thing.", "", false, "", "", 6026, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden026 = new ConDot(6026, "You carefully squint into the darkness.", "", false, "", "", 6027, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden027 = new ConDot(6027, "Suddenly, a bit in the distance, a figure pokes their head out of the space between two trees and silently motions for you to follow.", "", false, "", "", 6028, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden028 = new ConDot(6028, "It takes you a good few seconds of staring at them to realize, oh, that's just Theodora.", "", false, "", "", 6025, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 3);
    public ConDot nightGarden029 = new ConDot(6029, "You quickly follow her.", "", false, "", "", 6030, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden030 = new ConDot(6030, "She leads you through dense brush and trees, on a path you've never been through before, until you arrive at a very small clearing.", "", false, "", "", 6031, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden031 = new ConDot(6031, "Someone is already there. You startle.", "", false, "", "", 6032, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden032 = new ConDot(6032, "Wait, Theo--!", "You", false, "", "", 6033, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden033 = new ConDot(6033, "Shh! Keep your voice down. She's with us.", "Theodora", false, "", "", 6034, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden034 = new ConDot(6034, "The women's voice sounds familiar, slow and even. She wears a mask that covers almost all her face.", "", false, "", "", 6035, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden035 = new ConDot(6035, "I thought you were gonna keep her out of this, Theodora. What is she even gonna do that won't just place her in more danger?", "???", false, "", "", 6036, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden036 = new ConDot(6036, "Look, I-- ... She might have ruined the whole plot if she didn't know about it. Ellie is the only one who actually studies for our botony class.", "Theodora", false, "", "", 6037, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden037 = new ConDot(6037, "*What* is *happening*?!", "You", false, "", "", 6038, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden038 = new ConDot(6038, "Lower your voice. We don't want them to find us.", "???", false, "", "", 6039, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden039 = new ConDot(6039, "Okay, fine, sorry, but can you please explain what you're doing Theo?!", "", false, "", "", 6040, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);
    public ConDot nightGarden040 = new ConDot(6040, "", "Theodora", false, "", "", 6041, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);









    public ConDot hostileNightGardenEnd001 = new ConDot(7001, "Something in your stomach turns. The world starts to warp around you.", "", false, "", "", 00, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    public ConDot sisterNightGardenEnd001ConDot = new ConDot (7101, "", "", false, "", "", 00, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    public ConDot hostileTea = new ConDot (8001, "", "", false, "", "", 00, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);

    public ConDot sisterTea = new ConDot (9001, "", "", false, "", "", 00, 0, 0, FlagState.NotSet, 0, 0, 0, 0, 0);






    // flowbers: lavender (LGBTQ), green carnations (homosexual), rose (gay men), violets (lesbian and bi women)
    // lily (yuri, lesbians), trillium (bisexuality), watermelon (abrosexual), orchid (intersex)
    // Coltsfoot (justice shall be done)

    //public ConDot garden001 = new ConDot(4001, "Dia", "Speaker", false, "", "", next id, 0, 0, FlagState.NotSet, 0, 0, 0, leftimage, rightimage);

    //public ConDot name = new ConDot(ID, "Dia", "Speaker", false, "", "", next id, 0, new FlagHold(), new ImageHold()

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
        cdlist.Add(breakfast018);
        cdlist.Add(breakfast019);
        cdlist.Add(breakfast020);
        cdlist.Add(breakfast021);
        cdlist.Add(breakfast022);
        cdlist.Add(breakfast023);
        cdlist.Add(breakfast024);
        cdlist.Add(breakfast025);
        cdlist.Add(breakfast026);
        cdlist.Add(breakfast027);
        cdlist.Add(breakfast028);
        cdlist.Add(breakfast029);
        cdlist.Add(breakfast030);
        cdlist.Add(breakfast031);
        cdlist.Add(breakfast032);
        cdlist.Add(breakfast033);
        cdlist.Add(breakfast034);

        cdlist.Add(breakfastend001);
        cdlist.Add(breakfastend002);
        cdlist.Add(breakfastend003);
        cdlist.Add(breakfastend004);
        cdlist.Add(breakfastend005);
        cdlist.Add(breakfastend006);
        cdlist.Add(breakfastend007);
        cdlist.Add(breakfastend008);
        cdlist.Add(breakfastend009);
        cdlist.Add(breakfastend010);
        cdlist.Add(breakfastend011);
        cdlist.Add(breakfastend012);
        cdlist.Add(breakfastend013);
        cdlist.Add(breakfastend014);
        cdlist.Add(breakfastend015);
        cdlist.Add(breakfastend016);
        cdlist.Add(breakfastend017);
        cdlist.Add(breakfastend018);

        cdlist.Add(garden001);
        cdlist.Add(garden002);
        cdlist.Add(garden003);
        cdlist.Add(garden004);
        cdlist.Add(garden005);
        cdlist.Add(garden006);
        cdlist.Add(garden007);
        cdlist.Add(garden008);
        cdlist.Add(garden009);
        cdlist.Add(garden010);
        cdlist.Add(garden011);
        cdlist.Add(garden012);
        cdlist.Add(garden013);
        cdlist.Add(garden014);
        cdlist.Add(garden015);
        cdlist.Add(garden016);
        cdlist.Add(garden017);
        cdlist.Add(garden018);
        cdlist.Add(garden019);
        cdlist.Add(garden020);
        cdlist.Add(garden021);
        cdlist.Add(garden022);

        cdlist.Add(garden023);
        cdlist.Add(garden024);
        cdlist.Add(garden025);
        cdlist.Add(garden026);
        cdlist.Add(garden027);
        cdlist.Add(garden028);
        cdlist.Add(garden029);
        cdlist.Add(garden030);
        cdlist.Add(garden031);
        cdlist.Add(garden032);
        cdlist.Add(garden033);
        cdlist.Add(garden034);
        cdlist.Add(garden035);
        cdlist.Add(garden036);
        cdlist.Add(garden037);
        cdlist.Add(garden038);
        cdlist.Add(garden039);
        cdlist.Add(garden040);
        cdlist.Add(garden041);
        cdlist.Add(garden042);
        cdlist.Add(garden043);
        cdlist.Add(garden044);
        cdlist.Add(garden045);

        cdlist.Add(hostileGardenEnd001);
        cdlist.Add(hostileGardenEnd002);
        cdlist.Add(hostileGardenEnd003);
        cdlist.Add(hostileGardenEnd004);

        cdlist.Add(sisterGardenEnd001);
        cdlist.Add(sisterGardenEnd002);
        cdlist.Add(sisterGardenEnd003);
        cdlist.Add(sisterGardenEnd004);
        cdlist.Add(sisterGardenEnd005);

        cdlist.Add(nightGarden001);
        cdlist.Add(nightGarden002);
        cdlist.Add(nightGarden003);
        cdlist.Add(nightGarden004);
        cdlist.Add(nightGarden005);
        cdlist.Add(nightGarden006);
        cdlist.Add(nightGarden007);
        cdlist.Add(nightGarden008);
        cdlist.Add(nightGarden009);
        cdlist.Add(nightGarden010);
        cdlist.Add(nightGarden011);
        cdlist.Add(nightGarden012);
        cdlist.Add(nightGarden013);
        cdlist.Add(nightGarden014);
        cdlist.Add(nightGarden015);
        cdlist.Add(nightGarden016);
        cdlist.Add(nightGarden017);
        cdlist.Add(nightGarden018);
        cdlist.Add(nightGarden019);
        cdlist.Add(nightGarden020);
        cdlist.Add(nightGarden021);
        cdlist.Add(nightGarden022);
        cdlist.Add(nightGarden023);
        cdlist.Add(nightGarden024);



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
            background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[7];
        }

        if (currentConDot.Id == 6001)
        {
            //background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[n]; bedchamber
        }

        if (currentConDot.Id == 8001)
        {
            //background.GetComponent<UnityEngine.UI.Image>().sprite = imagelist[n]; tea room
        }



        if (currentConDot.Id == 5002 || currentConDot.Id == 5102)
        {
            background.GetComponent<UnityEngine.UI.Image>().color = Color.black;
        }

        if (currentConDot.Id == 6001 || currentConDot.Id == 8001)
        {
            background.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
    }
}
