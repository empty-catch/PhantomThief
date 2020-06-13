#pragma warning disable CS0649
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item itemPrefab;
    [SerializeField]
    private RectTransform itemSlot;
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private GameObject explanation;

    private Item[] items = new Item[20];
    private int itemCount;

    public void AddItem(string name)
    {
        if (itemCount >= 20)
        {
            return;
        }

        explanation.SetActive(true);
        var item = Item.NewItem(itemPrefab, itemSlot, SelectItem, itemCount, name);
        items[itemCount] = item;
        itemCount++;

        SelectItem(itemCount - 1);
    }

    private void SelectItem(int index)
    {
        for (int i = 0; i < itemCount; i++)
        {
            items[i].SetActive(i == index);
            if (i == index)
            {
                itemName.text = items[i].Name;
            }
        }
    }
}
