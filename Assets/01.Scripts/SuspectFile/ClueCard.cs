#pragma warning disable CS0649
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClueCard : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private string clue;
    private RectTransform rectTransform;
    private Vector2 position;
    private Vector2 difference;
    private IEnumerator followCursor;
    private Tweener tweener;

    public void Initialize(string clue, Vector2 position)
    {
        this.clue = clue;
        this.position = position;

        text.text = clue;
        ResizeImage();
        rectTransform.anchoredPosition = position;
    }

    public void Select()
    {
        tweener?.Kill();
        difference = transform.position - Input.mousePosition;
        followCursor.Start(this);
    }

    public void Deselect()
    {
        followCursor.Stop(this);
        tweener = rectTransform.DOAnchorPos(position, 0.2F);
    }

    private void Awake()
    {
        followCursor = FollowCursor();
        rectTransform = transform as RectTransform;
    }

    private void ResizeImage()
    {
        rectTransform.sizeDelta = new Vector2(text.preferredWidth + 20F, text.preferredHeight + 20F);
    }

    private IEnumerator FollowCursor()
    {
        while (true)
        {
            transform.position = (Vector2)Input.mousePosition + difference;
            yield return null;
        }
    }
}
