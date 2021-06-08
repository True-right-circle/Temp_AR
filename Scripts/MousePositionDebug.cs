using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MousePositionDebug : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Canvas canvas;
    public RectTransform rectTransform;
    public GameObject Dummy_Cube;
    Vector2 startpos = new Vector2();
    Vector2 endpos = new Vector2();

    public void OnPointerDown(PointerEventData eventData)
    {
        Dummy_Cube.transform.localScale = new Vector3(0.1f, 1, 1);
        //Dummy_Cube.SetActive(false);
        Dummy_Cube.SetActive(true);
        startpos = ScreenToRectPos(Input.mousePosition);

        Dummy_Cube.transform.localPosition = new Vector3(startpos.x,startpos.y, -0.51f);
    }


    public void OnDrag(PointerEventData eventData)
    {
        endpos = ScreenToRectPos(Input.mousePosition);
        float distance = GetDistance(endpos, startpos);
        if (endpos.x > startpos.x)
        {
            Dummy_Cube.transform.localScale = new Vector3(distance, Dummy_Cube.transform.localScale.y, Dummy_Cube.transform.localScale.z);
            Dummy_Cube.transform.localRotation = Quaternion.Euler(Dummy_Cube.transform.localRotation.x, Dummy_Cube.transform.localRotation.y, interpolateAngle(CalculateAngle(startpos, endpos)));
            UnityEngine.Debug.Log("z == \n" + interpolateAngle(CalculateAngle(startpos, endpos)));
        }
        else
        {
            Dummy_Cube.transform.localScale = new Vector3(-distance, Dummy_Cube.transform.localScale.y, Dummy_Cube.transform.localScale.z);
            Dummy_Cube.transform.localRotation = Quaternion.Euler(Dummy_Cube.transform.localRotation.x, Dummy_Cube.transform.localRotation.y, interpolateAngle(CalculateBAngle(startpos, endpos)));
            UnityEngine.Debug.Log("z == \n" + interpolateAngle(CalculateAngle(startpos, endpos)));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // endpos = ScreenToRectPos(Input.mousePosition);

        //Dummy_Cube.transform.localScale = new Vector3(endpos.x - startpos.x, Dummy_Cube.transform.localScale.y, Dummy_Cube.transform.localScale.z);
        //Dummy_Cube.SetActive(true);
        //UnityEngine.Debug.Log(startpos+"\n"+endpos+"\n"+ (endpos.x - startpos.x));
    }


    //https://answers.unity.com/questions/1169455/convert-inputmouseposition-to-recttransform-pivot.html
    //Input -> Mouse Position
    //ScreenPointToLocalPointInRectangle
    //param : 점이 위치할 사각형, 마우스(터치포인터) 위치, 카메라 : 메인 카메라, out -> 결과물 좌표
    //화면 공간 포인트를 사각형 평면에있는 RectTransform의 로컬 공간 위치로 변환합니다.
    public Vector2 ScreenToRectPos(Vector2 screen_pos)
    {
        //Canvas Mode => World
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && canvas.worldCamera != null)
        {
            //Canvas is in Camera mode
            Vector2 anchorPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screen_pos, canvas.worldCamera, out anchorPos);
            return anchorPos;
        }
        else
        {
            //Canvas is in Overlay mode
            Vector2 anchorPos = screen_pos - new Vector2(rectTransform.position.x, rectTransform.position.y);
            anchorPos = new Vector2(anchorPos.x / rectTransform.lossyScale.x, anchorPos.y / rectTransform.lossyScale.y);
            return anchorPos;
        }
    }

    float GetDistance(Vector2 start, Vector2 end)
    {
        // [과정1] 종점(x2, y2) - 시작점(x1, y1)
        float width = end.x - start.x;
        float height = end.y - start.y;

        // [과정2] 거리(크기)의 스칼라값을 구하기 위해 피타고라스 정리 사용
        float distance = width * width + height * height;
        distance = Mathf.Sqrt(distance);

        return distance;
    }

    public static float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.right, to - from).eulerAngles.z;
    }

    public static float CalculateBAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.left, to - from).eulerAngles.z;
    }


    //To do : interpolate Input Angle each range
    public static float interpolateAngle(float angle)
    {
        // Ceil -??
        return Mathf.Ceil(angle);
    }


}
