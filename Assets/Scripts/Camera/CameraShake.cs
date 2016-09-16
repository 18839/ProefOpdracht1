using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    //Floats
    [SerializeField]
    private float _shakePower = 0.05f; // Amount of shaking.
    //Floats

    //Bool
    private bool _isShaking; // Is the camera shaking, or not?
	//Bool


	void Update () 
    {
        ShakeCamera();
	}

    private void ShakeCamera()
    {
        if (_isShaking)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * _shakePower;
        }
    }


    public void Shake(float duration)
    {
        _isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

  


    public void StopShaking()
    {
        _isShaking = false;
    }
}
