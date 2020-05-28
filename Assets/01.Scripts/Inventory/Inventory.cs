#pragma warning disable CS0649
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item itemPrefab;
    [SerializeField]
    private RectTransform itemSlot;

    private Item[] items = new Item[20];
    private int itemCount;

    public void AddItem()
    {
        if (itemCount >= 20)
        {
            return;
        }

        var item = Instantiate(itemPrefab, itemSlot);
        int index = itemCount;
        item.Select += () => SelectItem(index);
        items[itemCount] = item;
        itemCount++;
    }

    private void SelectItem(int index)
    {
        for (int i = 0; i < itemCount; i++)
        {
            items[i].SetActive(i == index);
        }
    }

    private void Awake()
    {
        AddItem();
        AddItem();
        SelectItem(0);
    }
}
