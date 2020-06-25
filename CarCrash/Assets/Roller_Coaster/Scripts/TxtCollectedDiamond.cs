using TMPro;
using UnityEngine;

public class TxtCollectedDiamond : MonoBehaviour
{

    public float animationYOffset = 100f;
    public float animationSpeed = 0.5f;

    public RectTransform targetCanvas;
    public CanvasGroup targetCanvasGroup;
    public TextMeshProUGUI text;
    public Transform objectToFollow;
    public ImgOverlayCollectDiamond overlayCollectDiamond;

    public void ShowUI()
    {
        //RepositionText();

        targetCanvasGroup.alpha = 1;

        //float currentY = text.rectTransform.anchoredPosition.y;
        //LeanTween.moveLocalY(text.gameObject, currentY + animationYOffset, animationSpeed);
        LeanTween.value(1, 0, animationSpeed).setDelay(0.3f).setOnUpdate((float value) =>
        {
            targetCanvasGroup.alpha = value;
        });

        overlayCollectDiamond.ShowUp();
    }



    private void RepositionText()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        text.rectTransform.anchoredPosition = WorldObject_ScreenPosition;
    }

}