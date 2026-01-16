using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Multiplier;

    private void Start()
    {
        ComboSystem.OnScoreChange += UpdateUI;          
    }
    private void OnDisable()
    {
        ComboSystem.OnScoreChange -= UpdateUI;          
    }
       private void UpdateUI(int score, int multiplier)    //ontvang de score en de multiplier uit het bericht
    {
        Score.text = "Score: "+score; //de text in het textveld (TMP_Text component) van de score aanpassen.
        Multiplier.text = "Multiplier: "+multiplier+"X"; //de text in het textveld (TMP_Text component) van de multiplier aanpassen.
    }
}