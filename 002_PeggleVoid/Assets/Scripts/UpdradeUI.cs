using TMPro;
using UnityEngine;

public class UpdradeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreField;
    void Start()
    {
        
    }

    
    void Update()
    {
        scoreField.text = "Hallo je score is";
    }
}
