using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ConDotSO", menuName = "ConDotSO")]
public class ConDotSO : ScriptableObject
{
    public int Id;
    public string Dia;
    public string CharacterName;
    public bool ButtonBool;
    public string LeftChoice;
    public string RightChoice;
    public int LeftConDot;
    public int RightConDot;
    public int FlagIdToBeSet;
    public GameManager.FlagState FlagIdStateToBeSet;
    public int FlagIdToReadForNextConDot;
    public int ConDotIfFlagTrue;
    public int ConDotIfFlagFalse;
    public int IdForLeftImage;
    public int IdForRightImage;
}
