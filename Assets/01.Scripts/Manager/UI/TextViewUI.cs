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
        
    public void ShowTexts(string value){
        textUI.text = "";
        textUI.DOText(value, 1.5f);
    }
}
