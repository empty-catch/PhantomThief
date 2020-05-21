using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]
    private float defaultSpeed;
    private float speed;

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

            if(Input.GetKeyDown(KeyCode.W)){
                Apply();
            }

            if(Input.GetKeyDown(KeyCode.E)){
                Cancel();
            }
        }
    }
    
    private void Move(Vector2 direction){
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Interaction() { }
    private void Apply() { }
    private void Cancel() { }
}
