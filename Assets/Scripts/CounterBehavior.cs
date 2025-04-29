using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterBehavior : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int _count;
    private bool _updated;

    public Button continueButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText($"{_count}/6 Errors Found");
        _updated = false;
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void IncrementCounter()
    {
        if (_count < 6)
        {
            _count++;
            text.SetText($"{_count}/6 Errors Found");
            
            if (_count == 6 && _updated == false)
            {
                continueButton.interactable = true;
                continueButton.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
         
    }
}
