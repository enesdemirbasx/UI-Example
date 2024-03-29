using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameScreenView : MonoBehaviour
{
    public CanvasGroup CanvasGroupTop;
    public CanvasGroup CanvasGroupBottom;
    public CanvasGroup CanvasGroupLeft;
    public CanvasGroup CanvasGroupMiddle;
    public CanvasGroup CanvasGroupRight;

    public GameObject Top;
    public GameObject Bottom;
    public GameObject Left;
    public GameObject Right;


    public async void OnClickInventory()
    {
        DOTween.To(() => CanvasGroupTop.alpha, x => CanvasGroupTop.alpha = x, 0, .3f);
        DOTween.To(() => CanvasGroupBottom.alpha, x => CanvasGroupBottom.alpha = x, 0, .3f);
        DOTween.To(() => CanvasGroupLeft.alpha, x => CanvasGroupLeft.alpha = x, 0, .3f);
        DOTween.To(() => CanvasGroupRight.alpha, x => CanvasGroupRight.alpha = x, 0, .3f);
        DOTween.To(() => CanvasGroupMiddle.alpha, x => CanvasGroupMiddle.alpha = x, 0, .3f);

        Top.transform.DOMoveY(40, .3f).SetRelative(true);
        Bottom.transform.DOMoveY(-40, .3f).SetRelative(true);
        Left.transform.DOMoveX(-40, .3f).SetRelative(true);
        Right.transform.DOMoveX(40, .3f).SetRelative(true);

        StartCoroutine(ScreenChange());
    }

    public async void change()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer1);
        await ScreenManager.Instance.OpenScreen(ScreenKeys.InventoryScreen, ScreenLayers.Layer1);   
    }

    private  IEnumerator ScreenChange()
    {
        yield return new WaitForSeconds(.3f);
        change();
    }
}