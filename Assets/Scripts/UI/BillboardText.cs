using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{

    // Yes, I understand that this might be entierly pointless but making the TextMeshPro text above the player rotate towards the camera is a required mechanic for the game to 
    //feel good to play!

    void Update() 
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
