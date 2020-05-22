#pragma warning disable CS0649
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuspectFile : MonoBehaviour
{
    [Header("Suspects")]
    [SerializeField]
    private Image selectEffect;
    [SerializeField]
    private Suspect[] suspects = new Suspect[4];
    [SerializeField]
    private RectTransform[] suspectsUI = new RectTransform[4];

    [Header("Clue Matching")]
    [SerializeField]
    private Text matchingSuspect;
    [SerializeField]
    private ClueCard clueCardPrefab;
    [SerializeField]
    private RectTransform[] clueCards = new RectTransform[4];
    [SerializeField]
    private RectTransform[] clueCardPlaces;

    private int selectedSuspectIndex = 0;

    public void SelectSuspect(int index)
    {
        selectEffect.rectTransform.pivot = suspectsUI[index].pivot;
        selectEffect.rectTransform.anchorMin = suspectsUI[index].anchorMin;
        selectEffect.rectTransform.anchorMax = suspectsUI[index].anchorMax;
        selectEffect.rectTransform.anchoredPosition = suspectsUI[index].anchoredPosition;

        clueCards[selectedSuspectIndex].gameObject.SetActive(false);
        clueCards[index].gameObject.SetActive(true);
        selectedSuspectIndex = index;
    }

    public void AddClueCard(string clue, int suspectIndex)
    {
        var clueCard = Instantiate(clueCardPrefab, clueCards[suspectIndex]);
        clueCard.Initialize(clue, clueCards[suspectIndex].anchoredPosition);
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

        SelectSuspect(selectedSuspectIndex);
        AddClueCard("상설전시관", 0);
        AddClueCard("주인공을", 0);
        AddClueCard("그냥", 0);
        AddClueCard("밀었다", 0);
    }
}
