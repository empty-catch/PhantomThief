using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;

    [HideInInspector]
    public WidgetViewer widgetViewer;

    private void Awake(){
        if(instance is null)
            instance = this;

            widgetViewer = gameObject.GetComponent<WidgetViewer>();
    }
}
