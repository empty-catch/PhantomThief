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

    public void SelectSuspect(int index)
    {
        foreach (var clueCard in clueCards)
        {
            clueCard.gameObject.SetActive(false);
        }

        matchingSuspect.text = $"{suspects[index].Name}의 단서";
        selectEffect.anchoredPosition = suspectsUI[index].anchoredPosition;
        clueCards[index].gameObject.SetActive(true);
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

        AddClueCard("생가", 1);
        AddClueCard("유령의 몸", 1);
        AddClueCard("조사", 1);
        AddClueCard("승천 불가", 1);
        SelectSuspect(1);
    }
}
