
using System;
using System.Collections.Generic;
using UnityEngine;
public class ComboSystem : MonoBehaviour
{

    public static event Action<int, int> OnScoreChange;
    private List<string> bumperTags = new List<string>();  
    private int scoreMultiplier = 1;
    private void Start()
 {
        BumperHit.onBumperHit += CheckForCombo;            
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;             
    }
    private void CheckForCombo(Transform t, int bumperValue)
    {
        bumperTags.Add(t.gameObject.tag);
        if (bumperTags.Count > 1)                          
        {                                                 
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;                          
            }
            else                                           
            {
                scoreMultiplier = 1;                        
                bumperTags.Clear();                         
            }
        }                                                   
         ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);

                                                           
       OnScoreChange?.Invoke(ScoreManager.Instance.score, scoreMultiplier);
    }
}

