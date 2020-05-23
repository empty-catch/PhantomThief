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

    private int suspectIndex;
    private string clue;
    private Tweener tweener;
    private Action<int, string, string> match;

    private Vector2 position;
    private Vector2 difference;
    private IEnumerator followCursor;

    public void Initialize(int suspectIndex, string clue, Vector2 position, Action<int, string, string> match)
    {
        this.suspectIndex = suspectIndex;
        this.clue = clue;
        this.position = position;
        this.match = match;

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
            match?.Invoke(suspectIndex, ClueCardPlace.Type, clue);
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
