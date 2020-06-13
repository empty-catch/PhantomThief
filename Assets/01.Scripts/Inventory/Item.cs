#pragma warning disable CS0649
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler
{
    public event Action Select;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Image selection;
    [SerializeField]
    private Sprite active;
    [SerializeField]
    private Sprite inactive;

    public string Name { get; private set; }

    public static Item NewItem(Item prefab, RectTransform slot, Action<int> selectItem, int index, string name)
    {
        var item = Instantiate(prefab, slot);
        item.Select += () => selectItem?.Invoke(index);
        item.Name = name;
        return item;
    }

    public void SetActive(bool value)
    {
        image.sprite = value ? active : inactive;
        selection.color = new Color(1F, 1F, 1F, value ? 1F : 0F);
    }

    public void OnPointerDown(PointerEventData _)
    {
        Select?.Invoke();
    }
}
