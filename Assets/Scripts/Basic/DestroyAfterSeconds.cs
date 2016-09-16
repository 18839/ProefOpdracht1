using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    [SerializeField]
    private float _destroySeconds;

	void Start()
    {
        Destroy(this.gameObject, _destroySeconds);
    }
}
