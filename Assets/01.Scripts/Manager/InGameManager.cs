using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    [HideInInspector]
    public WidgetViewer widgetViewer;

    [Header("Player Object")]
    [SerializeField]
    private PlayerCharacterController playerCharacter = null;

    public PlayerCharacterController PlayerObject => playerCharacter;

    private void Awake(){
        if(instance is null)
            instance = this;

            widgetViewer = gameObject.GetComponent<WidgetViewer>();
    }
}
