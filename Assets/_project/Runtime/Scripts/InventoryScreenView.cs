using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InventoryScreenView : MonoBehaviour
{
    public CanvasGroup CanvasGroupTop;
    public CanvasGroup CanvasGroupBottom;
    public CanvasGroup CanvasGroupMiddle;

    public GameObject Top;
    public GameObject Middle;
    public GameObject Bottom;

    private void Awake()
    {
        CanvasGroupTop.alpha = 0;
        CanvasGroupBottom.alpha = 0;
        CanvasGroupMiddle.alpha = 0;
        Top.transform.DOMoveY(40,0).SetRelative(true);
        Bottom.transform.DOMoveY(-40, 0).SetRelative(true);
        Middle.transform.DOMoveY(40, 0).SetRelative(true);
    }

    private void Start()
    {
        DOTween.To(() => CanvasGroupTop.alpha, x => CanvasGroupTop.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupBottom.alpha, x => CanvasGroupBottom.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupMiddle.alpha, x => CanvasGroupMiddle.alpha = x, 1, .6f);

        Top.transform.DOMoveY(-40, .6f).SetRelative(true);
        Bottom.transform.DOMoveY(40, .6f).SetRelative(true);
        Middle.transform.DOMoveY(-40, .6f).SetRelative(true);
    }
}
