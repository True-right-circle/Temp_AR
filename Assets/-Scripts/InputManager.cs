using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public bool isDragging = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        CheckDragging();
    }

    
    private void CheckDragging()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
