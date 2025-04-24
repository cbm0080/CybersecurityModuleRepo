using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class CorrectButtonBehavior : MonoBehaviour
{
    public Canvas CounterCanvas;
    public Button button;
    public CounterBehavior counter;
    
    
    
    //The canvas object to be moved if the button is correct
    public Canvas targetCanvas;
    //The first point the canvas moves to
    public Vector3 intermediateVector1;
    //The second point the canvas moves to
    public Vector3 intermediateVector2;
    public string wrapDirection = "top";
    private RectTransform canvasTransform;
    private void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<CounterBehavior>();
        button.onClick.AddListener(ButtonEvent);
        DOTween.Init(false, true, LogBehaviour.Verbose);
        canvasTransform = targetCanvas.GetComponent<RectTransform>();
        float GlobaltargetX = (canvasTransform.localPosition.x - 1.301f);
        float Globaltargety = (canvasTransform.localPosition.y + 2.052f);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(ButtonEvent);
    }
  
    private void ButtonEvent()
        //Handles the results of what should happen when the button is pressed
        //For incorrect buttons, they should simply become inactive.
        //Correct buttons should become inactive and also trigger the supplementary text boxes
    {
        button.interactable = false;
        if (targetCanvas != null)
        {
            Sequence movementSequence = DOTween.Sequence();
            switch (wrapDirection)
            {
                case "left":
                    movementSequence.Append(canvasTransform.DOLocalMoveX(0.93f, 1))
                                    .Insert(0.75f, canvasTransform.DOLocalMoveZ(0.1f, 1f))
                                    .Insert(1f, canvasTransform.DOLocalMoveX(0.62f, 0.5f));
                    break;
                case "right":
                    movementSequence.Append(canvasTransform.DOLocalMoveX(-0.87f, 1))
                                    .Insert(0.75f, canvasTransform.DOLocalMoveZ(0.1f, 1f))
                                    .Insert(1f, canvasTransform.DOLocalMoveX(-0.58f, 0.5f));
                    break;
                case "top":
                    movementSequence.Append(canvasTransform.DOLocalMoveY(0.42f, 1))
                                    .Insert(0.75f,canvasTransform.DOLocalMoveZ(0.1f,1f))
                                    .Insert(1f,canvasTransform.DOLocalMoveY(0.28f, 0.5f));
                    break;
                case "bottom":
                    throw (new NotImplementedException());
                    break;
                default:
                    break;    
            }
            if (counter != null)
            {
                counter.IncrementCounter();
            }
        }
    }
}