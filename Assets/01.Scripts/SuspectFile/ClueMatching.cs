using UnityEngine;

public class ClueMatching : MonoBehaviour
{
    [SerializeField]
    private Suspect[] suspects = new Suspect[4];
    [SerializeField]
    private IntEvent matched;
    private Clue[] clues = new Clue[4];

    public void Match(int suspectIndex, string type, string clue)
    {
        switch (type)
        {
            case "Where":
                clues[suspectIndex].where = clue;
                break;
            case "What":
                clues[suspectIndex].what = clue;
                break;
            case "How":
                clues[suspectIndex].how = clue;
                break;
            case "Why":
                clues[suspectIndex].why = clue;
                break;
        }

        var isMatching = suspects[suspectIndex].Where == clues[suspectIndex].where &&
            suspects[suspectIndex].What == clues[suspectIndex].what &&
            suspects[suspectIndex].How == clues[suspectIndex].how &&
            suspects[suspectIndex].Why == clues[suspectIndex].why;

        if (isMatching)
        {
            Debug.Log($"Matched {suspectIndex}th Suspect");
            matched?.Invoke(suspectIndex);
        }
    }

    private struct Clue
    {
        public string where;
        public string what;
        public string how;
        public string why;
    }
}
