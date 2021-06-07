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
    public RectTransform DragRect;
    private bool isDrag = false;

    private Vector2 Startpos = new Vector2(0,0);
    private Vector2 Endpos = new Vector2(0, 0);

    //by jin for Drag Rect 2021.05.22
    //by jin cache Items(rect, canvas... etc)
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DragRect.sizeDelta = new Vector2(1, 1);
    }

    private void Start()
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

    //by jin for Select mode Input ->To-be : Touch(on Android, IOS) 2021.05.22
    void SelectMode()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDrag = true;
            Startpos = Input.mousePosition;
            DragRect.gameObject.SetActive(true);
            DragRect.position = Input.mousePosition;
            UnityEngine.Debug.Log("Mouse down  " + isDrag);
        }
        else if(Input.GetMouseButton(0))
        {
            if(isDrag)
            {
                Endpos = Input.mousePosition;
                //DragRect.sizeDelta = new Vector2(Mathf.Abs(Endpos.x - Startpos.x), Mathf.Abs(Endpos.y - Startpos.y));
                //DragRect.sizeDelta = new Vector2(Endpos.x - Startpos.x, Endpos.y - Startpos.y);
                DragRect.localScale = new Vector3(Endpos.x - Startpos.x, -(Endpos.y - Startpos.y), 1);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            DragRect.localScale = new Vector3(1, 1, 0);
            DragRect.gameObject.SetActive(false);
            UnityEngine.Debug.Log("Mouse Up  "+ isDrag);
        }
    }


    //by jin for when into input edit mode public? private?
    private void InitializeInput()
    {
        
    }
}
