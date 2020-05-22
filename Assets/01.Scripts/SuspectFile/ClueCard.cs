using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ClueCard : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Awake()
    {
        (transform as RectTransform).sizeDelta = new Vector2(text.preferredWidth + 20F, text.preferredHeight + 20F);
    }
}
