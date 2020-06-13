using UnityEngine;
using UnityEngine.EventSystems;

public class ClueCardPlace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool IsMouseOver { get; private set; }
    public static string Name { get; private set; }
    public static Vector2? Position { get; private set; }

    public void OnPointerEnter(PointerEventData pointer)
    {
        IsMouseOver = true;
        Name = pointer.pointerEnter.name;
        Position = (pointer.pointerEnter.transform as RectTransform).anchoredPosition;
    }

    public void OnPointerExit(PointerEventData _)
    {
        IsMouseOver = false;
        Name = null;
        Position = null;
    }
}
