using TMPro;
using UnityEngine;

public class CounterBehavior : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int _count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.SetText($"{_count}/6 Errors Found");
    }

    // Update is called once per frame
    void Update()
    {
        if (_count == 6)
        {
            text.SetText("Click to continue");
        }   
    }

    public void IncrementCounter()
    {
        if (_count <= 6)
        {
            _count++;
            text.SetText($"{_count}/6 Errors Found");
        }
    }
}
