using UnityEngine;
using System.Collections;

public class LevelOST : MonoBehaviour {

    [SerializeField]
    private Timer _timerScript;

    [SerializeField]
    private AudioSource _levelSoundtrack;

  
    void Start()
    {
        _timerScript.OnTimerEnd += StopMusic;
    }

    void StopMusic()
    {
        _levelSoundtrack.Stop();
    }
}
