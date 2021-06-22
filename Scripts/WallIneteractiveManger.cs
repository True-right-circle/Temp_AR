using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Figureout
/// Use IPoint~ on UI
/// Use OnMOuse~ on GameObject
/// </summary>
public class WallIneteractiveManger : MonoBehaviour, IPointerClickHandler
{

    //for point to Camera ray point
    public Camera mainCam;
    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
                UnityEngine.Debug.Log(hit.collider.name);
        }
    }

    //it's work only UI 
    public void OnPointerClick(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("my event =\n" + eventData.clickTime);
    }

    public void OnMouseOver()
    {
        UnityEngine.Debug.Log("this name - " + this.name);
    }
}
