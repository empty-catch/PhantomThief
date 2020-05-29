using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]
    private float defaultSpeed;
    private float speed;

    [Header("Events")]
    [SerializeField]
    private VoidEvent applyEvent;

    private Ray mouseRay;

    private void Awake(){
        speed = defaultSpeed;
    }

    private void Update(){

        if(Input.anyKey){
            if(Input.GetKey(KeyCode.A)){
                Move(Vector2.left);
            }

            if(Input.GetKey(KeyCode.D)){
                Move(Vector2.right);
            }

            if(Input.GetKeyDown(KeyCode.E)){
                Apply();
            }

            if(Input.GetKeyDown(KeyCode.W)){
                Cancel();
            }

            if(Input.GetMouseButtonDown(0)){
                Interaction();
            }
        }
    }
    
    private void Move(Vector2 direction){
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Interaction(){
        InteractionObject targetObject = GetAvailableInteractionObject();
        targetObject?.Interaction();
    }

    private InteractionObject GetAvailableInteractionObject() { 
        mouseRay.direction = Vector3.forward;
        mouseRay.origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, LayerMask.GetMask("InteractionObject"))){
            return hit.collider.gameObject.GetComponent<InteractionObject>();
        }

        return null;
    }

    private void Apply() { 
        applyEvent.Invoke();
    }
    private void Cancel() { }
}
