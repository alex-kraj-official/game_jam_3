using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DifficultySelector : MonoBehaviour
{
    [Header("TEXTS")]
    [SerializeField] private TextMeshProUGUI Desc_Txt;
    [SerializeField] private TextMeshProUGUI DescRec_Txt;

    [SerializeField] private string hoveredDifficulty;
    [SerializeField] public int difficulty;

    private void Update()
    {

    }

    public void SetDifficulty(string difficultyBtn)
    {
        switch (difficultyBtn)
        {
            case "easy":
                Desc_Txt.text = "You start with plenty enough resources. Enemies have low HP.";
                DescRec_Txt.text = "(Recommended for new players).";
                difficulty = 0;
                break;
            case "normal":
                Desc_Txt.text = "You start with barely enough resources. Enemies have normal HP.";
                DescRec_Txt.text = "(Recommended for experienced players).";
                difficulty = 1;
                break;
            case "hard":
                Desc_Txt.text = "You start with very little resources. Enemies have a LOT HP.";
                DescRec_Txt.text = "(Recommended for pro players).";
                difficulty = 2;
                break;
        }
        Debug.Log("Selected difficulty: " + difficulty);
    }

    public void DifficultyDesc(string difficultyBtn)
    {
        switch (difficultyBtn)
        {
            case "easy":
                Desc_Txt.SetText("You start with plenty enough resources. Enemies have low HP.");
                DescRec_Txt.SetText("(Recommended for new players).");
                break;
            case "normal":
                Desc_Txt.SetText("You start with barely enough resources. Enemies have normal HP.");
                DescRec_Txt.SetText("(Recommended for experienced players).");
                break;
            case "hard":
                Desc_Txt.SetText("You start with very little resources. Enemies have a LOT HP.");
                DescRec_Txt.SetText("(Recommended for pro players).");
                break;
            default:
                Desc_Txt.SetText("");
                DescRec_Txt.SetText("");
                break;
        }
    }
}
