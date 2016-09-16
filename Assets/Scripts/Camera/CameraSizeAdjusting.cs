using UnityEngine;
using System.Collections;

public class CameraSizeAdjusting : MonoBehaviour {

    //Floats
    private float _camSize;
    private float _regCamSizeToUse = 9f;

    [SerializeField] private float _camSizeToChangeTo;
    [SerializeField] private float _zoomSpeed = 2f;
    //Floats

    //GameObjects
    [SerializeField] private GameObject _mainCamGameObject;
    //GameObjects

    //Camera
    private Camera _mainCam;
    //Camera
    
    //Bool
    private bool _zoomIn = false;
    private bool _zoomOut = false;
    //Bool

    
    
	void Start ()
    {
        _mainCam = this.GetComponent<Camera>();
        _camSize = _mainCam.orthographicSize;
	}
	

	void Update () 
    {
        AdjustCamera();
        RevertCamera();
	}

   
    
    public void AdjustCamera()
    {
        if (_zoomIn)
        {
            if (_camSize <= _camSizeToChangeTo)
            {
                _camSize += _zoomSpeed * Time.deltaTime;

                _mainCam.orthographicSize = _camSize;
            }
        }
       
        
    }

    public void RevertCamera()
    {
        if(_zoomOut)
        {
            if (_camSize >= _regCamSizeToUse)
            {
                _camSize -= _zoomSpeed * Time.deltaTime;
                _mainCam.orthographicSize = _camSize;
            }
        }
    }
}
