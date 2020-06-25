using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLevelFailedTween : MonoBehaviour {

    [SerializeField]
    private float _time = 0.5f;
    [SerializeField]
    private Vector3 _toScale = Vector3.one;
    [SerializeField]
    private LeanTweenType _easeType = LeanTweenType.easeInOutCirc;
    [SerializeField]
    private GameObject _txtFailedObj = null;

    public void Show() {
        LeanTween.scale(_txtFailedObj, _toScale, _time).setFrom(Vector3.zero).setEase(_easeType);
    }

    public void Hide() {
        LeanTween.scale(_txtFailedObj, Vector3.zero, _time).setEase(_easeType);
    }

}
