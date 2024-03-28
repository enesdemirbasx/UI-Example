using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public async void Awake()
    {
        BundleModel.Instance = new BundleModel();
        var screenManager = ScreenManager.Instance;
        await screenManager.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
