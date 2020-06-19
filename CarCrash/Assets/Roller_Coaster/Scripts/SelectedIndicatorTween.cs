using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedIndicatorTween : MonoBehaviour {

    [SerializeField]
    private Vector3 _toScale;
    [SerializeField]
    private LeanTweenType _easeType;
    [SerializeField]
    private float _time;

    private void Awake() {
        LeanTween.scale(this.gameObject, _toScale, _time).setEase(_easeType).setLoopPingPong();
    }

}
