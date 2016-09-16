using UnityEngine;
using System.Collections;

public class RadarTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject _radarDetector;

    [SerializeField]
    private PlayerCollision _playerCollision;

    [SerializeField]
    private SpriteRenderer _RadarDecSpriteRenderer;


    private SFXPlayer _sfxPlayer;
    private GameObject _sfxPlayerObj;

    void Start()
    {
        _playerCollision.OnChestEnter += RemoveChest;

        _sfxPlayerObj = GameObject.Find("SFX_Player");
        _sfxPlayer = _sfxPlayerObj.GetComponent<SFXPlayer>();

        _radarDetector.SetActive(false);
    }

    void RemoveChest()
    {
        Destroy(_radarDetector.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(GameTags.whiteborder))
        {
            _sfxPlayer.PlaySFX(2);
        }
        else if (coll.gameObject.CompareTag(GameTags.redborder))
        {
            _sfxPlayer.PlaySFX(3);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if ( coll.gameObject.CompareTag(GameTags.whiteborder))
        {
            _radarDetector.SetActive(true);
        }
        else if (coll.gameObject.CompareTag(GameTags.redborder))
        {
            _RadarDecSpriteRenderer.color = Color.red;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(GameTags.whiteborder))
        {
            _radarDetector.SetActive(false);
        }
        else if (coll.gameObject.CompareTag(GameTags.redborder))
        {
            _RadarDecSpriteRenderer.color = Color.white;
        }
    }
}
