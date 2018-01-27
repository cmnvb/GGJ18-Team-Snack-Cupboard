using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour {
    /// <summary>
    /// Called by VRTK when this button had been pressed
    /// </summary>
    public void PushButton()
    {

        GetComponent<MeshRenderer>().material.color = Color.blue;
        
    }

}
