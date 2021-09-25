using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ClickableCollider : MonoBehaviour
{
    public UnityEvent downAction;

    public UnityEvent upAction;

    public UnityEvent dragAction;

    
    
    // Update is called once per frame
    void OnMouseDown()
    {
        downAction.Invoke();
    }

    void OnMouseUp()
    {
        upAction.Invoke();
    }

    private void OnMouseDrag()
    {
        dragAction.Invoke();
    }
}
