using System.Linq;
using System.Net.WebSockets;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextViewUI : MonoBehaviour
{
    [SerializeField]
    private Text textUI = null;
    private Tween textTween;

    public void ShowTexts(string value){
        textTween?.Kill();

        textUI.text = "";
        value = value.LineBreak();
        
        textTween = textUI.DOText(value, 1.5f);
    }
}
