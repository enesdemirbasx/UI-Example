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
    // public Image Profile;
    // public Image ProfilePicture;
    // public Image ExpBar;
    // public Image LevelBG;
    // public TextMeshProUGUI Username;
    // public TextMeshProUGUI Rank;
    // public TextMeshProUGUI Exp;
    // public TextMeshProUGUI ExpCount;
    //
    // public Image Coin;
    // public Image Scrolls;
    // public Image CoinIco;
    // public Image ScrollIco;
    // public Image Plus1;
    // public Image Plus2;
    // public TextMeshProUGUI CoinCount;
    // public TextMeshProUGUI ScrollCount;
    //
    // public Image RankButton;
    // public Image InventoryButton;
    // public Image InboxButton;
    // public Image MapButton;
    // public Image Ico1;
    // public Image Ico2;
    // public Image Ico3;
    // public Image Ico4;
    // public Image Ico5;
    // public Image Ico6;
    // public TextMeshProUGUI textRank;
    // public TextMeshProUGUI textInventory;
    // public TextMeshProUGUI textInbox;
    // public TextMeshProUGUI textMap;
    // public TextMeshProUGUI Count;
    //
    //
    // public GameObject Bottom;
    // public Image Slot1;
    // public Image Slot2;
    // public Image FullSlot;
    // public Image Food;
    // public Image Blackout1;
    // public Image Blackout2;
    // public Image Controller;
    // public Image Skill1;
    // public Image Skill2;
    // public Image Skill3;
    // public Image Skill4;
    // public TextMeshProUGUI num1;
    // public TextMeshProUGUI num2;
    //
    // public GameObject Left;
    // public Image Quest1;
    // public Image Line;
    // public Image InformationIco;
    // public TextMeshProUGUI Quests1;
    // public Image QuestGreen;
    // public TextMeshProUGUI QuestGreenText;
    // public Image Tick;
    // public Image Quest2;
    // public TextMeshProUGUI Quest2Text;
    // public Image Qstar;
    // public Image Quest3;
    // public TextMeshProUGUI Quest3Text;
    // public Image Qstar2;
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
        
        // Coin.transform.DOMoveY(40, .3f).SetRelative(true);
        // Scrolls.transform.DOMoveY(40, .3f).SetRelative(true);
        // InventoryButton.transform.DOMoveX(40, .3f).SetRelative(true);
        // RankButton.transform.DOMoveX(40, .3f).SetRelative(true);
        // InboxButton.transform.DOMoveX(40, .3f).SetRelative(true);
        // MapButton.transform.DOMoveX(40, .3f).SetRelative(true);
        // Bottom.transform.DOMoveY(-40, .3f).SetRelative(true);
        // Left.transform.DOMoveX(-40, .3f).SetRelative(true);
        // Profile.DOFade(0, .3f);
        // ProfilePicture.DOFade(0, .3f);
        // Username.DOFade(0, .3f);
        // Rank.DOFade(0, .3f);
        // ExpBar.DOFade(0, .3f);
        // LevelBG.DOFade(0, .3f);
        // Exp.DOFade(0, .3f);
        // Coin.DOFade(0, .3f);
        // Scrolls.DOFade(0, .3f);
        // CoinIco.DOFade(0, .3f);
        // ScrollIco.DOFade(0, .3f);
        // Plus1.DOFade(0, .3f);
        // Plus2.DOFade(0, .3f);
        // CoinCount.DOFade(0, .3f);
        // ScrollCount.DOFade(0, .3f);
        // RankButton.DOFade(0, .3f);
        // InventoryButton.DOFade(0, .3f);
        // InboxButton.DOFade(0, .3f);
        // MapButton.DOFade(0, .3f);
        // Ico1.DOFade(0, .3f);
        // Ico2.DOFade(0, .3f);
        // Ico3.DOFade(0, .3f);
        // Ico4.DOFade(0, .3f);
        // Ico5.DOFade(0, .3f);
        // Ico6.DOFade(0, .3f);
        // textRank.DOFade(0, .3f);
        // textInventory.DOFade(0, .3f);
        // textInbox.DOFade(0, .3f);
        // textMap.DOFade(0, .3f);
        // Count.DOFade(0, .3f);
        // Slot1.DOFade(0, .3f);
        // Slot2.DOFade(0, .3f);
        // FullSlot.DOFade(0, .3f);
        // Food.DOFade(0, .3f);
        // Blackout1.DOFade(0, .3f);
        // Blackout2.DOFade(0, .3f);
        // Controller.DOFade(0, .3f);
        // Skill1.DOFade(0, .3f);
        // Skill2.DOFade(0, .3f);
        // Skill3.DOFade(0, .3f);
        // Skill4.DOFade(0, .3f);
        // num1.DOFade(0, .3f);
        // num2.DOFade(0, .3f);
        // Quest1.DOFade(0, .3f);
        // Quest2.DOFade(0, .3f);
        // Quest3.DOFade(0, .3f);
        // Line.DOFade(0, .3f);
        // InformationIco.DOFade(0, .3f);
        // Quests1.DOFade(0, .3f);
        // QuestGreen.DOFade(0, .3f);
        // QuestGreenText.DOFade(0, .3f);
        // Tick.DOFade(0, .3f);
        // Quest2Text.DOFade(0, .3f);
        // Qstar.DOFade(0, .3f);
        // Qstar2.DOFade(0, .3f);
        // Quest3Text.DOFade(0, .3f);
        //
        // BundleModel.Instance = new BundleModel();
        // var screenManager = ScreenManager.Instance;
        // await screenManager.OpenScreen(ScreenKeys.InventoryScreen, ScreenLayers.Layer1);
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