using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SuspectFile : MonoBehaviour
{
    [Header("Suspects")]
    [SerializeField]
    private Suspect[] suspects = new Suspect[4];
    [SerializeField]
    private RectTransform[] suspectsUI = new RectTransform[4];
    [SerializeField]
    private Image selectEffect;

    private List<ClueCard>[] clueCardLists = new List<ClueCard>[4];
    private int selectedSuspectIndex;

    public void SelectSuspect(int index)
    {
        selectedSuspectIndex = index;
        selectEffect.rectTransform.pivot = suspectsUI[index].pivot;
        selectEffect.rectTransform.anchorMin = suspectsUI[index].anchorMin;
        selectEffect.rectTransform.anchorMax = suspectsUI[index].anchorMax;
        selectEffect.rectTransform.anchoredPosition = suspectsUI[index].anchoredPosition;
    }

    private void Awake()
    {
        for (int i = 0; i < suspectsUI.Length; i++)
        {
            var picture = suspectsUI[i].GetChild(0).GetComponent<Image>();
            var name = suspectsUI[i].GetChild(1).GetComponent<Text>();
            var description = suspectsUI[i].GetChild(2).GetComponent<Text>();

            picture.sprite = suspects[i].Picture;
            name.text = suspects[i].Name;
            description.text = suspects[i].Description;
        }

        for (int i = 0; i < clueCardLists.Length; i++)
        {
            clueCardLists[i] = new List<ClueCard>();
        }

        SelectSuspect(selectedSuspectIndex);
    }
}
