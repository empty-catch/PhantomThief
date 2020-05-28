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
