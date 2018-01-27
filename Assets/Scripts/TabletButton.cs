using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;
public class TabletButton : MonoBehaviour
{
    public TranslationTablet TT;
    public enum leftRight { LEFT, RIGHT }
    public leftRight LR;
    private VRTK_InteractableObject_UnityEvents tabletEvents;


    void Start()
    {
        tabletEvents = GetComponent<VRTK_InteractableObject_UnityEvents>();
        tabletEvents.OnTouch.AddListener(Use);

    }

    public void Use(object sender, VRTK.InteractableObjectEventArgs e)
    {
        Debug.Log("Lmao");
        if (LR == leftRight.LEFT) TT.MoveLeft();
        else TT.MoveRight();

    }

}
