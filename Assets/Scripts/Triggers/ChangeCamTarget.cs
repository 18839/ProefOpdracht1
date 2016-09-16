using UnityEngine;
using System.Collections;

public class ChangeCamTarget : MonoBehaviour {

    [SerializeField]
    private CameraMovement _camMovement;
	

    void Start()
    {
       
            StartCoroutine(_camMovement.ChangeTarget(true, 3));
    }
           
    
}
