using UnityEngine;
using UnityEngine.UI;

public class TutorialHandTween : MonoBehaviour {

    [SerializeField]
    private bool _playOnAwake = true;
    [SerializeField]
    private float _toScale = 0.75f;
    [SerializeField]
    private float _shrinkAnimationSpeed = 1f;

    [SerializeField]
    private GameObject _handImageObj = null;
    [SerializeField]
    private GameObject _popLineObj = null;

    private void Awake() {
        if (_playOnAwake) {
            StartTween();
        }
    }

    public void StartTween() {
        if (LeanTween.isTweening(this.gameObject)) {
            return;
        }

        // HAND IMAGE
        LeanTween.delayedCall(_handImageObj, 1.5f, () => {
            LeanTween.scale(_handImageObj, Vector3.one * _toScale, _shrinkAnimationSpeed)
            .setLoopPingPong()
            .setEase(LeanTweenType.easeInOutBack).setRepeat(2);
        }).setRepeat(-1);

        // POP LINE IMAGE
        LeanTween.delayedCall(_popLineObj, 1.5f, () => {
            LeanTween.scale(_popLineObj, Vector3.one, _shrinkAnimationSpeed)
            .setFrom(0f)
            .setLoopPingPong()
            .setEase(LeanTweenType.easeInOutCirc)
            .setRepeat(2);
        }).setRepeat(-1);
    }

    public void StopTween() {

    }

}
