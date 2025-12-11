
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    
    [SerializeField] private List<string> items = new List<string>();
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))PrintRandomItem();
        if(Input.GetKeyDown(KeyCode.Escape))PrintAllItems();
    }
    private void PrintRandomItem() {
        Debug.Log(items[Random.Range(0,9)]);

    }
    //hier staat onder de foreach!!
    private void PrintAllItems() {
        foreach(var it in items)
        {
         Debug.Log(it); 
        }
        
    }

}

