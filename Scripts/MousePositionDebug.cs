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
    public Vector2 ScreenToRectPos(Vector2 screen_pos)
    {
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
