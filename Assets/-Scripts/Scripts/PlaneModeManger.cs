using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ViewState
{
    Top,
    Front
}

public class PlaneModeManger : MonoBehaviour
{
    public Camera MainCam;
    public GameObject PlaneCanvas;

    private Vector3 MainDefaultpos = new Vector3(0, 0, -35);

    private Quaternion Top = new Quaternion();
    private Quaternion Front = new Quaternion();


    private Vector3 PlaneFront = new Vector3();
    private Vector3 PlaneTop = new Vector3();


    private Coroutine RotateCor = null;
    private bool isTop = false;
    private ViewState _state;

    private float spinSpeed = 500f;

    

    private void Awake()
    {
        _state = ViewState.Front;

        //Canvas
        Top = Quaternion.Euler(0, 0, 0);
        Front = Quaternion.Euler(90, 45, 0);

        PlaneFront = new Vector3(0, -3.5f, 10);
        PlaneTop = new Vector3(0, 0, 10);
    }

    private void Update()
    {
        if (_state.Equals(ViewState.Front))
        {
            InputKeyFront();
        }
        else if (_state.Equals(ViewState.Top))
        {
            InputKeyTop();
        }
    }

    public void OnClickRotatePlane()
    {
        startRotateCor();
    }

    private void startRotateCor()
    {
        if (RotateCor != null)
            RotateCor = null;

        RotateCor = StartCoroutine(RotateCorutine());
    }

    IEnumerator RotateCorutine()
    {
        if (isTop)
        {
            _state = ViewState.Front;
            MainCam.orthographic = false;
            float angle = Quaternion.Angle(PlaneCanvas.transform.localRotation, Front);
            while (angle > 0)
            {
                PlaneCanvas.transform.localRotation = Quaternion.RotateTowards(PlaneCanvas.transform.localRotation, Front, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(PlaneCanvas.transform.localRotation, Front);
                yield return null;
            }
            while (!(PlaneCanvas.transform.localPosition == PlaneFront))
            {
                PlaneCanvas.transform.localPosition = Vector3.Lerp(PlaneCanvas.transform.localPosition, PlaneFront, Time.deltaTime * 50);
                yield return null;
            }
           // while (!(MainCam.transform.localPosition == MainDefaultpos))
           // {
           //     MainCam.transform.localPosition = Vector3.Lerp(MainCam.transform.localPosition, MainDefaultpos, Time.deltaTime * 50);
           //     yield return null;
           // }
            isTop = false;
        }
        else
        {
            MainCam.orthographic = true;
            MainCam.orthographicSize = 27;
            _state = ViewState.Top;
            float angle = Quaternion.Angle(PlaneCanvas.transform.localRotation, Top);
            while (angle > 0)
            {
                PlaneCanvas.transform.localRotation = Quaternion.RotateTowards(PlaneCanvas.transform.localRotation, Top, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(PlaneCanvas.transform.localRotation, Top);
                yield return null;
            }
            while (!(PlaneCanvas.transform.localPosition == PlaneTop))
            {
                PlaneCanvas.transform.localPosition = Vector3.Lerp(PlaneCanvas.transform.localPosition, PlaneTop, Time.deltaTime * 50);
                yield return null;
            }
            //while (!(MainCam.transform.localPosition == MainDefaultpos))
            //{
            //    MainCam.transform.localPosition = Vector3.Lerp(MainCam.transform.localPosition, MainDefaultpos, Time.deltaTime * 50);
            //    yield return null;
            //}
            isTop = true;
        }
    }


    private void InputKeyFront()
    {
        //Y+
        if (Input.GetKey(KeyCode.W) && MainCam.transform.localPosition.y <= 5)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y + 0.25f, MainCam.transform.localPosition.z);

        }
        //Y-
        else if (Input.GetKey(KeyCode.S) && MainCam.transform.localPosition.y >= 0.5f)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y - 0.25f, MainCam.transform.localPosition.z);

        }
        //Z +
        else if (Input.GetKey(KeyCode.Z) && MainCam.transform.localPosition.z <= 5)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z + 0.25f);

        }
        //Z -
        else if (Input.GetKey(KeyCode.X) && MainCam.transform.localPosition.z >= -35)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z - 0.25f);
        }
        //X-
        else if (Input.GetKey(KeyCode.A) && MainCam.transform.localPosition.x >= -10)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x - 0.25f, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z);
        }
        //X+
        else if (Input.GetKey(KeyCode.D) && MainCam.transform.localPosition.x <= 10)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x + 0.25f, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z);
        }
    }

    private void InputKeyTop()
    {
        //Y+
        if (Input.GetKey(KeyCode.W) && MainCam.transform.localPosition.y <= 5)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y + 0.25f, MainCam.transform.localPosition.z);

        }
        //Y-
        else if (Input.GetKey(KeyCode.S) && MainCam.transform.localPosition.y >= -5)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x, MainCam.transform.localPosition.y - 0.25f, MainCam.transform.localPosition.z);

        }
        //Z +
        else if (Input.GetKey(KeyCode.Z) && MainCam.orthographicSize >= 10)
        {
            MainCam.orthographicSize -= 0.25f;
        }
        //Z -
        else if (Input.GetKey(KeyCode.X) && MainCam.orthographicSize <= 27)
        {
            MainCam.orthographicSize += 0.25f;
        }
        //X-
        else if (Input.GetKey(KeyCode.A) && MainCam.transform.localPosition.x >= -10)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x - 0.25f, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z);
        }
        //X+
        else if (Input.GetKey(KeyCode.D) && MainCam.transform.localPosition.x <= 10)
        {
            MainCam.transform.localPosition = new Vector3(MainCam.transform.localPosition.x + 0.25f, MainCam.transform.localPosition.y, MainCam.transform.localPosition.z);
        }
    }

    //Previous?
    public void OnclickUndo()
    {
        //To -  do
        //UI History -> push / pop
    }
}
