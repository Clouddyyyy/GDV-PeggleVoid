using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    void Start()
    {
        
    }

    
    void Update()
    {
        Score.text = "Hallo je score is";
    }
}
