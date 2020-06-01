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

    [SerializeField]
    private TextViewUI npcDialogObject;

    private TextViewUI selectTextUI;
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

    public void ShowNPCDialog(string[] texts, int[] index, params GameObject[] targetObjects){
        selectTextUI = npcDialogObject;
        textValues = texts;

        Func<GameObject, Vector3> setDialog = (GameObject obj) => {
            Vector3 position = obj.transform.position;
            
            if(obj.Equals(targetObjects[targetObjects.Length - 1])){
                position.y += 6;
            } else{
                position.y += 3;
            }
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
                setDialog(targetObjects[this.index]);
            }
        };

        nextEvent();
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

        if(nextEvent != null){
            nextEvent();
        }

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
