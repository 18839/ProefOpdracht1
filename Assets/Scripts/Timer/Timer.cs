using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public delegate void TimerEventHandler();
    public TimerEventHandler OnTimerEnd;

    [SerializeField]
    private float _amountOfTime;

    [SerializeField]
    private float _countDownSpeed;

    public float GetAndSetTime
    {
        get { return _amountOfTime; }
        set { _amountOfTime = value; }
    }

	void Update()
    {
        CountDown();
    }

    void CountDown()
    {

            _amountOfTime -= _countDownSpeed * Time.deltaTime;
           FireDelegate();
        
    }
    
    void FireDelegate()
    {
        if (_amountOfTime <= 0)
        {
            if (OnTimerEnd != null)
                OnTimerEnd();
        }
    }
}
