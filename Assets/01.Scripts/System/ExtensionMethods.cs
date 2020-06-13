using System.Linq;
using System.Collections;
using UnityEngine;
using System;
public static class ExtensionMethods
{
    public static IEnumerator Start(this IEnumerator coroutine, MonoBehaviour behaviour)
    {
        behaviour.StartCoroutine(coroutine);
        return coroutine;
    }

    public static void Stop(this IEnumerator coroutine, MonoBehaviour behaviour)
    {
        behaviour.StopCoroutine(coroutine);
    }

    public static string LineBreak(this string value){
        string insert(string a, int index){
            return a.Insert(index, "\n");
        }
        
        for(int i = 0; i < value.Length; i++){
            if(i % 15 == 0 && i != 0){
                value = insert(value, i);
            }
        }

        return value;

    }
}
