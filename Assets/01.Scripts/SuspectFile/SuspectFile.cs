#pragma warning disable CS0649
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SuspectFile : MonoBehaviour
{
    [Header("Suspects")]
    [SerializeField]
    private RectTransform selectEffect;
    [SerializeField]
    private Suspect[] suspects = new Suspect[4];
    [SerializeField]
    private RectTransform[] suspectsUI = new RectTransform[4];

    [Header("Clue Matching")]
    [SerializeField]
    private ClueMatching clueMatching;
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
        selectEffect.anchoredPosition = suspectsUI[index].anchoredPosition;
        clueCards[selectedSuspectIndex].gameObject.SetActive(false);
        clueCards[index].gameObject.SetActive(true);
        selectedSuspectIndex = index;
    }

    public void AddClueCard(string clue, int suspectIndex)
    {
        var clueCard = Instantiate(clueCardPrefab, clueCards[suspectIndex]);
        var position = new Vector2(Random.Range(-160F, 160F), Random.Range(-100F, 100F));
        System.Action<string> match = placeName => clueMatching.Match(suspectIndex, placeName, clue, suspects[suspectIndex]);
        System.Action<string> cancelMatch = placeName => clueMatching.CancelMatch(suspectIndex, placeName, clue);
        clueCard.Initialize(clue, position, match, cancelMatch);
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
        AddClueCard("어디서", 0);
        AddClueCard("무엇을", 0);
        AddClueCard("어떻게", 0);
        AddClueCard("왜", 0);
    }
}
