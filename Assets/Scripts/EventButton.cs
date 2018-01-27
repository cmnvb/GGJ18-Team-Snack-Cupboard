//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour {

    public enum colour { RED, BLUE, GREEN, YELLOW };
    public colour ButtonColour;

    /// <summary>
    /// Called by VRTK when this button had been pressed
    /// </summary>
    public void PushButton()
    {
        Debug.Log("Button Pressed: " + ButtonColour.ToString());
        
    }

}
