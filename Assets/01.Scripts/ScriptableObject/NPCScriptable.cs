using UnityEngine;
using System;

[Serializable]
public class NPCDialog{
    public string dialog;
    public int targetIndex;
}


[CreateAssetMenu(fileName = "NPCScriptable", menuName = "NPCScriptable", order = 0)]
public class NPCScriptable : ScriptableObject {
    [SerializeField]
    private NPCDialog[] dialogs = null;

    public NPCDialog[] Dialogs => dialogs;
}