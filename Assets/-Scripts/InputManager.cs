using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EditMode
{
    None,
    Select,
    Rotate,
    Scale,
    TopSIde,
    Defalut
}

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public bool isDragging = false;
    public bool isRDragging = false;

    //X
    public GameObject PlaneHolder;
    //Y
    public GameObject PlanePanel;
    private float bias = 0.05f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotationX;
    private Vector3 _rotationY;

    private EditMode _eMode = EditMode.None;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        _eMode = EditMode.None;
    }

    private void InitializePlanePosition()
    {
        PlanePanel.transform.localRotation = Quaternion.Euler(90, 45, 0);
    }

    private void Update()
    {
        switch (_eMode)
        {
            case EditMode.Scale:
                break;
            case EditMode.Select:
                CheckDragging();
                break;
            case EditMode.Rotate:
                CheckRotate();
                break;

        }
    }

    
    private void CheckDragging()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
#endif
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

    }

    private void CheckRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRDragging = true;
            _mouseReference = Input.mousePosition;
        }
        else if(Input.GetMouseButton(1) && isRDragging)
        {

            UnityEngine.Debug.Log("Rotate" + PlaneHolder.transform.localRotation.x);
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotationX.y = -(_mouseOffset.x) * bias;
            _rotationY.x = -(_mouseOffset.y) * bias;

            PlanePanel.transform.localEulerAngles += _rotationX;
            _mouseReference = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRDragging = false;
        }
    }

    public void OnclickSelect()
    {
        isRDragging = false;
        _eMode = EditMode.Select;
    }

    public void OnclickRotate()
    {
        isDragging = false;
        _eMode = EditMode.Rotate;
    }

    private bool isTop = false;
    public void OnclickTopSideView()
    {
        if (!isTop)
        {
            _eMode = EditMode.TopSIde;
            PlanePanel.transform.localRotation = Quaternion.Euler(0, 0, 0);
            isTop = true;
        }
        else
        {
            PlanePanel.transform.localRotation = Quaternion.Euler(90, 45, 0);
            isTop = false;
        }
    }

    public void OnclickDefalut()
    {

    }
}
