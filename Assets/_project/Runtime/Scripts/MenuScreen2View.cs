using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
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
    public CanvasGroup Exp;
    public CanvasGroup Coin;
    public CanvasGroup Scroll;
    public CanvasGroup Chest;
    public CanvasGroup ClaimButton;
    public CanvasGroup EmberPotion;

    public GameObject Top;
    public GameObject Bottom;
    public GameObject Left;
    public GameObject Right;

    public Image ComplateImage;
    public Image ComplateImage2;
    public Image QuestIco;
    public Image QuestIco2;
    public Image BlurBG;
    public Image QuestComplatedBG;
    public Image TickImage;
    public Image Particle1;
    public Image Particle2;

    public TextMeshProUGUI Title;

    public Sprite Tick;

    private void Awake()
    {
        Particle1.enabled = false;
        Particle2.enabled = false;
        DOTween.To(() => ClaimButton.alpha, x => ClaimButton.alpha = x, 0, 0);
        ClaimButton.transform.DOMoveY(7.5f, 0).SetRelative(true);
        Chest.transform.DOScale(1.5f, 0);
        Chest.alpha = 0;
        Exp.transform.DOMoveY(7.5f, 0).SetRelative(true);
        DOTween.To(() => Exp.alpha, x => Exp.alpha = x, 0, 0);
        Coin.transform.DOMoveY(7.5f, 0).SetRelative(true);
        DOTween.To(() => Coin.alpha, x => Coin.alpha = x, 0, 0);
        Scroll.transform.DOMoveY(7.5f, 0).SetRelative(true);
        DOTween.To(() => Scroll.alpha, x => Scroll.alpha = x, 0, 0);
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
        Top.transform.DOMoveY(-40, .6f).SetRelative(true);
        Bottom.transform.DOMoveY(40, .6f).SetRelative(true);
        Left.transform.DOMoveX(40, .6f).SetRelative(true);
        Right.transform.DOMoveX(-40, .6f).SetRelative(true);
        DOTween.To(() => CanvasGroupTop.alpha, x => CanvasGroupTop.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupBottom.alpha, x => CanvasGroupBottom.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupLeft.alpha, x => CanvasGroupLeft.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupRight.alpha, x => CanvasGroupRight.alpha = x, 1, .6f);
        DOTween.To(() => CanvasGroupMiddle.alpha, x => CanvasGroupMiddle.alpha = x, 1, .6f);
        StartCoroutine(QuestComp(ComplateImage, QuestIco, Particle1, .5f));
    }

    private void Start()
    {
    }

    private IEnumerator QuestComp(Image Green, Image Ico, Image Particle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Green.DOFade(1, .5f);
        Green.transform.DOScaleX(1f, .5f);
        Green.transform.DOScaleY(1f, .5f);
        Particle.enabled = true;
        Particle.transform.DOScaleX(1.5f, .5f);
        Particle.transform.DOScaleY(2, .5f);
        Particle.DOFade(0, .5f);
        Ico.transform.DOMoveX(-40, 0).SetRelative(true);
        Ico.sprite = Tick;
        Ico.transform.DOMoveX(40, 0.5f).SetRelative(true);
    }

    public async void OnClickPotion()
    {
        DOTween.To(() => EmberPotion.alpha, x => EmberPotion.alpha = x, 0, .5f);
        StartCoroutine(QuestComp(ComplateImage2, QuestIco2, Particle2, 0));
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
        QuestComplatedBG.DOFade(1, 0.6f);
        QuestComplatedBG.transform.DOMoveY(-40, 0.6f).SetRelative(true).OnComplete((() =>
        {
            Title.transform.DOScale(1, .6f);
            Title.DOFade(1, 0.6f).OnComplete((() =>
            {
                TickImage.transform.DOScale(1, .6f);
                TickImage.DOFade(1, 0.6f).OnComplete((() =>
                {
                    DOTween.To(() => Exp.alpha, x => Exp.alpha = x, 1, .6f).SetEase(Ease.OutCirc);
                    Exp.transform.DOMoveY(-7.5f, .6f).SetRelative(true).SetEase(Ease.OutCirc).OnComplete((() =>
                    {
                        Coin.transform.DOMoveY(-7.5f, .6f).SetRelative(true).SetEase(Ease.OutCirc);
                        DOTween.To(() => Coin.alpha, x => Coin.alpha = x, 1, .6f).SetEase(Ease.OutCirc).OnComplete((
                            () =>
                            {
                                Scroll.transform.DOMoveY(-7.5f, .6f).SetRelative(true).SetEase(Ease.OutCirc);
                                DOTween.To(() => Scroll.alpha, x => Scroll.alpha = x, 1, .6f).SetEase(Ease.OutCirc)
                                    .OnComplete((
                                        () =>
                                        {
                                            DOTween.To(() => Chest.alpha, x => Chest.alpha = x, 1, .6f)
                                                .SetEase(Ease.OutCirc);
                                            Chest.transform.DOScale(1f, .6f).SetEase(Ease.OutCirc).OnComplete((() =>
                                            {
                                                ClaimButton.transform.DOMoveY(-7.5f, .6f).SetRelative(true)
                                                    .SetEase(Ease.OutCirc);
                                                DOTween.To(() => ClaimButton.alpha, x => ClaimButton.alpha = x, 1, .6f)
                                                    .SetEase(Ease.OutCirc);
                                            }));
                                        }));
                            }));
                    }));
                }));
            }));
        }));
        ;
    }
}