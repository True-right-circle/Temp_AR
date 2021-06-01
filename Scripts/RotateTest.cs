using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public GameObject mCam;
    public GameObject mPlane;
    private bool isTop = false;
    private bool isCamTop = false;

    Quaternion Top = new Quaternion();
    Quaternion Front = new Quaternion();
    Vector3 CamFront = new Vector3();
    Vector3 CamTop = new Vector3();

    Coroutine CamRotateCor = null;
    Coroutine RotateCor = null;
    float spinSpeed = 600f;
    private void Awake()
    {
        Top = Quaternion.Euler(-90,0,0);
        Front = Quaternion.Euler(0,45,0);

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
    IEnumerator RotateCorutine()
    {
        if (isTop)
        {
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Front);
            while (angle > 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Front, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(mPlane.transform.localRotation, Front);
                yield return null;
            }
            while (!(mCam.transform.localPosition == CamFront))
            {
                mCam.transform.localPosition = Vector3.Lerp(mCam.transform.localPosition, CamFront, Time.deltaTime * 10);
                yield return null;
            }
            isTop = false;
        }
        else
        {
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Top);
            while (angle > 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Top, Time.deltaTime * spinSpeed);
                angle = Quaternion.Angle(mPlane.transform.localRotation, Top);
                yield return null;
            }
            while(!(mCam.transform.localPosition== CamTop))
            {
                mCam.transform.localPosition = Vector3.Lerp(mCam.transform.localPosition, CamTop, Time.deltaTime * 10);
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
