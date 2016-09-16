using UnityEngine;
using System.Collections;

public class ChangeTransformPosition : MonoBehaviour {


    [SerializeField]
    private Transform _changeTransformTo;

    [SerializeField]
    private bool _changeAtStart;

    [SerializeField]
    private bool _ChangeViaString;
    [SerializeField]
    private string _stringObject;

    [SerializeField]
    private bool _changeLater;

    [SerializeField]
    private float _waitAmountSeconds;

    

    void Start()
    {
        if (_changeAtStart)
            transform.position = _changeTransformTo.transform.position;
        else if (_changeLater)
            StartCoroutine("ChangeTransform");
        else
            StartCoroutine("ChangeViaString");

        
    }

    private IEnumerator ChangeViaString()
    {
        yield return new WaitForSeconds(_waitAmountSeconds);
        GameObject stringObj = GameObject.FindGameObjectWithTag(GameTags.exit);
        transform.position = stringObj.transform.position;
    }

    private IEnumerator ChangeTransform()
    {
        yield return new WaitForSeconds(_waitAmountSeconds);
        transform.position = _changeTransformTo.transform.position;
    }
}
