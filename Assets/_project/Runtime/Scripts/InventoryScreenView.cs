using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Runtime.Core.Singleton;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryScreenView : SingletonBehaviour<InventoryScreenView>
{
    public CanvasGroup CanvasGroupTop;
    public CanvasGroup CanvasGroupBottom;
    public CanvasGroup CanvasGroupMiddle;
    public CanvasGroup CanvasGroupPotion;
    public CanvasGroup CanvasGroupEmberGrid;

    public GameObject CraftButton;
    public GameObject Top;
    public GameObject Middle;
    public GameObject Bottom;

    public Sprite EmberPotionSprite;
    public Sprite EmberSprite;
    public Sprite ButtonSprite;
    public Sprite GrayButtonSprite;

    public TextMeshProUGUI Title;
    public TextMeshProUGUI Comment;
    public TextMeshProUGUI LastText;

    public Image Potion;
    public Image BigSlot;
    public Image TextSlot;
    public Image SelectedIco;
    public Image MaterialSlot1;
    public Image MaterialSlot2;
    public Image MaterialSlot3;
    public Image Ember1;
    public Image Ember2;
    public Image Ember3;
    public Image FillSquare;
    public Image DoubleSquare;
    
    private void Awake()
    {
        DoubleSquare.enabled = false;
        Ember1.DOFade(0, 0);
        Ember2.DOFade(0, 0);
        Ember3.DOFade(0, 0);
        Ember1.enabled = false;
        Ember2.enabled = false;
        Ember3.enabled = false;
        SelectedIco.enabled = false;
        CanvasGroupTop.alpha = 0;
        CanvasGroupBottom.alpha = 0;
        CanvasGroupMiddle.alpha = 0;
        Top.transform.DOMoveY(40, 0).SetRelative(true);
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

    public void OnClickPotion()
    {
        Potion.sprite = EmberPotionSprite;
        Potion.color = Color.white;
        Potion.transform.DOMoveY(40, 0).SetRelative(true);
        Potion.transform.DOMoveY(-40, .3f).SetRelative(true);
        Potion.rectTransform.sizeDelta = new Vector2(88, 88);
        DOTween.To(() => CanvasGroupPotion.alpha, x => CanvasGroupPotion.alpha = x, 1, .5f);

        BigSlot.color = new Color(0.9529f, 0.8980f, 0.6353f);
        TextSlot.color = new Color(0.9529f, 0.8980f, 0.6353f);
        MaterialSlot1.color = new Color(0.9529f, 0.8980f, 0.6353f);
        MaterialSlot2.color = new Color(0.9529f, 0.8980f, 0.6353f);
        MaterialSlot3.color = new Color(0.9529f, 0.8980f, 0.6353f);

        Ember1.enabled = true;
        Ember2.enabled = true;
        Ember3.enabled = true;
        Ember1.sprite = EmberSprite;
        Ember2.sprite = EmberSprite;
        Ember3.sprite = EmberSprite;
        Ember1.transform.DOMoveY(40, 0).SetRelative(true);
        Ember1.DOFade(1, .3f);
        Ember1.transform.DOMoveY(-40, .3f).SetRelative(true);
        Ember2.transform.DOMoveY(40, 0).SetRelative(true);
        Ember2.DOFade(1, .3f);
        Ember2.transform.DOMoveY(-40, .3f).SetRelative(true);
        Ember3.transform.DOMoveY(40, 0).SetRelative(true);
        Ember3.DOFade(1, .3f);
        Ember3.transform.DOMoveY(-40, .3f).SetRelative(true);

        CraftButton.GetComponent<Image>().sprite = ButtonSprite;
        SelectedIco.transform.DOScaleX(.85f, 1f);
        StartCoroutine(SelectedAnimation());
        Title.text = "Big Ember Potion";
        LastText.text = "";
        Comment.text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
        StartCoroutine(AnimateText(Comment,0.02f));
    }


    IEnumerator SelectedAnimation()
    {
        SelectedIco.enabled = true;
        while (true)
        {
            SelectedIco.transform.DOScale(0.85f, 1f);
            yield return new WaitForSeconds(1);
            SelectedIco.transform.DOScale(0.95f, 1f);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator AnimateText(TextMeshProUGUI Text,float delay)
    {
        Text.ForceMeshUpdate();
        int totalVisibleCharacters = Text.textInfo.characterCount;
        int visibleCount = 0;
        int counter = 0;
        while (counter <= totalVisibleCharacters)
        {
            int visibleCountOld = visibleCount;

            visibleCount = counter % (totalVisibleCharacters + 1);

            if (visibleCount != visibleCountOld)
            {
                Text.maxVisibleCharacters = visibleCount;
            }
            counter++;
            yield return new WaitForSeconds(delay);
        }
    }

    public void OnClickCraft()
    {
        FillSquare.fillAmount = 0;
        StartCoroutine(Fill());
    }

    IEnumerator Fill()
    {
        TextMeshProUGUI GetText = CraftButton.GetComponentInChildren<TextMeshProUGUI>();
        bool isFill = true;
        while (isFill)
        {
            FillSquare.fillAmount += 0.02f;
            yield return new WaitForSeconds(.02f);
            if (FillSquare.fillAmount == 1f)
            {
                DoubleSquare.enabled = true;
                FillSquare.enabled = false;
                DoubleSquare.transform.DOScale(1.4f, .5f);
                DoubleSquare.DOFade(0, 0.5f);
                DOTween.To(() => CanvasGroupEmberGrid.alpha, x => CanvasGroupEmberGrid.alpha = x, 0, .5f);
                MaterialSlot1.color = new Color(0.6863f, 0.6863f, 0.6863f);
                MaterialSlot2.color = new Color(0.6863f, 0.6863f, 0.6863f);
                MaterialSlot3.color = new Color(0.6863f, 0.6863f, 0.6863f);
                Ember1.color = new Color(0.6863f, 0.6863f, 0.6863f);
                Ember2.color = new Color(0.6863f, 0.6863f, 0.6863f);
                Ember3.color = new Color(0.6863f, 0.6863f, 0.6863f);
                CraftButton.GetComponent<Image>().sprite = GrayButtonSprite;
                GetText.text = "in Crafting";
                StartCoroutine(AnimateText(GetText,0.04f));
                yield return new WaitForSeconds(1f);
                GetText.text = "Craft";
                StartCoroutine(AnimateText(GetText,0.04f));
                isFill = false;
            }
        }
    }

    public async void OnClickClose()
    {
        var screenView = GameScreenView.Instance;
        screenView.IsMissionComplated = true;
        var screenManager = ScreenManager.Instance;
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer1);
        await screenManager.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}