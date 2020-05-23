using UnityEngine;
using UnityEngine.EventSystems;

public class ClueCardPlace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool IsMouseOver { get; private set; }
    public static string Type { get; private set; }

    public void OnPointerEnter(PointerEventData pointer)
    {
        IsMouseOver = true;
        Type = pointer.pointerEnter.name;
    }

    public void OnPointerExit(PointerEventData _)
    {
        IsMouseOver = false;
        Type = string.Empty;
    }
}
