using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private void OnMouseDown()
    {
        UnityEngine.Debug.Log("click");
    }

    private void OnMouseDrag()
    {
        UnityEngine.Debug.Log("Drag");
    }
}
