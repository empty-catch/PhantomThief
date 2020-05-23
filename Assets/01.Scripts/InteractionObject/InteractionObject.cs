using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    [SerializeField]
    private InteractionScriptable information;

    private string[] monolougeTexts;
    private string[] systemTexts;

    private void Awake() {
        monolougeTexts = information.monolougeStrings;
        systemTexts = information.systemStrings;
    }

    public void Interaction() {
        StartCoroutine(InteractionCoroutine());
    }

    private IEnumerator InteractionCoroutine(){
        if(monolougeTexts.Length > 0){
            yield return new WaitForTextEnd(0, monolougeTexts);
        }
        
        if(systemTexts.Length > 0){
            yield return new WaitForTextEnd(1, systemTexts);
        }
    }
}
