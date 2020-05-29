using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WidgetViewer : MonoBehaviour
{
    [SerializeField]
    private TextViewUI monolougeObject;
    
    [SerializeField]
    private TextViewUI systemTextObject;

    [SerializeField]
    private TextViewUI invenstigateObject;

    private TextViewUI selectTextUI;
    private string[] textValues;
    private int index = 0;

    public Action endEvent {get; set;}

    private bool isOpen = false;
    
    public void ShowInvenstigate(params string[] texts){
        selectTextUI = invenstigateObject;
        textValues = texts;

        OpenSetting();
    }

    public void ShowMonologue(params string[] texts){
        selectTextUI = monolougeObject;
        textValues = texts;

        OpenSetting();
    }

    public void ShowSystemText(params string[] texts){
        selectTextUI = systemTextObject;
        textValues = texts;

        OpenSetting();
    }

    private void OpenSetting(){
        selectTextUI.gameObject.SetActive(true);
        selectTextUI.ShowTexts(textValues[index++]);
        isOpen = true;
    }


    public void NextText(){
        if(!isOpen)
            return;


        if(index.Equals(textValues.Length)){
            CloseUIText();
            return ;
        }

        selectTextUI.ShowTexts(textValues[index++]);


    }

    private void CloseUIText(){
        selectTextUI.gameObject.SetActive(false);
        isOpen = false;
        index = 0;
        endEvent();
    }
}
