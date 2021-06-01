using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ViewState
{
    Top,
    Front
}

public class RotateTest : MonoBehaviour
{
    public GameObject mCam;
    public GameObject mPlane;
    private bool isTop = false;
    private bool isCamTop = false;
    private ViewState _state;

    Quaternion Top = new Quaternion();
    Quaternion Front = new Quaternion();
    Vector3 CamFront = new Vector3();
    Vector3 CamTop = new Vector3();

    Coroutine CamRotateCor = null;
    Coroutine RotateCor = null;
    float spinSpeed = 600f;
    private void Awake()
    {
        _state = ViewState.Front;
        //Plane
        //Top = Quaternion.Euler(-90,0,0);
        //Front = Quaternion.Euler(0,45,0);

        //Canvas
        Top = Quaternion.Euler(0, 0, 0);
        Front = Quaternion.Euler(90, 45, 0);

        CamFront = new Vector3(0, 3.5f, -10);
        CamTop = new Vector3(0, 0, -10);

        float angle = Quaternion.Angle(mPlane.transform.localRotation, mCam.transform.localRotation);
        UnityEngine.Debug.Log("cam r " + angle);
    }

    public void OnClickRotatePlane()
    {
        startRotateCor();
        //StartCamRotateCor();
    }

    private void startRotateCor()
    {
        if (RotateCor != null)
            RotateCor = null;

        RotateCor = StartCoroutine(RotateCorutine());
    }
    //Front y,z
    //Top x,y,z
    private void Update()
    {
        if(_state.Equals(ViewState.Front))
        {
            InputKeyFront();
        }
        else if(_state.Equals(ViewState.Top))
        {
            InputKeyTop();
        }
    }

    private void InputKeyFront()
    {
        //Y+
        if (Input.GetKey(KeyCode.W) && mCam.transform.localPosition.y <= 5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y + 0.1f, mCam.transform.localPosition.z);

        }
        //Y-
        else if (Input.GetKey(KeyCode.S) && mCam.transform.localPosition.y >= 0.5f)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y - 0.1f, mCam.transform.localPosition.z);

        }
        //Z +
        else if (Input.GetKey(KeyCode.Z) && mCam.transform.localPosition.z <= 5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y, mCam.transform.localPosition.z + 0.1f);

        }
        //Z -
        else if (Input.GetKey(KeyCode.X) && mCam.transform.localPosition.z >= -10)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y, mCam.transform.localPosition.z - 0.1f);
        }
    }

    private void InputKeyTop()
    {
        //Y+
        if (Input.GetKey(KeyCode.W) && mCam.transform.localPosition.y<=5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y + 0.1f, mCam.transform.localPosition.z);

        }
        //Y-
        else if (Input.GetKey(KeyCode.S) && mCam.transform.localPosition.y >= -5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y - 0.1f, mCam.transform.localPosition.z);

        }
        //Z +
        else if (Input.GetKey(KeyCode.Z) && mCam.transform.localPosition.z <= 5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y, mCam.transform.localPosition.z + 0.1f);

        }
        //Z -
        else if (Input.GetKey(KeyCode.X) && mCam.transform.localPosition.z >= -10)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x, mCam.transform.localPosition.y, mCam.transform.localPosition.z - 0.1f);
        }
        //X-
        else if(Input.GetKey(KeyCode.A) && mCam.transform.localPosition.x >= -5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x-0.1f, mCam.transform.localPosition.y, mCam.transform.localPosition.z);
        }
        //X+
        else if(Input.GetKey(KeyCode.D) && mCam.transform.localPosition.x <= 5)
        {
            mCam.transform.localPosition = new Vector3(mCam.transform.localPosition.x+0.1f, mCam.transform.localPosition.y, mCam.transform.localPosition.z );
        }
    }
    IEnumerator RotateCorutine()
    {
        if (isTop)
        {
            _state = ViewState.Front;
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Front);
            while (angle > 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Front, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(mPlane.transform.localRotation, Front);
                yield return null;
            }
            while (!(mCam.transform.localPosition == CamFront))
            {
                mCam.transform.localPosition = Vector3.Lerp(mCam.transform.localPosition, CamFront, Time.deltaTime * 15);
                yield return null;
            }
            isTop = false;
        }
        else
        {
            _state = ViewState.Top;
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Top);
            while (angle > 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Top, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(mPlane.transform.localRotation, Top);
                yield return null;
            }
            while(!(mCam.transform.localPosition== CamTop))
            {
                mCam.transform.localPosition = Vector3.Lerp(mCam.transform.localPosition, CamTop, Time.deltaTime * 15);
                yield return null;
            }
            isTop = true;
        }
    }


    private void StartCamRotateCor()
    {
        if (CamRotateCor != null)
            CamRotateCor = null;

        CamRotateCor = StartCoroutine(RotateCamCorutine());

    }

    IEnumerator RotateCamCorutine()
    {
        if(isCamTop)
        {
            float angle = Quaternion.Angle(mPlane.transform.localRotation, mCam.transform.localRotation);
            while (angle<95.0f && angle>45.0f)
            {
                mCam.transform.RotateAround(mPlane.transform.position, Vector3.left, Time.deltaTime * 300);
                angle = Quaternion.Angle(mPlane.transform.localRotation, mCam.transform.localRotation);
                UnityEngine.Debug.Log("cam r " + angle);
                yield return null;
            }
            isCamTop = false;
        }
        else
        {
            float angle = Quaternion.Angle(mPlane.transform.localRotation, mCam.transform.localRotation);
            while (angle<90.0f)
            {
                mCam.transform.RotateAround(mPlane.transform.position, Vector3.right, Time.deltaTime * 600);
                angle = Quaternion.Angle(mPlane.transform.localRotation, mCam.transform.localRotation);
                yield return null;
            }
           // UnityEngine.Debug.Log("cam r " + angle);
            isCamTop = true;
        }
    }


}
