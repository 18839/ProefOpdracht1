using UnityEngine;
using System.Collections;

public class MapCameraObject : MonoBehaviour
{

    [SerializeField]
    private CameraMovement _camMovement;

    [SerializeField]
    private float _startingTime;


    void Start()
    {
        StartCoroutine("TrackExit");
    }

    private IEnumerator TrackExit()
    {
        _camMovement.cameraChange = GameObject.FindGameObjectWithTag("Exit");
        yield return new WaitForSeconds(_startingTime);
        StartCoroutine(_camMovement.ChangeTarget(false, 3));
    }


}
