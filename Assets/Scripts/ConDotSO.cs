using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ConDotSO", menuName = "ConDotSO")]
public class ConDotSO : ScriptableObject
{
    public int id;
    public string dia;
    public string characterName;
    public bool buttonBool;
    public string leftChoice;
    public string rightChoice;
    public int leftConDot;
    public int rightConDot;
    public int flagIdToBeSet;
    public GameManager.FlagState flagIdStateToBeSet;
    public int conDotIfFlagTrue;
    public int conDotIfFlagFalse;
    public int idForLeftImage;
    public int idForRightImage;
}
