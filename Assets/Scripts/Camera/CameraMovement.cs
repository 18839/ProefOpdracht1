using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    //Floats
    [SerializeField]
    private float _camFollowSpeed = 0.25f; // Amount of speed.
    private float _cameraMagnitudeVel = 10;
    private float _camFollowVelocity;
    //Floats


    //GameObject
    private GameObject _cameraTarget; // Obj that will change during runtime.

    [SerializeField]
    private GameObject _cameraPlayer; // Player object.

    public GameObject cameraChange; // Change camera target to...
    //GameObject

    //Vector3
    private Vector3 _offset;
    private Vector3 _cameraTargetPos;
    //Vector3



    void Start()
    {
        _cameraTargetPos = transform.position; // Locks it's own position.
      //  _cameraTarget = _cameraPlayer; // Target of the camera starts at the player.
    }



    void FixedUpdate()
    {
        FollowCamera();


        /*
         * Why FixedUpdate?
         * FixedUpdate makes it run more smooth.
         */
    }

    void FollowCamera()
    {
        if (_cameraTarget != null) // Only run this function if the target exists.
        {
            Vector3 posNoZ = transform.position; // Grab the camera's position.
            posNoZ.z = _cameraTarget.transform.position.z; // Set it to the target's z axis.

            Vector3 _cameraTargetDirection = (_cameraTarget.transform.position - posNoZ);

            _camFollowVelocity = _cameraTargetDirection.magnitude * _cameraMagnitudeVel;

            _cameraTargetPos = transform.position + (_cameraTargetDirection.normalized * _camFollowVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, _cameraTargetPos + _offset, _camFollowSpeed); // Smoothly change the cam's position to the target's position.
        }
    }

    public IEnumerator ChangeTarget(bool limited, float duration)
    {
        /*
         * Method with two parameters, limited, and duration.
         * Once you call this function, you'll be given two options: Is it limited, or not? If so, how long?
         * If it's limited, it'll change it's target for a certain amount of time. You will be given that certain amount as duration.
         
         * If it's not limited, it's new target will stay forever.
         */


        if (limited)
        {
            _cameraTarget = cameraChange;
            yield return new WaitForSeconds(duration); // Wait for the amount of seconds given.
            _cameraTarget = _cameraPlayer; // Set it back to the player.
            limited = false; 
        }

        else
            _cameraTarget = cameraChange; // Not limited? Stays forever.
    }
}