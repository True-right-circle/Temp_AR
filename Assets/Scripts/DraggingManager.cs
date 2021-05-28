using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingManager : MonoBehaviour
{
    public GameObject Dargging_rect;
    public RectTransform Debugging_rect;

    private bool isDragging = false;
    private Vector2 StartPos = new Vector2(0, 0);
    private Vector2 EndPos = new Vector2(0, 0);
    public Camera main;
    public GameObject Cude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DraggingRect();
    }

    
    private void DraggingRect()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            StartPos = Input.mousePosition;
            Dargging_rect.SetActive(true);
            Dargging_rect.transform.position = StartPos;

            Vector3 mainpos = main.ScreenToWorldPoint(new Vector3(Dargging_rect.transform.position.x, Dargging_rect.transform.position.y, main.nearClipPlane));
            Cude.transform.localPosition = new Vector3(mainpos.x, mainpos.y, 0);
        }
        else if(Input.GetMouseButton(0))
        {
            if (isDragging)
            {
                EndPos = Input.mousePosition;
                Dargging_rect.transform.localScale = new Vector3(EndPos.x - StartPos.x,(EndPos.y - StartPos.y), 1);
                UnityEngine.Debug.Log(main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, main.nearClipPlane)));
                //Cude.transform.localPosition = main.ScreenToWorldPoint(Dargging_rect.transform.position);
                Vector3 mainpos = main.ScreenToWorldPoint(new Vector3(EndPos.x - StartPos.x, EndPos.y - StartPos.y, main.nearClipPlane));
              
                //Cude.transform.localScale = new Vector3(mainpos.x, mainpos.y, 1);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Dargging_rect.transform.localScale = new Vector3(1, 1, 1);
            Dargging_rect.SetActive(false);
            isDragging = false;
        }
    }
}
