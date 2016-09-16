using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemoveBoard : MonoBehaviour {

    [SerializeField]
    private Timer _timerScript;
    [SerializeField]
    private PlayerCollision _playerCollision;

    [SerializeField]
    private Text _conditionText;

    [SerializeField]
    private string[] _conditionStrings;

    [SerializeField]
    private GameObject _mainPlayer;
    [SerializeField]
    private GameObject _timerText;
    private GameObject _boardHolder;
   
    void Start()
    {
        _conditionText.gameObject.SetActive(false);

        Invoke("FindPlayer", .5f);
        InvokeRepeating("WinCondition", 1f, 1f);

        _timerScript.OnTimerEnd += LossCondition;
        _playerCollision.OnExitEnter += WinCondition;
    }


    void FindPlayer()
    {
        _mainPlayer = GameObject.FindGameObjectWithTag(GameTags.player);
        _playerCollision = _mainPlayer.GetComponent<PlayerCollision>();
    }

    private void WinCondition()
    {
        if(_playerCollision.GetExit)
        EndGame(true);
    }

    void LossCondition()
    {
        EndGame(false);
    }

    void EndGame(bool win)
    {
        _boardHolder = GameObject.Find("BoardHolder");

        if (_boardHolder != null)
        Destroy(_boardHolder.gameObject);
        Destroy(_mainPlayer.gameObject);
        Destroy(_timerText.gameObject);

        if (win)
            StartCoroutine("WinCoroutine");
        else
            StartCoroutine("LossCoroutine");

        StartCoroutine("BackToMenu");
    }

    private IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(3);
        _conditionText.gameObject.SetActive(true);
        _conditionText.text = _conditionStrings[0];
    }

    private IEnumerator LossCoroutine()
    {
        yield return new WaitForSeconds(3);
        _conditionText.gameObject.SetActive(true);
        _conditionText.text = _conditionStrings[1];
    }

    private IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(6);
        Application.LoadLevel("Menu");
    }
}
