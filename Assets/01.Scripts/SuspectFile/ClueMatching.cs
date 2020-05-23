#pragma warning disable CS0649
using System.Collections.Generic;
using UnityEngine;

public class ClueMatching : MonoBehaviour
{
    [SerializeField]
    private IntEvent matched;
    private Clue[] clues = new Clue[4] { new Clue(), new Clue(), new Clue(), new Clue() };

    public void Match(int suspectIndex, string placeName, string clue, Suspect suspect)
    {
        switch (placeName)
        {
            case "Where":
                clues[suspectIndex].Where.Add(clue);
                break;
            case "What":
                clues[suspectIndex].What.Add(clue);
                break;
            case "How":
                clues[suspectIndex].How.Add(clue);
                break;
            case "Why":
                clues[suspectIndex].Why.Add(clue);
                break;
        }

        if (clues[suspectIndex].IsMatching(suspect))
        {
            Debug.Log($"Matched {suspectIndex}th Suspect");
            matched?.Invoke(suspectIndex);
        }
    }

    public void CancelMatch(int suspectIndex, string placeName, string clue)
    {
        switch (placeName)
        {
            case "Where":
                clues[suspectIndex].Where.Remove(clue);
                break;
            case "What":
                clues[suspectIndex].What.Remove(clue);
                break;
            case "How":
                clues[suspectIndex].How.Remove(clue);
                break;
            case "Why":
                clues[suspectIndex].Why.Remove(clue);
                break;
        }
    }

    private class Clue
    {
        public HashSet<string> Where { get; } = new HashSet<string>();
        public HashSet<string> What { get; } = new HashSet<string>();
        public HashSet<string> How { get; } = new HashSet<string>();
        public HashSet<string> Why { get; } = new HashSet<string>();

        public bool IsMatching(Suspect suspect)
        {
            var hasOne = Where.Count == 1 && What.Count == 1 && How.Count == 1 && Why.Count == 1;
            return hasOne && Where.Contains(suspect.Where) && What.Contains(suspect.What) && How.Contains(suspect.How) && Why.Contains(suspect.Why);
        }
    }
}
