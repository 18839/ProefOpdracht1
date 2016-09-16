using UnityEngine;
using System.Collections;

public class RadarSFX : MonoBehaviour {

    [SerializeField]
    private AudioSource _radarSFX;

    [SerializeField]
    private GameObject _playerObj;

    [SerializeField]
    private PlayerCollision _playerColScript;

    void Start()
    {
        Invoke("FindPlayer", 0.1f);
    }

    void FindPlayer()
    {
        _playerObj = GameObject.FindGameObjectWithTag(GameTags.player);
        _playerColScript = _playerObj.GetComponent<PlayerCollision>();
    }

	public void PlayRadarSFX()
    {
        if (_playerColScript.GetChestObtained)
        _radarSFX.Play();
    }
}
