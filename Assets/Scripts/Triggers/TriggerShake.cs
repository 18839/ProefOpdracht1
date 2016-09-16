using UnityEngine;
using System.Collections;

public class TriggerShake : MonoBehaviour
{

    [SerializeField]
    private CameraShake _camShake;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == GameTags.player)
            _camShake.Shake(1f);

    }
}
