using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;


public class IncorrectButtonBehavior : MonoBehaviour
{
    public Button button;
    
    private void Start()
    {
        button.onClick.AddListener(ButtonEvent);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ButtonEvent);
    }
  
    private void ButtonEvent()
        //Handles the results of what should happen when the button is pressed
        //For incorrect buttons, they should simply become inactive.
    {
        button.interactable = false;
    }
}
