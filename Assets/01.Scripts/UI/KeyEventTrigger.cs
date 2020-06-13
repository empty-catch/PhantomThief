using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEventTrigger : MonoBehaviour
{
    [SerializeField]
    private List<Entry> keyDownTriggers = new List<Entry>();
    [SerializeField]
    private List<Entry> keyHoldTriggers = new List<Entry>();
    [SerializeField]
    private List<Entry> keyUpTriggers = new List<Entry>();

    public void AddNew()
    {
        keyDownTriggers.Add(new Entry());
    }

    private void Update()
    {
        foreach (var trigger in keyDownTriggers)
        {
            if (Input.GetKeyDown(trigger.keyCode))
            {
                trigger.callback?.Invoke();
            }
        }

        foreach (var trigger in keyHoldTriggers)
        {
            if (Input.GetKey(trigger.keyCode))
            {
                trigger.callback?.Invoke();
            }
        }

        foreach (var trigger in keyUpTriggers)
        {
            if (Input.GetKeyUp(trigger.keyCode))
            {
                trigger.callback?.Invoke();
            }
        }
    }

    [Serializable]
    public class Entry
    {
        public KeyCode keyCode;
        public UnityEvent callback;
    }
}
