using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {

    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Timer _timerObj;

    void Update()
    {
        _timerText.text = "Time Left: " + _timerObj.GetAndSetTime.ToString("00");
    }
}
