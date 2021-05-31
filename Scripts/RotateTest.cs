using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public GameObject mPlane;
    private bool isTop = false;
    Quaternion Top = new Quaternion();
    Quaternion Front = new Quaternion();
    Coroutine RotateCor = null;
    float spinSpeed = 50.5f;
    private void Awake()
    {
        Top = Quaternion.Euler(-90,0,0);
        Front = Quaternion.Euler(0,45,0);
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
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Front);
            while (angle >= 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Front, Time.deltaTime * spinSpeed);
                yield return null;
            }
            UnityEngine.Debug.Log(angle + isTop.ToString());
            isTop = false;
        }
        else
        {
            float angle = Quaternion.Angle(mPlane.transform.localRotation, Top);
            while (angle >= 0)
            {
                mPlane.transform.localRotation = Quaternion.RotateTowards(mPlane.transform.localRotation, Top, Time.deltaTime * spinSpeed);
                yield return null;
                UnityEngine.Debug.Log(angle);
            }
            UnityEngine.Debug.Log(angle + isTop.ToString());
            isTop = true;
        }
    }
}
