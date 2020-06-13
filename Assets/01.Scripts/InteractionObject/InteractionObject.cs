using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionObject : MonoBehaviour
{

    [SerializeField]
    private InteractionScriptable information = null;

    [SerializeField]
    private StringEvent itemEvent = null;

    private Action endAction;

    private string[] monolougeTexts;
    private string[] systemTexts;
    private string[] invenstigateTexts;

    private string item = null;

    private Sprite eventSprite;
    
    private void Awake() {
        eventSprite = information.eventSprite;
        item = information.item;
        monolougeTexts = information.monolougeStrings;
        systemTexts = information.systemStrings;
        invenstigateTexts = information.invenstigateStrings;    
    }

    public void Interaction() {
        StartCoroutine(InteractionCoroutine());
    }
    
    public void Interaction(Action endAction) {
        StartCoroutine(InteractionCoroutine());
        this.endAction = endAction;
    }

    private IEnumerator InteractionCoroutine(){
        if(eventSprite != null){
            yield return new WaitForTextEnd(eventSprite);
        }

        if(invenstigateTexts.Length > 0){
            yield return new WaitForTextEnd(0, invenstigateTexts);
        }

        if(monolougeTexts.Length > 0){
            yield return new WaitForTextEnd(1, monolougeTexts);
        }
        
        if(systemTexts.Length > 0){
            yield return new WaitForTextEnd(2, systemTexts);
        }
        
        if(endAction != null)
            endAction();

        if(item != null){
            itemEvent?.Invoke(item);
        }
    }
}
