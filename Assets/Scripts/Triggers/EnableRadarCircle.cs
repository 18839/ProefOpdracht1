using UnityEngine;
using System.Collections;

public class EnableRadarCircle : MonoBehaviour {

    [SerializeField]
    private PlayerCollision _playerCollision;

    [SerializeField]
    private GameObject _radarCircle;

    void Start()
    {
        _radarCircle.SetActive(false);

        _playerCollision.OnChestEnter += ActivateRadarCircle;
    }

    void ActivateRadarCircle()
    {
        _radarCircle.SetActive(true);
    }
}
