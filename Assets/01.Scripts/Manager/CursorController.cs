using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [Header("Cursor Texture")]
    [SerializeField]
    private Texture2D[] cursorSprites = null;
    private Ray mouseRay;
    
    private void Awake(){
        mouseRay.direction = Vector2.zero;
    }

    private void Update(){
        // interactive state
        if(GetCurrentMouseState()){
            Cursor.SetCursor(cursorSprites[0], Vector2.zero, CursorMode.Auto);
        } else {
            Cursor.SetCursor(cursorSprites[1], Vector2.zero, CursorMode.Auto);
        }
    }

    private bool GetCurrentMouseState(){
        mouseRay.origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, Mathf.Infinity, LayerMask.GetMask("InteractionObject"));

        return hit.collider != null;
    }
}
