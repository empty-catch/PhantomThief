using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC Object")]
    [SerializeField]
    private List<GameObject> npcObjects = new List<GameObject>();

    [Header("Information")]
    [SerializeField]
    private NPCScriptable information;

    private string[] dialogs;
    private int[] index;

    private void Start(){

        dialogs = new string[information.Dialogs.Length];
        index = new int[information.Dialogs.Length];
        
        for(int i = 0; i < information.Dialogs.Length; i++){
            dialogs[i] = information.Dialogs[i].dialog;
            index[i] = information.Dialogs[i].targetIndex;
        }

        npcObjects.Add(InGameManager.instance.PlayerObject.gameObject);
    }

    public void ShowConversation(){
        InGameManager.instance.PlayerObject.IsInteraction = true;
        
        InGameManager.instance.widgetViewer.endEvent = () => {
            InGameManager.instance.PlayerObject.IsInteraction = false;
        };

        InGameManager.instance.widgetViewer.ShowNPCDialog(dialogs, index, npcObjects.ToArray());
    }  
}
