﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Spine.Unity;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]
    private float defaultSpeed = 0;
    private float speed;

    [Header("Events")]
    [SerializeField]
    private VoidEvent applyEvent = null;

    private string currentAnimationName = "";

    private bool isInteraction = false;
    public bool IsInteraction {
        get{return isInteraction;} 
        set{isInteraction = value;}
    }

    private Ray mouseRay;
    private SkeletonAnimation animationBone;

    private void Awake(){
        speed = defaultSpeed;
        animationBone = gameObject.GetComponent<SkeletonAnimation>();
    }

    private void Update(){
        MoveProcess();
        InteractionProcess();
    }

    private void MoveProcess(){
        if(isInteraction)
            return;

        switch(Input.anyKey){
            case var k when Input.GetKey(KeyCode.A):
            Move(Vector2.left);
            SetDirection(Vector2.left);
            SetAnimation("walk");
            break;

            case var k when Input.GetKey(KeyCode.D):
            Move(Vector2.right);
            SetDirection(Vector2.right);
            SetAnimation("walk");
            break;

            default:
            SetAnimation("idle");
            break;
        }
    }

    private void InteractionProcess(){
        switch(Input.anyKeyDown){
            case var k when Input.GetKeyDown(KeyCode.E):
            Apply();
            break;

            case var k when Input.GetKeyDown(KeyCode.W):
            Cancel();
            break;

            case var k when Input.GetMouseButtonDown(0):
            Interaction();
            break;
        }
    }
    
    private void SetDirection(Vector2 direction){
        direction.x *= -1;
        direction.y = 1;
        gameObject.transform.localScale = direction;
    }
    
    private void Move(Vector2 direction){
        Vector2 position = (Vector2)gameObject.transform.position + direction * speed * Time.deltaTime;

        if(Mathf.Abs(position.x) > 12.3f){
            gameObject.transform.position = new Vector2(12.3f, 0) * direction;
        } else{
            gameObject.transform.position = position;
        }
    }

    private void Interaction(){                
        if(isInteraction)
            return;

        InteractionObject targetObject = GetAvailableInteractionObject();
        targetObject?.Interaction(() => {isInteraction = false;});
    }

    private InteractionObject GetAvailableInteractionObject() { 
        mouseRay.direction = Vector3.forward;
        mouseRay.origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit;

        hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, Mathf.Infinity, LayerMask.GetMask("InteractionObject"));

        if(hit.collider != null){
            isInteraction = true;
            return hit.collider.gameObject.GetComponent<InteractionObject>();
        }

        return null;
    }

    private void Apply() { 
        applyEvent.Invoke();
    }
    private void Cancel() { }

    public void SetAnimation(string animationName){
        if(animationName.Equals(currentAnimationName)){
            return;
        }

        animationBone.state.SetAnimation(0, animationName, true);
        currentAnimationName = animationName;
    }
}
