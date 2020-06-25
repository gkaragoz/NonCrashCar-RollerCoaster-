using UnityEngine;

public class ImgOverlayCollectDiamond : MonoBehaviour {

    [SerializeField]
    private RectTransform _tweenObj = null;
    [SerializeField]
    private float _time = 0.5f;
    [SerializeField]
    private Vector2 _offset;

    public RectTransform targetCanvas;
    public Transform objectToFollow;

    public void ShowUp() {
        RepositionImage();

        LeanTween.move(_tweenObj, new Vector2(Screen.width, Screen.height) + _offset, _time);
    }

    private void RepositionImage() {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        _tweenObj.anchoredPosition = WorldObject_ScreenPosition;
    }

}
