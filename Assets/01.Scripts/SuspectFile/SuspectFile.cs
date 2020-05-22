using UnityEngine;
using UnityEngine.UI;

public class SuspectFile : MonoBehaviour
{
    [SerializeField]
    private Suspect[] suspects;
    [SerializeField]
    private RectTransform[] suspectsUI;

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
    }
}
