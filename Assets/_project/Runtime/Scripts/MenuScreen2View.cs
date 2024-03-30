using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class MenuScreen2View : MonoBehaviour
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
    public GameObject Middle;

    public Image ComplateImage;
    public Image ComplateImage2;
    public Image QuestIco;
    public Image QuestIco2;
    public Image BlurBG;
    public Image QuestComplatedBG;
    public Image TickImage;

    public TextMeshProUGUI Title;
    public Sprite Tick;

    private void Awake()
    {
        TickImage.transform.DOScale(1.8f, 0);
        TickImage.DOFade(0, 0);
        QuestComplatedBG.DOFade(0, 0);
        QuestComplatedBG.transform.DOMoveY(40, 0).SetRelative(true);
        Title.transform.DOScale(1.8f, 0);
        Title.DOFade(0, 0);
        BlurBG.DOFade(0, 0);
        BlurBG.enabled = false;
        ComplateImage.DOFade(0, 0);
        ComplateImage2.DOFade(0, 0);
        CanvasGroupTop.alpha = 0;
        CanvasGroupBottom.alpha = 0;
        CanvasGroupMiddle.alpha = 0;
        CanvasGroupLeft.alpha = 0;
        CanvasGroupRight.alpha = 0;
        Top.transform.DOMoveY(40, 0).SetRelative(true);
        Bottom.transform.DOMoveY(-40, 0).SetRelative(true);
        Left.transform.DOMoveX(-40, 0).SetRelative(true);
        Right.transform.DOMoveX(40, 0).SetRelative(true);
        Top.transform.DOMoveY(-40, .3f).SetRelative(true);
        Bottom.transform.DOMoveY(40, .3f).SetRelative(true);
        Left.transform.DOMoveX(40, .3f).SetRelative(true);
        Right.transform.DOMoveX(-40, .3f).SetRelative(true);
        DOTween.To(() => CanvasGroupTop.alpha, x => CanvasGroupTop.alpha = x, 1, .3f);
        DOTween.To(() => CanvasGroupBottom.alpha, x => CanvasGroupBottom.alpha = x, 1, .3f);
        DOTween.To(() => CanvasGroupLeft.alpha, x => CanvasGroupLeft.alpha = x, 1, .3f);
        DOTween.To(() => CanvasGroupRight.alpha, x => CanvasGroupRight.alpha = x, 1, .3f);
        DOTween.To(() => CanvasGroupMiddle.alpha, x => CanvasGroupMiddle.alpha = x, 1, .3f);
        StartCoroutine(QuestComp(ComplateImage, QuestIco, .5f));
    }

    private void Start()
    {
    }

    private IEnumerator QuestComp(Image Green, Image Ico, float delay)
    {
        yield return new WaitForSeconds(delay);

        Green.DOFade(1, .5f);
        Green.transform.DOScaleX(1f, .5f);
        Green.transform.DOScaleY(1f, .5f);
        Ico.transform.DOMoveX(-40, 0).SetRelative(true);
        Ico.sprite = Tick;
        Ico.transform.DOMoveX(40, 0.5f).SetRelative(true);
    }

    public async void OnClickPotion()
    {
        StartCoroutine(QuestComp(ComplateImage2, QuestIco2, 0));
        StartCoroutine(PotionClickAnimation());
    }

    IEnumerator PotionClickAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Top.transform.DOMoveY(40, .5f).SetRelative(true);
        Bottom.transform.DOMoveY(-40, .5f).SetRelative(true);
        Left.transform.DOMoveX(-40, .5f).SetRelative(true);
        Right.transform.DOMoveX(40, .5f).SetRelative(true);
        DOTween.To(() => CanvasGroupTop.alpha, x => CanvasGroupTop.alpha = x, 0, .5f);
        DOTween.To(() => CanvasGroupBottom.alpha, x => CanvasGroupBottom.alpha = x, 0, .5f);
        DOTween.To(() => CanvasGroupLeft.alpha, x => CanvasGroupLeft.alpha = x, 0, .5f);
        DOTween.To(() => CanvasGroupRight.alpha, x => CanvasGroupRight.alpha = x, 0, .5f);
        DOTween.To(() => CanvasGroupMiddle.alpha, x => CanvasGroupMiddle.alpha = x, 0, .5f);
        BlurBG.enabled = true;
        BlurBG.DOFade(1, .5f);
        StartCoroutine(QuestComplated());
    }

    IEnumerator QuestComplated()
    {
        Sequence sequence = DOTween.Sequence();
        yield return new WaitForSeconds(0.5f);
        QuestComplatedBG.DOFade(1, 0.5f);
        QuestComplatedBG.transform.DOMoveY(-40, 0.5f).SetRelative(true).OnComplete((() =>
        {
            Title.transform.DOScale(1, .3f);
            Title.DOFade(1, 0.3f).OnComplete((() =>
            {
                TickImage.transform.DOScale(1, .3f);
                TickImage.DOFade(1, 0.3f);
            }));
        }));
        ;
    }
}