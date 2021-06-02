using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MousePositionDebug : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Canvas canvas;
    public RectTransform rectTransform;
    public GameObject Dummy_Cube;
    Vector2 startpos = new Vector2();
    Vector2 endpos = new Vector2();

    public void OnPointerDown(PointerEventData eventData)
    {
        Dummy_Cube.SetActive(false);
        startpos = ScreenToRectPos(Input.mousePosition);
        Dummy_Cube.transform.localPosition = startpos;
        UnityEngine.Debug.Log(startpos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endpos = ScreenToRectPos(Input.mousePosition);

        Dummy_Cube.transform.localScale = new Vector3(endpos.x - startpos.x, Dummy_Cube.transform.localScale.y, Dummy_Cube.transform.localScale.z);
        Dummy_Cube.SetActive(true);
        UnityEngine.Debug.Log(startpos+"\n"+endpos+"\n"+ (endpos.x - startpos.x));
    }


    //https://answers.unity.com/questions/1169455/convert-inputmouseposition-to-recttransform-pivot.html
    //Input -> Mouse Position
    //ScreenPointToLocalPointInRectangle
    //param : ���� ��ġ�� �簢��, ���콺(��ġ������) ��ġ, ī�޶� : ���� ī�޶�, out -> ����� ��ǥ
    //ȭ�� ���� ����Ʈ�� �簢�� ��鿡�ִ� RectTransform�� ���� ���� ��ġ�� ��ȯ�մϴ�.
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
