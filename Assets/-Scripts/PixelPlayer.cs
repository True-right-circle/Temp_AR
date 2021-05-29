using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IPointerClickHandler etc..
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PixelPlayer : MonoBehaviour, IPointerEnterHandler
{
    private Image cross;
    private void Awake()
    {
        cross = this.GetComponent<Image>();
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(InputManager.instance.isDragging)
        {
            //cross.color = new Color(1, 0, 0);
            this.transform.GetChild(0).gameObject.SetActive(true);
            UnityEngine.Debug.Log(this.name);
        }
    }

}

