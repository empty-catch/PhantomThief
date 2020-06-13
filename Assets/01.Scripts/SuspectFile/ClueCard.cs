#pragma warning disable CS0649
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class ClueCard : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private Image image;
    private RectTransform rectTransform;

    private string clue;
    private string placeName;
    private Action<string> match;
    private Action<string> cancelMatch;

    private Vector2 position;
    private Vector2 difference;
    private IEnumerator followCursor;
    private Tweener tweener;

    public void Initialize(string clue, Vector2 position, Action<string> match, Action<string> cancelMatch)
    {
        this.clue = clue;
        this.position = position;
        this.match = match;
        this.cancelMatch = cancelMatch;

        text.text = clue;
        ResizeImage();
        rectTransform.anchoredPosition = position;
    }

    public void Select()
    {
        image.raycastTarget = false;
        difference = transform.position - Input.mousePosition;
        followCursor.Start(this);
    }

    public void Deselect()
    {
        followCursor.Stop(this);
        tweener?.Kill();

        if (ClueCardPlace.IsMouseOver)
        {
            position = rectTransform.anchoredPosition;
            cancelMatch?.Invoke(placeName);
            match?.Invoke(ClueCardPlace.Name);
            placeName = ClueCardPlace.Name;

            if (placeName != "Clue Card Place")
            {
                transform.DOMove(ClueCardPlace.Position.Value, 0.1F);
            }
        }
        else
        {
            tweener = rectTransform.DOAnchorPos(position, 0.2F);
        }

        image.raycastTarget = true;
    }

    private void Awake()
    {
        followCursor = FollowCursor();
        rectTransform = transform as RectTransform;
        image = GetComponent<Image>();
    }

    private void ResizeImage()
    {
        rectTransform.sizeDelta = new Vector2(text.preferredWidth + 68F, text.preferredHeight + 34F);
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
