using UnityEngine;
using System.Collections;

public class MenuSlides : MonoBehaviour {

    [SerializeField]
    private int _slideIndex;

    [SerializeField]
    private GameObject[] slideObj;

    [SerializeField]
    private GameObject[] textObj;

    /*
     * 0 = Menu;
     * 1 = Slide One
     * 2 = Slide Two
     * 3 = Slide Three
     */

    [SerializeField]
    private SFXPlayer _sfxPlayer;

    void Start()
    {
        slideObj[1].SetActive(false);
        slideObj[2].SetActive(false);
        slideObj[3].SetActive(false);
        slideObj[4].SetActive(false);

        textObj[1].SetActive(false);
        textObj[2].SetActive(false);
        textObj[3].SetActive(false);
        textObj[4].SetActive(false);
    }

    void Update()
    {
        // CheckSlideIndex();
        ContinueSlides();
    }

    void CheckSlideIndex()
    {
        if (_slideIndex == 1)
        {
            slideObj[0].SetActive(false);
            slideObj[1].SetActive(true);

            textObj[0].SetActive(false);
            textObj[1].SetActive(true);
        }

        if (_slideIndex == 2)
        {
            slideObj[1].SetActive(false);
            slideObj[2].SetActive(true);

            textObj[1].SetActive(false);
            textObj[2].SetActive(true);
        }

        if (_slideIndex == 3)
        {
            slideObj[2].SetActive(false);
            slideObj[3].SetActive(true);

            textObj[2].SetActive(false);
            textObj[3].SetActive(true);
        }

        if (_slideIndex == 4)
        {
            slideObj[3].SetActive(false);
            slideObj[4].SetActive(true);

            textObj[3].SetActive(false);
            textObj[4].SetActive(true);


            StartCoroutine("StartGame");
        }
            
    }

    IEnumerator StartGame()
    {
        AsyncOperation async = Application.LoadLevelAsync("Game");

        while (!async.isDone)
            yield return null;
    }

    void ContinueSlides()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _slideIndex += 1;
            _sfxPlayer.PlaySFX(0);
            CheckSlideIndex();
        }
    }
}
