using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//by jin for Manage Mouse Input Mode 2021.05.22
enum InputStatus
{
    Select
}

public class MouseModeManager : MonoBehaviour
{
    public static MouseModeManager Instance;
    private InputStatus mode;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
    }

    void Start()
    {
        mode = InputStatus.Select;
    }


    void Update()
    {
        switch(mode)
        {
            case InputStatus.Select:
                SelectMode();
                break;
        }
    }


    void SelectMode()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("Down on");
        }
    }

    //by jin for when into input edit mode
    private void InitializeInput()
    {
        
    }
}
