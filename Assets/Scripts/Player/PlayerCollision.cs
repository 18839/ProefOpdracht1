using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    private GameObject _mapCameraObj;

    private bool _chestObtained;

    public bool GetChestObtained
    {
        get { return _chestObtained; }
    }

    private bool _exitReached;

    public bool GetExit
    {
        get { return _exitReached; }
    }

    [SerializeField]
    private CameraMovement _camMovement;

    private SFXPlayer _sfxPlayer;
    private GameObject _sfxPlayerObj;

    public delegate void ChestHandler();
    public ChestHandler OnChestEnter;

    public delegate void ExitHandler();
    public ExitHandler OnExitEnter;

    void Start()
    {
        _mapCameraObj.SetActive(false);

        _sfxPlayerObj = GameObject.Find("SFX_Player");
        _sfxPlayer = _sfxPlayerObj.GetComponent<SFXPlayer>();
    }

   
	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Chest(Clone)")
        {
            if (OnChestEnter != null)
                OnChestEnter();

            _mapCameraObj.SetActive(true);
            Instantiate(_mapCameraObj, _mapCameraObj.transform.position, Quaternion.identity);

            _chestObtained = true;

            _sfxPlayer.PlaySFX(1);

            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == GameTags.exit)
        {
            if (OnExitEnter != null)
                OnExitEnter();

            _exitReached = true;
        }
    }
}
