using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConDotBank : MonoBehaviour
{
    public GameManager gm;
    
    public List<Holder> holderList;
    public List<GameManager.ConDot> tempcdList;
    public List<ConDotSO> temporaryListOfConDotSOToTransfer;

    public GameManager.ConDot prolouge1 = new GameManager.ConDot(1001, "Welcome to the Kingdom of Carisia.", "", false, "", "", 1002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot prolouge2 = new GameManager.ConDot(1002, "You, Princess Elena I, are the youngest princess of Carisia.", "", false, "", "", 1003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 2, 0);
    public GameManager.ConDot prolouge3 = new GameManager.ConDot(1003, "Your dear Father, King William IV, and your dear Mother, Queen Katherine XXII, are the rulers of Carisia.", "", false, "", "", 1004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 6, 5);
    public GameManager.ConDot prolouge4 = new GameManager.ConDot(1004, "And your lovely older sister, Princess Theodora VI, is second in line to the throne.", "", false, "", "", 1005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 3);
    public GameManager.ConDot prolouge5 = new GameManager.ConDot(1005, "Your oldest sister, Crown Princess Katherine XXIII, has gone on a long voyage to find a fair prince for the Kingdom of Carisia. You miss her greatly.", "", false, "", "", 1006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 4);
    public GameManager.ConDot prolouge6 = new GameManager.ConDot(1006, "But now is not the time to worry yourself sick about dear Kat. Now, it is time for breakfast.", "", false, "", "", 2001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 1);

    public GameManager.ConDot breakfast001 = new GameManager.ConDot(2001, "The church bells ring in the distance. Ding! Ding! Ding!", "", false, "", "", 2002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast002 = new GameManager.ConDot(2002, "The royal family is gathered, alongside all the nobles and high society to dine.", "", false, "", "", 2003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast003 = new GameManager.ConDot(2003, "Your Father stands and raises his cup. You and everyone else follow.", "", false, "", "", 2004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 6);
    public GameManager.ConDot breakfast004 = new GameManager.ConDot(2004, "May the Lord in His grace protect our harvest, our Crown Princess, and our scared Kingdom, Carisia!", "Father", false, "", "", 2005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast005 = new GameManager.ConDot(2005, "Amen! Here here! Thank the lord!", "Crowd", false, "", "", 2006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast006 = new GameManager.ConDot(2006, "Your Father sits down and everyone else follows suit. Breakfast begins and everyone starts to talk.", "", false, "", "", 2007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast007 = new GameManager.ConDot(2007, "Why, isn't this just the best? Everyone gathered in merriment, what joy!", "Mother", true, "Act Nice", "Act Annoyed", 2008, 2009, 0, GameManager.FlagState.NotSet, 0, 0, 0, 2, 5);
    public GameManager.ConDot breakfast008 = new GameManager.ConDot(2008, "Yes, it's very nice, Mother. The food is very rich.", "You", false, "", "", 2010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast009 = new GameManager.ConDot(2009, "You say that every morning, Mother...", "You", false, "", "", 2011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast010 = new GameManager.ConDot(2010, "Yes, it's all so nice! Wouldn't you agree, Theodora?", "Mother", false, "", "", 2012, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast011 = new GameManager.ConDot(2011, "Oh, how rude! Even your sister wouldn't be so rude to her Mother! Right, Theodora?", "You", false, "", "", 2012, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast012 = new GameManager.ConDot(2012, "Your sister's head whips around and she blinks a few times.", "", false, "", "", 2013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot breakfast013 = new GameManager.ConDot(2013, "Uh.. yeah, of course, Mother.", "Theodora", false, "", "", 2014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast014 = new GameManager.ConDot(2014, "Your Mother starts rambling on about something or other but you keep looking at Theodora.", "", false, "", "", 2015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 5);
    public GameManager.ConDot breakfast015 = new GameManager.ConDot(2015, "She seems to be... zoned out.", "", false, "", "", 2016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot breakfast016 = new GameManager.ConDot(2016, "She is not usually zoned out.", "", false, "", "", 2017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast017 = new GameManager.ConDot(2017, "Something seems wrong...", "", false, "", "", 2018, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast018 = new GameManager.ConDot(2018, "You whisper in a low tone, so no one else can hear you. You poke her and she jumps again.", "", false, "", "", 2019, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast019 = new GameManager.ConDot(2019, "Psst! Theo! What's going on?", "You", false, "", "", 2020, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast020 = new GameManager.ConDot(2020, "Huh? What?", "Theodora", false, "", "", 2021, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast021 = new GameManager.ConDot(2021, "You seem... off, you know? What's up?", "You", false, "", "", 2022, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast022 = new GameManager.ConDot(2022, "Oh. I'm... I'm fine, don't worry about me. I'm just tired.", "Theodora", true, "Let it Go", "Pressure Her", 2023, 2026, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast023 = new GameManager.ConDot(2023, "Okay, okay. Just wanted to ask, Theo.", "You", false, "", "", 2024, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast024 = new GameManager.ConDot(2024, "Mhmm...", "Theodora", false, "", "", 2025, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast025 = new GameManager.ConDot(2025, "She zones back out again.", "", false, "", "", 3001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast026 = new GameManager.ConDot(2026, "No, really Theo, what's going on?", "You", false, "", "", 2027, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast027 = new GameManager.ConDot(2027, "I'm-- fine, okay?! Just leave me alone...", "Theodora", false, "", "", 2028, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast028 = new GameManager.ConDot(2028, "It seems like this isn't going anywhere.", "", false, "", "", 2029, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast029 = new GameManager.ConDot(2029, "You side-eye her. She sticks her tongue out at you.", "", false, "", "", 2030, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast030 = new GameManager.ConDot(2030, "You make a mean face at her. She does it back.", "", false, "", "", 2031, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast031 = new GameManager.ConDot(2031, "Why don't you--?!", "You", false, "", "", 2032, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast032 = new GameManager.ConDot(2032, "CHILDREN!", "Mother", false, "", "", 2033, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 5);
    public GameManager.ConDot breakfast033 = new GameManager.ConDot(2033, "Children, both of you! You will sit and eat like proper ladys of the court!", "Mother", false, "", "", 2034, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfast034 = new GameManager.ConDot(2034, "Something tightens in your chest and you look down at your food. You try eating it again, but it doesn't seem as appetizing.", "", false, "", "", 3001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 1);
    public GameManager.ConDot breakfastend001 = new GameManager.ConDot(3001, "The rest of breakfast is uneventful.", "", false, "", "", 3002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 1);
    public GameManager.ConDot breakfastend002 = new GameManager.ConDot(3002, "Your Father stands and taps his fork against his glass to get the crowd's attention.", "", false, "", "", 3003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 6);
    public GameManager.ConDot breakfastend003 = new GameManager.ConDot(3003, "This breakfast is offically over. Everyone is free to go. Court will be in session in an hour.", "Father", false, "", "", 3004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend004 = new GameManager.ConDot(3004, "He sits back down and people begin to leave. Others stay to finish their meal. One of your teachers walks up to you and Theodora.", "", false, "", "", 3005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot breakfastend005 = new GameManager.ConDot(3005, "Remember, after your meals, you must report to the stables for your horse-back riding lessons, okay?", "Teacher", false, "", "", 3006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend006 = new GameManager.ConDot(3006, "Okay...", "You & Theodora", false, "", "", 3007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend007 = new GameManager.ConDot(3007, "Be more merry, Princesses! Today will be very exciting. You are going to learn how to make your horses jump!", "Teacher", false, "", "", 3008, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend008 = new GameManager.ConDot(3008, "Mhm...", "You & Theodora", false, "", "", 3009, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend009 = new GameManager.ConDot(3009, "You both know it will not be very exciting.", "", false, "", "", 3010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend010 = new GameManager.ConDot(3010, "Your teacher gets called away by a Lady-in-Waiting to discuss something you can't care about.", "", false, "", "", 3011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend011 = new GameManager.ConDot(3011, "After sitting for a few seconds, Theodora gets up and leaves.", "", false, "", "", 3012, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend012 = new GameManager.ConDot(3012, "She seems to be going to the stables, but you notice at the last second she turns in the wrong direction.", "", false, "", "", 3013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend013 = new GameManager.ConDot(3013, "You quickly get up and follow her, peeking around the corner to see where she is going.", "", false, "", "", 3014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend014 = new GameManager.ConDot(3014, "Your sister turns one more corner and steps outside. She's going to the garden.", "", false, "", "", 3015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend015 = new GameManager.ConDot(3015, "She does not go to the garden randomly.", "", false, "", "", 3016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend016 = new GameManager.ConDot(3016, "She does not skip class. That's your job.", "", false, "", "", 3017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend017 = new GameManager.ConDot(3017, "Something is definitely wrong.", "", false, "", "", 3018, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot breakfastend018 = new GameManager.ConDot(3018, "You follow her into the garden.", "", false, "", "", 4001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden001 = new GameManager.ConDot(4001, "The Royal Gardens contain a while variety of plants across Carisia.", "", false, "", "", 4002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 1);
    public GameManager.ConDot garden002 = new GameManager.ConDot(4002, "Some beautiful, some tasty, some very toxic.", "", false, "", "", 4003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden003 = new GameManager.ConDot(4003, "Theodora is trudging around the garden grounds, dress getting progressively more muddy, seeming searching for some kind of plant.", "", false, "", "", 4004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot garden004 = new GameManager.ConDot(4004, "She hasn't noticed you yet.", "", false, "Act Accusatory", "Act Kindly", 4005, 00, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    //add choice here for apporach kindly if have time

    public GameManager.ConDot garden005 = new GameManager.ConDot(4005, "Theodora, what are you doing here?!", "You", false, "", "", 4006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 2, 0);
    public GameManager.ConDot garden006 = new GameManager.ConDot(4006, "She turns to look at you. For a second, you see her face full of fear before it hardens into anger.", "", false, "", "", 4007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden007 = new GameManager.ConDot(4007, "I could ask the same of you! What are you doing here, Elena?", "Theodora", false, "", "", 4008, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden008 = new GameManager.ConDot(4008, "You know, just following after my sister who has seemingly *forgotten* how to get to the stables even though she's been getting lessons there since she was five--", "You", false, "", "", 4009, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden009 = new GameManager.ConDot(4009, "Stay in your own lane, Elena! I don't care about any of that shit!", "Theodora", false, "", "", 4010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden010 = new GameManager.ConDot(4010, "You stare at her.", "", false, "", "", 4011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden011 = new GameManager.ConDot(4011, "She stares back at you. There's something behind it, though.", "", true, "Why are you so angry? (Unconcerned)", "Why are you so scared? (Concerned)", 4012, 4023, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden012 = new GameManager.ConDot(4012, "Why are you so angry? Why are you like this all of the sudden?", "You", false, "", "", 4013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden013 = new GameManager.ConDot(4013, "You wouldn't care, Elena! No one here at this airheaded castle does!", "Theodora", false, "", "", 4014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden014 = new GameManager.ConDot(4014, "All these stupid horseback riding lessons and dancing lessons and courting lessons and all this stuff on how to be a *good little princess*-- it doesn't matter!", "Theodora", false, "", "", 4015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden015 = new GameManager.ConDot(4015, "None of it matters. It's all just things our parents made up.", "Theodora", false, "", "", 4016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden016 = new GameManager.ConDot(4016, "What?", "You", false, "", "", 4017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden017 = new GameManager.ConDot(4017, "You wouldn't get it. You don't care.", "Theodora", false, "", "", 4018, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden018 = new GameManager.ConDot(4018, "Wait, I--", "You", false, "", "", 4019, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden019 = new GameManager.ConDot(4019, "Theodora hikes up her skirts and petticoats.", "", false, "", "", 4020, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden020 = new GameManager.ConDot(4020, "Just wait and see what some *real* royalty can do.", "Theodora", false, "", "", 4021, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden021 = new GameManager.ConDot(4021, "Theodora turns and heads down a secert path you've never seen before. When you try to follow her, she's gone without a trace. The path she took is already hidden again.", "", false, "", "", 4022, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 1);
    public GameManager.ConDot garden022 = new GameManager.ConDot(4022, "There's no use in staying here. There's nothing left to say.", "", false, "", "", 5001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden023 = new GameManager.ConDot(4023, "Why are you scared? Is something wrong, Theo?", "You", false, "", "", 4024, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden024 = new GameManager.ConDot(4024, "Something in Theodora's guise breaks a little.", "", false, "", "", 4025, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden025 = new GameManager.ConDot(4025, "Scared? What-- What are you talking about, Elena?!", "Theodora", false, "", "", 4026, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden026 = new GameManager.ConDot(4026, "Theodora's trying to be angry, but you can tell she's just terrified.", "", false, "", "", 4027, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden027 = new GameManager.ConDot(4027, "Theo I-- look, I'm sorry for following you, I just want to make sure you're okay. You don't seem well.", "You", false, "", "", 4028, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden028 = new GameManager.ConDot(4028, "Theodora is silent. Her eyes start watering. She turns her face away from you.", "", false, "", "", 4029, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden029 = new GameManager.ConDot(4029, "Her voice turns low and careful.", "", false, "", "", 4030, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden030 = new GameManager.ConDot(4030, "Meet me here when the moon is empty and the night is it's darkest. I need you there.", "Theodora", false, "", "", 4031, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden031 = new GameManager.ConDot(4031, "You're taken aback.", "", false, "", "", 4032, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden032 = new GameManager.ConDot(4032, "But Theo is your sister.", "", false, "", "", 4033, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden033 = new GameManager.ConDot(4033, "It's for her. Always for her.", "", false, "", "", 4034, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden034 = new GameManager.ConDot(4034, "You sharply nod your head.", "", false, "", "", 4035, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden035 = new GameManager.ConDot(4035, "Theodora does the same back.", "", false, "", "", 4036, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden036 = new GameManager.ConDot(4036, "I need to gather things. You need to go back. If only one of us are gone Father and Mother won't worry as much.", "Theodora", false, "", "", 4037, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden037 = new GameManager.ConDot(4037, "You simply nod your head again and turn to leave.", "", false, "", "", 4038, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden038 = new GameManager.ConDot(4038, "After a split second, Theodora stops you.", "", false, "", "", 4039, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden039 = new GameManager.ConDot(4039, "Wait-- wait one more moment.", "Theodora", false, "", "", 4040, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden040 = new GameManager.ConDot(4040, "You look back.", "", false, "", "", 4041, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden041 = new GameManager.ConDot(4041, "...", "Theodora", false, "", "", 4042, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden042 = new GameManager.ConDot(4042, "Thank you, Ellie. Thank you.", "Theodora", false, "", "", 4043, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden043 = new GameManager.ConDot(4043, "You smile at her.", "", false, "", "", 4044, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden044 = new GameManager.ConDot(4044, "Of course, Theo. Anything for you.", "You", false, "", "", 4045, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot garden045 = new GameManager.ConDot(4045, "You turn and leave the garden.", "", false, "", "", 5101, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    public GameManager.ConDot hostileGardenEnd001 = new GameManager.ConDot(5001, "You trudge back into the castle, already late for lessons.", "", false, "", "", 5002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileGardenEnd002 = new GameManager.ConDot(5002, "Your teacher reprimands you for being late and having a dirty dress.", "", false, "", "", 5003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileGardenEnd003 = new GameManager.ConDot(5003, "Your teacher doesn't take notice of Theodora's abscence at all.", "", false, "", "", 5004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 0);
    public GameManager.ConDot hostileGardenEnd004 = new GameManager.ConDot(5004, "You do.", "", false, "", "", 8001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    public GameManager.ConDot sisterGardenEnd001 = new GameManager.ConDot(5101, "You return to the castle, already late for lessons.", "", false, "", "", 5102, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot sisterGardenEnd002 = new GameManager.ConDot(5102, "Your teacher reprimands you for being late and having a dirty dress.", "", false, "", "", 5103, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot sisterGardenEnd003 = new GameManager.ConDot(5103, "Your teacher doesn't even mention Theodora's absence.", "", false, "", "", 5104, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 0);
    public GameManager.ConDot sisterGardenEnd004 = new GameManager.ConDot(5104, "You stay quiet.", "", false, "", "", 5105, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot sisterGardenEnd005 = new GameManager.ConDot(5105, "Anything for your sisters.", "", false, "", "", 6001, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);



    public GameManager.ConDot nightGarden001 = new GameManager.ConDot(6001, "Theodora reappears by midday for lunch in a freshly cleaned dress. No one comments on her disappearence. You don't either, to keep the secret.", "", false, "", "", 6002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot nightGarden002 = new GameManager.ConDot(6002, "Days pass. Everything seems normal again...", "", false, "", "", 6003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 1);
    public GameManager.ConDot nightGarden003 = new GameManager.ConDot(6003, "... until tonight.", "", false, "", "", 6004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden004 = new GameManager.ConDot(6004, "You're about lie down and sleep when you notice the moonlight that usually shines through your bedchambers' window is dim.", "", false, "", "", 6005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden005 = new GameManager.ConDot(6005, "You approach the window. You remember it's a new moon tonight. The astrological oracle that your Father and Mother loves was blabbering on about it today.", "", false, "", "", 6006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden006 = new GameManager.ConDot(6006, "Then it hits you.", "", false, "", "", 6007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden007 = new GameManager.ConDot(6007, "An empty moon.", "", false, "", "", 6008, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden008 = new GameManager.ConDot(6008, "The darkest night.", "", false, "", "", 6009, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden009 = new GameManager.ConDot(6009, "Curses. You need to get out to the garden. Fast.", "", false, "", "", 6010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden010 = new GameManager.ConDot(6010, "You look to the door. Curses again. The Guards stationed outside of your bedchamber would never allow that.", "", false, "", "", 6011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden011 = new GameManager.ConDot(6011, "Maybe there's... another way...", "", false, "", "", 6012, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden012 = new GameManager.ConDot(6012, "You ever-so-carefully lean out the window.", "", false, "", "", 6013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden013 = new GameManager.ConDot(6013, "You quickly lean back into your bedchamber. Nope nope nope. Even with insane acrobatics, you can't survive a drop from your bedchamber tower.", "", false, "", "", 6014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden014 = new GameManager.ConDot(6014, "You sigh and dramatically lay down on the floor. If only there was a distraction...", "", false, "", "", 6015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden015 = new GameManager.ConDot(6015, "Abruptly, the wood floor trembles and lurches as at least eleven cannons discharge one after the other and shake the foundations of the castle.", "", false, "", "", 6016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden016 = new GameManager.ConDot(6016, "You hear the muffled voices of your guards through your bedchamber door.", "", false, "", "", 6017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden017 = new GameManager.ConDot(6017, "A danger for the princess! We must go promptly!", "Guard 1", false, "", "", 6018, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden018 = new GameManager.ConDot(6018, "But we cannot protect the princess if we are not near her!", "Guard 2", false, "", "", 6019, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden019 = new GameManager.ConDot(6019, "Forsooth, however, we must think long term. If we let the danger come to us, the enemy will be fully prepared!", "Guard 1", false, "", "", 6020, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden020 = new GameManager.ConDot(6020, "Verily. We must proceed at once!", "Guard 2", false, "", "", 6021, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden021 = new GameManager.ConDot(6021, "Guard 1 and Guard 2 rush off, full plate armor clanking loudly as they leave.", "", false, "", "", 6022, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden022 = new GameManager.ConDot(6022, "After a few moment of silence, you get up and creak open the door.", "", false, "", "", 6023, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden023 = new GameManager.ConDot(6023, "All of the torches are blown out. The halls are deserted. Seemingly everyone hurried towards the noise.", "", false, "", "", 6024, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden024 = new GameManager.ConDot(6024, "You easily sneak out of your bedchambers, through the halls, and into the garden.", "", false, "", "", 6025, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden025 = new GameManager.ConDot(6025, "The garden takes on an eerie tone as you walk through it. You can barley see a thing.", "", false, "", "", 6026, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden026 = new GameManager.ConDot(6026, "You carefully squint into the darkness.", "", false, "", "", 6027, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden027 = new GameManager.ConDot(6027, "Suddenly, a bit in the distance, a figure pokes their head out of the space between two trees and silently motions for you to follow.", "", false, "", "", 6028, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden028 = new GameManager.ConDot(6028, "It takes you a good few seconds of staring at them to realize, oh, that's just Theodora.", "", false, "", "", 6029, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 3);
    public GameManager.ConDot nightGarden029 = new GameManager.ConDot(6029, "You quickly follow her.", "", false, "", "", 6030, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden030 = new GameManager.ConDot(6030, "She leads you through dense brush and trees, on a path you've never been through before, until you arrive at a very small clearing.", "", false, "", "", 6031, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden031 = new GameManager.ConDot(6031, "Someone is already there. You startle.", "", false, "", "", 6032, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden032 = new GameManager.ConDot(6032, "Wait, Theo--!", "You", false, "", "", 6033, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden033 = new GameManager.ConDot(6033, "Shh! Keep your voice down. She's with us.", "Theodora", false, "", "", 6034, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden034 = new GameManager.ConDot(6034, "The women's voice sounds familiar, slow and even. She wears a mask that covers almost all her face.", "", false, "", "", 6035, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden035 = new GameManager.ConDot(6035, "I thought you were gonna keep her out of this, Theodora. What is she even gonna do that won't just place her in more danger?", "???", false, "", "", 6036, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden036 = new GameManager.ConDot(6036, "Look, I-- ... She might have ruined the whole plot if she didn't know about it. Ellie is the only one who actually studies for our botony class.", "Theodora", false, "", "", 6037, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden037 = new GameManager.ConDot(6037, "*What* is *happening*?!", "You", false, "", "", 6038, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden038 = new GameManager.ConDot(6038, "Lower your voice. We don't want them to find us.", "???", false, "", "", 6039, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden039 = new GameManager.ConDot(6039, "Okay, fine, sorry, but can you please explain what you're doing Theo?!", "", false, "", "", 6040, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden040 = new GameManager.ConDot(6040, "Just give me a minute, okay?", "Theodora", false, "", "", 6041, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden041 = new GameManager.ConDot(6041, "Theodora looks at the mystery woman.", "", false, "", "", 6042, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden042 = new GameManager.ConDot(6042, "Do you have the fresh Angel's Breath?", "Theodora", false, "", "", 6043, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden043 = new GameManager.ConDot(6043, "The mystery woman holds out freshly picked flowers with their stems wrapped in a damp cloth. They are white with hints of a deep black around the edges and center.", "", false, "", "", 6044, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden044 = new GameManager.ConDot(6044, "They don't look like any native plant around here. The flowers must have been express delivered on horseback from very far away.", "", false, "", "", 6045, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden045 = new GameManager.ConDot(6045, "Great. They still look fresh enough. I checked eariler and the jasmine flowers just bloomed. We have everything.", "Theodora", false, "", "", 6046, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden046 = new GameManager.ConDot(6046, "The mystery woman looks at you.", "", false, "", "", 6047, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden047 = new GameManager.ConDot(6047, "They're for the tea. Angel's Breath smells and tastes horrible when brewed. The jasmine is to cover it up.", "", false, "", "", 6048, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden048 = new GameManager.ConDot(6048, "Why are you brewing Angel's Breath? That stuff it only used for bouquets in flower languages at this point.", "You", false, "", "", 6049, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden049 = new GameManager.ConDot(6049, "We're using it because Angel's Breath contains a deadly toxin!", "Theodora", true, "WHY ARE YOU BREWING POISON???", "MAYBE *THATS* WHY IT SMELLS SO BAD???", 6056, 6051, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden050 = new GameManager.ConDot(6050, "Actually, Angel's Breath smells bad when brewed because it attracts fruit flies for pollination.", "???", false, "", "", 6051, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden051 = new GameManager.ConDot(6051, "It makes the smell of fruit when it's young which quickly develops into the smell of rotten fruit as the blossom develops.", "???", false, "", "", 6052, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden052 = new GameManager.ConDot(6052, "Most Angel's Breath found in markets is actually harvested prematurely, before it smells rotten and the flowers have become mostly black.", "???", false, "", "", 6053, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden053 = new GameManager.ConDot(6053, "However, no matter the stage, when brewed, Angel's Breath quickly develops and gains it's not-so-famous rotten smell.", "???", false, "", "", 6054, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden054 = new GameManager.ConDot(6054, "Oh, huh, that's actually pretty interesting.", "You", false, "", "", 6055, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden055 = new GameManager.ConDot(6055, "Wait.", "You", false, "", "", 6056, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden056 = new GameManager.ConDot(6056, "WHY ARE YOU BREWING POISON??????", "You", false, "", "", 6057, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden057 = new GameManager.ConDot(6057, "Elena, do you... know what's going on?", "???", false, "", "", 6058, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden058 = new GameManager.ConDot(6058, "Well, clearly *not*, because all of this seems--", "You", false, "", "", 6059, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden059 = new GameManager.ConDot(6059, "No, Elena, in the outside world. Do you know what's going on in the outside world.", "???", false, "", "", 6060, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden060 = new GameManager.ConDot(6060, "...What? What do you mean?", "You", false, "", "", 6061, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden061 = new GameManager.ConDot(6061, "Okay. King William and Queen Katherine are really bad at foreign diplomacy, so all the other monarches are angry and all the citizens who came from those nations are angry.", "???", false, "", "", 6062, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden062 = new GameManager.ConDot(6062, "What?! No, Father and Mother could ever do that! They're so nice... and... kind...", "Elena", false, "", "", 6063, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden063 = new GameManager.ConDot(6063, "Both Theodora and the mystery woman are raising their eyebrows at you.", "", false, "", "", 6064, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden064 = new GameManager.ConDot(6064, "No. No no no no no. It has to be some mistake or--", "You", false, "", "", 6065, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden065 = new GameManager.ConDot(6065, "Your father claimed he was King of Kings to the Kindgom to the West last week and your Mother called the Kingdom to the North's heir a bastard child yesterday.", "???", false, "", "", 6066, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden066 = new GameManager.ConDot(6066, "The mystery woman keeps listing more things but your ears start ringing. Your legs almost buckle but you steady yourself against a tree.", "", false, "", "", 6067, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden067 = new GameManager.ConDot(6067, "Woah, okay, Ellie, it's okay, it's okay.", "Theodora", true, "They couldn't have done that-- I dont believe it!", "What are we doing about this?", 6068, 6080, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden068 = new GameManager.ConDot(6068, "You want more evidence? You just got it about ten minutes ago.", "???", false, "", "", 6069, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden069 = new GameManager.ConDot(6069, "What?", "You", false, "", "", 6070, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden070 = new GameManager.ConDot(6070, "The explosion. You heard it. Everyone heard it.", "???", false, "", "", 6071, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden071 = new GameManager.ConDot(6071, "Was-- did Father and Mother do that?", "You", false, "", "", 6072, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden072 = new GameManager.ConDot(6072, "No. That was the citizens. They're fed up.", "???", false, "", "", 6073, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden073 = new GameManager.ConDot(6073, "How did the citizens get cannons??", "You", false, "", "", 6074, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden074 = new GameManager.ConDot(6074, "If anyone is hungry enough and done with the rule of the monarch, they can get anything.", "???", false, "", "", 6075, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden075 = new GameManager.ConDot(6075, "I honest thought that was a purposeful distraction.", "You", false, "", "", 6076, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden076 = new GameManager.ConDot(6076, "No, just very good timing. I didn't know they were going to try to raid the castle today.", "Theodora", false, "", "", 6077, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden077 = new GameManager.ConDot(6077, "What--?! Raid?? The castle??? What?!", "You", false, "", "", 6078, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden078 = new GameManager.ConDot(6078, "Listen, there's a lot of stuff you're sheltered from. You're gonna have to catch up.", "???", false, "", "", 6079, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden079 = new GameManager.ConDot(6079, "Okay. Okay okay okay... okay.", "You", false, "", "", 6080, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden080 = new GameManager.ConDot(6080, "What are we doing about this?", "You", false, "", "", 6081, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden081 = new GameManager.ConDot(6081, "We're going to poison Mother and Father and take their place on the throne.", "Theodora", false, "", "", 6082, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden082 = new GameManager.ConDot(6082, "You almost faint. You can't take this much whiplash.", "You", false, "", "", 6083, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden083 = new GameManager.ConDot(6083, "It's clear that King William and Queen Katherine aren't going to change.", "???", false, "", "", 6084, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden084 = new GameManager.ConDot(6084, "They would rather take the kingdom down with them than make even *one* good decision.", "???", false, "", "", 6085, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden085 = new GameManager.ConDot(6085, "So, as princess and heir, we will poison them and take their place, and try to get out of the ditch they've put the Kindgom of Carisia in.", "Theodora", false, "", "", 6086, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden086 = new GameManager.ConDot(6086, "Okay... Wait! Theodora, what about our sister? Kat still hasn't returned from her voyage. We would kill us if we ever did something to Father and Mother!", "You", false, "", "", 6087, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden087 = new GameManager.ConDot(6087, "Let's just say... she would be okay with it.", "Theodora", false, "", "", 6088, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden088 = new GameManager.ConDot(6088, "What?! How can you know that?", "You", false, "", "", 6089, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden089 = new GameManager.ConDot(6089, "Just-- trust me! She'll be just fine, we just need to do this.", "Theodora", false, "", "", 6090, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden090 = new GameManager.ConDot(6090, "How can I trust you at all, Theodora? You're trying to *murder* Father and Mother, and now you're trying to tell me you have some secert corrospondence with Kat!", "You", false, "", "", 6091, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden091 = new GameManager.ConDot(6091, "Just *please*, Elena, trust me! *Please*!", "Theodora", false, "", "", 6092, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot nightGarden092 = new GameManager.ConDot(6092, "Your heart sinks. She's your sister but... how can you trust her?", "", true, "I trust you. I will join you.", "I don't trust you. I can't support your actions.", 7101, 7001, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);


    public GameManager.ConDot hostileNightGardenEnd001 = new GameManager.ConDot(7001, "Your stomach churns. The world starts to warp around you.", "", false, "", "", 7002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd002 = new GameManager.ConDot(7002, "I don't trust you. I can't support your actions.", "You", false, "", "", 7003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd003 = new GameManager.ConDot(7003, "The night is quiet for a moment. You can't see either of their faces anymore. The trees seem to bend.", "", false, "", "", 7004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd004 = new GameManager.ConDot(7004, "Theodora's voice is grave.", "", false, "", "", 7005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd005 = new GameManager.ConDot(7005, "Then... we can't have you here anymore.", "Theodora", false, "", "", 7006, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd006 = new GameManager.ConDot(7006, "...What?", "You", false, "", "", 7007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd007 = new GameManager.ConDot(7007, "You know too much. You're just a liability now.", "???", false, "", "", 7008, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd008 = new GameManager.ConDot(7008, "Wait, wait, no no no no no, I don't wanna die!", "You", false, "", "", 7009, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd009 = new GameManager.ConDot(7009, "They can't seem to hear you.", "", false, "", "", 7010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd010 = new GameManager.ConDot(7010, "Either you can travel East, go far enough where you won't interfere, or--", "???", false, "", "", 7011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd011 = new GameManager.ConDot(7011, "Suddenly, there's the loud clanging of plate armor approaching.", "", false, "", "", 7012, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd012 = new GameManager.ConDot(7012, "Curses. They've found us. We need to--", "???", false, "", "", 7013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd013 = new GameManager.ConDot(7013, "Half a dozen guards emerge out of the undergrowth, one of them holding a crossbow pointed at the mystery woman.", "", false, "", "", 7014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd014 = new GameManager.ConDot(7014, "Hands in the air, Assassin, drop your weapons, or we will shoot!", "Crossbow Guard", false, "", "", 7015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd015 = new GameManager.ConDot(7015, "It will be a cold day in hell when I follow one of you pigs.", "???", false, "", "", 7016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd016 = new GameManager.ConDot(7016, "On a trigger finger, the guard holding the crossbow fires.", "", false, "", "", 7017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd017 = new GameManager.ConDot(7017, "But, in such close quarters, the bolt wildly misfires.", "", false, "", "", 7018, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd018 = new GameManager.ConDot(7018, "Theodora and the mystery woman seem to dive towards you, but it's too late.", "", false, "", "", 7019, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd019 = new GameManager.ConDot(7019, "The bolt goes straight", "", false, "", "", 7020, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd020 = new GameManager.ConDot(7020, "through", "", false, "", "", 7021, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd021 = new GameManager.ConDot(7021, "your", "", false, "", "", 7022, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd022 = new GameManager.ConDot(7022, "heart.", "", false, "", "", 7023, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd023 = new GameManager.ConDot(7023, "", "", false, "", "", 7024, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 1, 1);
    public GameManager.ConDot hostileNightGardenEnd024 = new GameManager.ConDot(7024, "[ ENDING 1 / 5 : HEARTBREAK ]", "", false, "", "", 7025, 0, 001, GameManager.FlagState.True, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd025 = new GameManager.ConDot(7025, "...", "", false, "", "", 7026, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd026 = new GameManager.ConDot(7026, "But you never feel the bolt hit. You never hear your sister or the woman cry out. You never hit the ground dead.", "", false, "", "", 7027, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot hostileNightGardenEnd027 = new GameManager.ConDot(7027, "You open your eyes.", "", false, "", "", 9999, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot sisterNightGardenEnd001 = new GameManager.ConDot(7101, "", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);





    public GameManager.ConDot hostileTea = new GameManager.ConDot(8001, "", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    public GameManager.ConDot hostileTeaJoinedEnd001 = new GameManager.ConDot(8101, "Your stomach churns. The world starts to warp around you.", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot hostileTeaJoinedEnd000 = new GameManager.ConDot(8100, "[ ENDING 4 / 5 : REUNION ]", "", false, "", "", 00, 0, 004, GameManager.FlagState.True, 0, 0, 0, 0, 0);





    public GameManager.ConDot hostileTeaDissentEnd001 = new GameManager.ConDot(8201, "Your stomach churns. The world starts to warp around you.", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);



    public GameManager.ConDot hostileTeaDissentEnd000 = new GameManager.ConDot(8201, "[ ENDING 5 / 5 : HONOR ]", "", false, "", "", 00, 0, 005, GameManager.FlagState.True, 0, 0, 0, 0, 0);



    public GameManager.ConDot sisterTea = new GameManager.ConDot(9001, "", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);



    public GameManager.ConDot sisterTeaJoinedEnd001 = new GameManager.ConDot(9101, "Your stomach churns. The world starts to warp around you.", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);


    public GameManager.ConDot sisterTeaJoinedEnd000 = new GameManager.ConDot(9101, "[ ENDING 2 / 5 : SISTERHOOD ]", "", false, "", "", 00, 0, 002, GameManager.FlagState.True, 0, 0, 0, 0, 0);






    public GameManager.ConDot sisterTeaDissentEnd001 = new GameManager.ConDot(9201, "Your stomach churns. The world starts to warp around you.", "", false, "", "", 00, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot sisterTeaDissentEnd000 = new GameManager.ConDot(9201, "[ ENDING 3 / 5 : BETRAYAL ]", "", false, "", "", 00, 0, 003, GameManager.FlagState.True, 0, 0, 0, 0, 0);



    public GameManager.ConDot firstVoid001 = new GameManager.ConDot(11001, "You're weightless, floating in space in a black void.", "", false, "", "", 11002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid002 = new GameManager.ConDot(11002, "As your head looks up, you see a tiny point of light, almost like a star.", "", false, "", "", 11003, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid003 = new GameManager.ConDot(11003, "You look back down and notice a figure in the void, almost invisible.", "", false, "", "", 11004, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid004 = new GameManager.ConDot(11004, "They seem to smile, however you can only see their eye.", "", false, "", "", 11005, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid005 = new GameManager.ConDot(11005, "Why, hello Elena. Welcome!", "???", false, "", "", 11006, 00, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    public GameManager.ConDot firstVoid006 = new GameManager.ConDot(11006, "Who are you?", "You", false, "", "", 11007, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid007 = new GameManager.ConDot(11007, "I am you, a part of you-- repressed, yes, but you.", "???", false, "", "", 11008, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid008 = new GameManager.ConDot(11008, "Me? But I'm Elena!", "You", false, "", "", 11009, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid009 = new GameManager.ConDot(11009, "I'm Elena too.", "Elena?", false, "", "", 11010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid010 = new GameManager.ConDot(11010, "But I'm Elena!", "You", false, "", "", 11010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid011 = new GameManager.ConDot(11011, "And why can't we have the same name?", "Elena?", false, "", "", 11011, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid012 = new GameManager.ConDot(11012, "Something weird is in your stomach.", "", false, "", "", 11013, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid013 = new GameManager.ConDot(11013, "It feels like it isn't mine. I want it to be my name. *My* name.", "You", false, "", "", 11014, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid014 = new GameManager.ConDot(11014, "It will be, Elena, don't worry.", "Elena?", false, "", "", 11015, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    public GameManager.ConDot firstVoid015 = new GameManager.ConDot(11015, "You don't know how to react. You feel distant happiness, but also distant... sadness?", "", false, "", "", 11016, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid016 = new GameManager.ConDot(11016, "You don't feel like yourself. Your chest tightens.", "", false, "", "", 11017, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid017 = new GameManager.ConDot(11017, "Breathe, Elena, confusion is normal when you are first here.", "Elena?", false, "", "", 11010, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid018 = new GameManager.ConDot(11018, "I don't feel right when I'm here. I want to go back. I want to go back!", "You", false, "", "", 11019, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid019 = new GameManager.ConDot(11019, "The other Elena seems sad.", "", false, "", "", 11020, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid020 = new GameManager.ConDot(11020, "Okay. You can go back.", "Elena?", false, "", "", 11021, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid021 = new GameManager.ConDot(11021, "What? Can you send me back?", "You", false, "", "", 11022, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid022 = new GameManager.ConDot(11022, "You will it yourself. I have no control over it.", "Elena?", false, "", "", 11023, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid023 = new GameManager.ConDot(11023, "You will see me again when you find another ending to the story.", "Elena?", false, "", "", 11024, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid024 = new GameManager.ConDot(11024, "You don't really care about what they're saying. You just want to stop feeling empty.", "", false, "", "", 11023, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid025 = new GameManager.ConDot(11025, "You clasp your hands and press them together, hoping with all your heart you can go back.", "", false, "", "", 11026, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);
    public GameManager.ConDot firstVoid026 = new GameManager.ConDot(11026, "The speck in the distance grows farther and farther until it disappears, and you close your eyes.", "", false, "", "", 11027, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);


    public GameManager.ConDot repeatVoid001 = new GameManager.ConDot(88001, "You're weightless, floating in space in a black void.", "", false, "", "", 99002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);






    public GameManager.ConDot secondVoid001 = new GameManager.ConDot(12001, "", "", false, "", "", 12002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot thirdVoid001 = new GameManager.ConDot(13001, "", "", false, "", "", 13002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot forthVoid001 = new GameManager.ConDot(14001, "", "", false, "", "", 14002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);




    public GameManager.ConDot fifthVoid001 = new GameManager.ConDot(15001, "", "", false, "", "", 15002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);


    public GameManager.ConDot trueEnd001 = new GameManager.ConDot(99001, "", "", false, "", "", 15002, 0, 0, GameManager.FlagState.NotSet, 0, 0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public IEnumerator Load()
    {
        print("call");
        tempcdList.Add(prolouge1);
        tempcdList.Add(prolouge2);
        tempcdList.Add(prolouge3);
        tempcdList.Add(prolouge4);
        tempcdList.Add(prolouge5);
        tempcdList.Add(prolouge6);

        tempcdList.Add(breakfast001);
        tempcdList.Add(breakfast002);
        tempcdList.Add(breakfast003);
        tempcdList.Add(breakfast004);
        tempcdList.Add(breakfast005);
        tempcdList.Add(breakfast006);
        tempcdList.Add(breakfast007);
        tempcdList.Add(breakfast008);
        tempcdList.Add(breakfast009);
        tempcdList.Add(breakfast010);
        tempcdList.Add(breakfast011);
        tempcdList.Add(breakfast012);
        tempcdList.Add(breakfast013);
        tempcdList.Add(breakfast014);
        tempcdList.Add(breakfast015);
        tempcdList.Add(breakfast016);
        tempcdList.Add(breakfast017);
        tempcdList.Add(breakfast018);
        tempcdList.Add(breakfast019);
        tempcdList.Add(breakfast020);
        tempcdList.Add(breakfast021);
        tempcdList.Add(breakfast022);
        tempcdList.Add(breakfast023);
        tempcdList.Add(breakfast024);
        tempcdList.Add(breakfast025);
        tempcdList.Add(breakfast026);
        tempcdList.Add(breakfast027);
        tempcdList.Add(breakfast028);
        tempcdList.Add(breakfast029);
        tempcdList.Add(breakfast030);
        tempcdList.Add(breakfast031);
        tempcdList.Add(breakfast032);
        tempcdList.Add(breakfast033);
        tempcdList.Add(breakfast034);

        tempcdList.Add(breakfastend001);
        tempcdList.Add(breakfastend002);
        tempcdList.Add(breakfastend003);
        tempcdList.Add(breakfastend004);
        tempcdList.Add(breakfastend005);
        tempcdList.Add(breakfastend006);
        tempcdList.Add(breakfastend007);
        tempcdList.Add(breakfastend008);
        tempcdList.Add(breakfastend009);
        tempcdList.Add(breakfastend010);
        tempcdList.Add(breakfastend011);
        tempcdList.Add(breakfastend012);
        tempcdList.Add(breakfastend013);
        tempcdList.Add(breakfastend014);
        tempcdList.Add(breakfastend015);
        tempcdList.Add(breakfastend016);
        tempcdList.Add(breakfastend017);
        tempcdList.Add(breakfastend018);

        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        yield return StartCoroutine(MakeConDotSOHolderofList(gm.breakfast));

        tempcdList.Add(garden001);
        tempcdList.Add(garden002);
        tempcdList.Add(garden003);
        tempcdList.Add(garden004);
        tempcdList.Add(garden005);
        tempcdList.Add(garden006);
        tempcdList.Add(garden007);
        tempcdList.Add(garden008);
        tempcdList.Add(garden009);
        tempcdList.Add(garden010);
        tempcdList.Add(garden011);
        tempcdList.Add(garden012);
        tempcdList.Add(garden013);
        tempcdList.Add(garden014);
        tempcdList.Add(garden015);
        tempcdList.Add(garden016);
        tempcdList.Add(garden017);
        tempcdList.Add(garden018);
        tempcdList.Add(garden019);
        tempcdList.Add(garden020);
        tempcdList.Add(garden021);
        tempcdList.Add(garden022);

        tempcdList.Add(garden023);
        tempcdList.Add(garden024);
        tempcdList.Add(garden025);
        tempcdList.Add(garden026);
        tempcdList.Add(garden027);
        tempcdList.Add(garden028);
        tempcdList.Add(garden029);
        tempcdList.Add(garden030);
        tempcdList.Add(garden031);
        tempcdList.Add(garden032);
        tempcdList.Add(garden033);
        tempcdList.Add(garden034);
        tempcdList.Add(garden035);
        tempcdList.Add(garden036);
        tempcdList.Add(garden037);
        tempcdList.Add(garden038);
        tempcdList.Add(garden039);
        tempcdList.Add(garden040);
        tempcdList.Add(garden041);
        tempcdList.Add(garden042);
        tempcdList.Add(garden043);
        tempcdList.Add(garden044);
        tempcdList.Add(garden045);

        tempcdList.Add(hostileGardenEnd001);
        tempcdList.Add(hostileGardenEnd002);
        tempcdList.Add(hostileGardenEnd003);
        tempcdList.Add(hostileGardenEnd004);

        tempcdList.Add(sisterGardenEnd001);
        tempcdList.Add(sisterGardenEnd002);
        tempcdList.Add(sisterGardenEnd003);
        tempcdList.Add(sisterGardenEnd004);
        tempcdList.Add(sisterGardenEnd005);

        tempcdList.Add(nightGarden001);
        tempcdList.Add(nightGarden002);
        tempcdList.Add(nightGarden003);
        tempcdList.Add(nightGarden004);
        tempcdList.Add(nightGarden005);
        tempcdList.Add(nightGarden006);
        tempcdList.Add(nightGarden007);
        tempcdList.Add(nightGarden008);
        tempcdList.Add(nightGarden009);
        tempcdList.Add(nightGarden010);
        tempcdList.Add(nightGarden011);
        tempcdList.Add(nightGarden012);
        tempcdList.Add(nightGarden013);
        tempcdList.Add(nightGarden014);
        tempcdList.Add(nightGarden015);
        tempcdList.Add(nightGarden016);
        tempcdList.Add(nightGarden017);
        tempcdList.Add(nightGarden018);
        tempcdList.Add(nightGarden019);
        tempcdList.Add(nightGarden020);
        tempcdList.Add(nightGarden021);
        tempcdList.Add(nightGarden022);
        tempcdList.Add(nightGarden023);
        tempcdList.Add(nightGarden024);
        tempcdList.Add(nightGarden025);
        tempcdList.Add(nightGarden026);
        tempcdList.Add(nightGarden027);
        tempcdList.Add(nightGarden028);
        tempcdList.Add(nightGarden029);
        tempcdList.Add(nightGarden030);
        tempcdList.Add(nightGarden031);
        tempcdList.Add(nightGarden032);
        tempcdList.Add(nightGarden033);
        tempcdList.Add(nightGarden034);
        tempcdList.Add(nightGarden035);
        tempcdList.Add(nightGarden036);
        tempcdList.Add(nightGarden037);
        tempcdList.Add(nightGarden038);
        tempcdList.Add(nightGarden039);
        tempcdList.Add(nightGarden040);
        tempcdList.Add(nightGarden041);
        tempcdList.Add(nightGarden042);
        tempcdList.Add(nightGarden043);
        tempcdList.Add(nightGarden044);
        tempcdList.Add(nightGarden045);
        tempcdList.Add(nightGarden046);
        tempcdList.Add(nightGarden047);
        tempcdList.Add(nightGarden048);
        tempcdList.Add(nightGarden049);
        tempcdList.Add(nightGarden050);
        tempcdList.Add(nightGarden051);
        tempcdList.Add(nightGarden052);
        tempcdList.Add(nightGarden053);
        tempcdList.Add(nightGarden054);
        tempcdList.Add(nightGarden055);
        tempcdList.Add(nightGarden056);
        tempcdList.Add(nightGarden057);
        tempcdList.Add(nightGarden058);
        tempcdList.Add(nightGarden059);
        tempcdList.Add(nightGarden060);
        tempcdList.Add(nightGarden061);
        tempcdList.Add(nightGarden062);
        tempcdList.Add(nightGarden063);
        tempcdList.Add(nightGarden064);
        tempcdList.Add(nightGarden065);
        tempcdList.Add(nightGarden066);
        tempcdList.Add(nightGarden067);
        tempcdList.Add(nightGarden068);
        tempcdList.Add(nightGarden069);
        tempcdList.Add(nightGarden070);
        tempcdList.Add(nightGarden071);
        tempcdList.Add(nightGarden072);
        tempcdList.Add(nightGarden073);
        tempcdList.Add(nightGarden074);
        tempcdList.Add(nightGarden075);
        tempcdList.Add(nightGarden076);
        tempcdList.Add(nightGarden077);
        tempcdList.Add(nightGarden078);
        tempcdList.Add(nightGarden079);
        tempcdList.Add(nightGarden080);
        tempcdList.Add(nightGarden081);
        tempcdList.Add(nightGarden082);
        tempcdList.Add(nightGarden083);
        tempcdList.Add(nightGarden084);
        tempcdList.Add(nightGarden085);
        tempcdList.Add(nightGarden086);
        tempcdList.Add(nightGarden087);
        tempcdList.Add(nightGarden088);
        tempcdList.Add(nightGarden089);
        tempcdList.Add(nightGarden090);
        tempcdList.Add(nightGarden091);
        tempcdList.Add(nightGarden092);

        tempcdList.Add(hostileNightGardenEnd001);
        tempcdList.Add(hostileNightGardenEnd002);
        tempcdList.Add(hostileNightGardenEnd003);
        tempcdList.Add(hostileNightGardenEnd004);
        tempcdList.Add(hostileNightGardenEnd005);
        tempcdList.Add(hostileNightGardenEnd006);
        tempcdList.Add(hostileNightGardenEnd007);
        tempcdList.Add(hostileNightGardenEnd008);
        tempcdList.Add(hostileNightGardenEnd009);
        tempcdList.Add(hostileNightGardenEnd010);
        tempcdList.Add(hostileNightGardenEnd011);
        tempcdList.Add(hostileNightGardenEnd012);
        tempcdList.Add(hostileNightGardenEnd013);
        tempcdList.Add(hostileNightGardenEnd014);
        tempcdList.Add(hostileNightGardenEnd015);
        tempcdList.Add(hostileNightGardenEnd016);
        tempcdList.Add(hostileNightGardenEnd017);
        tempcdList.Add(hostileNightGardenEnd018);
        tempcdList.Add(hostileNightGardenEnd019);
        tempcdList.Add(hostileNightGardenEnd020);
        tempcdList.Add(hostileNightGardenEnd021);
        tempcdList.Add(hostileNightGardenEnd022);
        tempcdList.Add(hostileNightGardenEnd023);
        tempcdList.Add(hostileNightGardenEnd024);
        tempcdList.Add(hostileNightGardenEnd025);
        tempcdList.Add(hostileNightGardenEnd026);
        tempcdList.Add(hostileNightGardenEnd027);




        tempcdList.Add(firstVoid001);
        tempcdList.Add(firstVoid002);
        tempcdList.Add(firstVoid003);
        tempcdList.Add(firstVoid004);
        tempcdList.Add(firstVoid005);
        tempcdList.Add(firstVoid006);
        tempcdList.Add(firstVoid007);
        tempcdList.Add(firstVoid008);
        tempcdList.Add(firstVoid009);
        tempcdList.Add(firstVoid010);
        tempcdList.Add(firstVoid011);
        tempcdList.Add(firstVoid012);
        tempcdList.Add(firstVoid013);
        tempcdList.Add(firstVoid014);
        tempcdList.Add(firstVoid015);
        tempcdList.Add(firstVoid016);
        tempcdList.Add(firstVoid017);
        tempcdList.Add(firstVoid018);
        tempcdList.Add(firstVoid019);
        tempcdList.Add(firstVoid020);
        tempcdList.Add(firstVoid021);
        tempcdList.Add(firstVoid022);
        tempcdList.Add(firstVoid023);
        tempcdList.Add(firstVoid024);
        tempcdList.Add(firstVoid025);
        tempcdList.Add(firstVoid026);

        yield break;
    }

    public IEnumerator MakeConDotSOHolderofList(Holder daholder)
    {

        foreach (GameManager.ConDot cd in tempcdList)
        {
            print("call");
            ConDotSO newScriptableObject = ScriptableObject.CreateInstance<ConDotSO>();

            newScriptableObject.name = cd.Id.ToString();

            newScriptableObject.id = cd.Id;

            newScriptableObject.dia = cd.Dia;

            newScriptableObject.characterName = cd.CharacterName;

            newScriptableObject.buttonBool = cd.ButtonBool;

            newScriptableObject.leftChoice = cd.LeftChoice;

            newScriptableObject.rightChoice = cd.RightChoice;

            newScriptableObject.leftConDot = cd.LeftConDot;

            newScriptableObject.rightConDot = cd.RightConDot;

            newScriptableObject.flagIdToBeSet = cd.FlagIdToBeSet;

            newScriptableObject.flagIdStateToBeSet = cd.FlagIdStateToBeSet;

            newScriptableObject.conDotIfFlagTrue = cd.ConDotIfFlagTrue;

            newScriptableObject.conDotIfFlagFalse = cd.ConDotIfFlagFalse;

            newScriptableObject.idForLeftImage = cd.IdForLeftImage;

            newScriptableObject.idForRightImage = cd.IdForRightImage;

            temporaryListOfConDotSOToTransfer.Add(newScriptableObject);

            print("Created ConDotSo: " + newScriptableObject.name);
        }

        print(daholder);

        tempcdList.Clear();

        yield break;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadToGm()
    {

        /*tempcdList.Add(holder.cd001);

        gm.tempcdList.Clear();
        
        foreach (GameManager.ConDot cd in tempcdList)
        {
            gm.tempcdList.Add(cd);
        }*/
    }
}
