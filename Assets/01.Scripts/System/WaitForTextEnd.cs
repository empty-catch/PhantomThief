using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTextEnd : CustomYieldInstruction
{
    private bool isEnd = true;
    public override bool keepWaiting{
        get {
            return isEnd;
        }
    }

    ///<summary>
    /// index 0 : monolouge
    //
    /// index 1 : monolouge
    ///
    /// index 2 : system text 
    ///</summary>
    public WaitForTextEnd(int index, params string[] textValues){
        InGameManager.instance.widgetViewer.endEvent = () => {isEnd = false;};
        if(index.Equals(0)){
            InGameManager.instance.widgetViewer.ShowInvenstigate(textValues);
        }
        else if(index.Equals(1)){
            InGameManager.instance.widgetViewer.ShowMonologue(textValues);
        }
        else if(index.Equals(2)){
            InGameManager.instance.widgetViewer.ShowSystemText(textValues);
        }
    }

    public WaitForTextEnd(Sprite sprite){
        InGameManager.instance.widgetViewer.endEvent = () => {isEnd = false;};
        InGameManager.instance.widgetViewer.ShowEventImage(sprite);
    }
}
