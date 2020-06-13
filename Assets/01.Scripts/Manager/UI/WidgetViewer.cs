using System.Net.Cache;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WidgetViewer : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private TextViewUI monolougeObject = null;
    
    [SerializeField]
    private TextViewUI systemTextObject = null;

    [SerializeField]
    private TextViewUI invenstigateObject = null;

    [SerializeField]
    private TextViewUI npcDialogObject = null;

    [SerializeField]
    private Image eventImage = null;

    private TextViewUI selectTextUI = null;
    private string[] textValues;
    private int index = 0;

    public Action endEvent {get; set;}
    public Action nextEvent {get; set;} 
    private object a;

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

    public void ShowEventImage(Sprite sprite){
        isOpen = true;
        eventImage.sprite = sprite;
        eventImage.gameObject.SetActive(true);
        nextEvent = () => {eventImage.gameObject.SetActive(false);};
        textValues = null;
    }

    public void ShowNPCDialog(string[] texts, int[] index, params GameObject[] targetObjects){
        selectTextUI = npcDialogObject;
        textValues = texts;

        Func<GameObject, Vector3> setDialog = (GameObject obj) => {
            Vector3 position = obj.transform.position;
            
            if(obj.Equals(targetObjects[targetObjects.Length - 1])){
                position.y += 5;
            } else{
                position.y += 3;
            }
            position.x += 2;
            return position;
        };

        nextEvent = () => {
            if(this.index >= index.Length){
                return;
            }

            if(index[this.index].Equals(-1)){
                selectTextUI.gameObject.transform.position = 
                setDialog(targetObjects[targetObjects.Length - 1]);
            } else{
                selectTextUI.gameObject.transform.position = 
                setDialog(targetObjects[index[this.index]]);
            }
        };

        nextEvent();
        OpenSetting();
    }

    private void OpenSetting(){
        selectTextUI.gameObject.SetActive(true);
        selectTextUI.ShowTexts(textValues[index]);
        isOpen = true;
    }


    public void NextText(){
        if(!isOpen)
            return;
            
        index++;

        if(nextEvent != null){
            nextEvent();
        }

        if(textValues is null || index == textValues.Length){
            CloseUIText();
            return ;
        }

        selectTextUI?.ShowTexts(textValues[index]);

    }

    private void CloseUIText(){
        selectTextUI?.gameObject.SetActive(false);
        isOpen = false;
        index = 0;
        endEvent();
        nextEvent = null;
    }
}
