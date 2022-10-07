using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameGenerator : MonoBehaviour
{

    public TextMeshPro TextBox;
    private string RandomName;
    
    public void Start()
    {
        string[] names = new string[] { 
            "Mark Fluffernutt", 
            "Bighands", 
            "Flynt Coalslaw", 
            "Boggy Pete", 
            "Baldwin", 
            "Jazz Hands",
            "Boggy",
            "Juan Shot",
            "Bart Ender",
            "Jim Nastics",
            "Bill Ding"
            };
        string RandomName = names[Random.Range(0, names.Length)];
        TextBox.text = " " + RandomName;

        
    }
}
