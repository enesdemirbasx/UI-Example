using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MissionComplateScreen : MonoBehaviour
{
    public Image BlurBG;

    private void Awake()
    {
        BlurBG.DOFade(0, 0);
    }

    private void Start()
    {
        BlurBG.DOFade(1, 0.3f);
    }
}
