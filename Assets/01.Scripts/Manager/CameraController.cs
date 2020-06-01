using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;

    private Vector3 locationMove;

    private void Start(){
        locationMove.y = targetObject.position.y + 4;
        locationMove.z = -150;
    }

    private void Update(){
        locationMove.x = targetObject.position.x;
        gameObject.transform.position = locationMove;
    }
}
