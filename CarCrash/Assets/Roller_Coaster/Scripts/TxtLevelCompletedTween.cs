using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLevelCompletedTween : MonoBehaviour {

    [SerializeField]
    private float _time = 0.5f;
    [SerializeField]
    private Vector3 _toScale = Vector3.one;
    [SerializeField]
    private LeanTweenType _easeType = LeanTweenType.easeInOutCirc;

    public void Show() {
        this.gameObject.SetActive(true);
        LeanTween.scale(this.gameObject, _toScale, _time).setFrom(Vector3.zero).setEase(_easeType);
    }

    public void Hide() {
        LeanTween.scale(this.gameObject, Vector3.zero, _time).setEase(_easeType).setOnComplete(() => {
            this.gameObject.SetActive(false);
        });
    }

}
