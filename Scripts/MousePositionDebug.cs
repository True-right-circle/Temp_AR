using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MousePositionDebug : MonoBehaviour, IPointerClickHandler
{
    public Canvas canvas;
    public RectTransform rectTransform;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 viewportPoint = ScreenToRectPos(Input.mousePosition);
        UnityEngine.Debug.Log(viewportPoint);
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
}
