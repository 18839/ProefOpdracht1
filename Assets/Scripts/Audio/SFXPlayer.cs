using UnityEngine;
using System.Collections;

public class SFXPlayer : MonoBehaviour {

    [SerializeField]
    private AudioSource[] _sfxAudio;

    public void PlaySFX(int soundeffect)
    {
        _sfxAudio[soundeffect].Play();
    }
}
