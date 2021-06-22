using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonData;

public class PlaneManger : MonoBehaviour
{
    //plane color 94F3C0
    //2 way
    public GameObject DummyWall;
    public List<LineInfo> LineIfo;
    public Canvas Plane;
    //Distance pivot = 1.818m
    private float pivot = 1.818f;
    
    //for Create Dummy
    public void CreateDummy()
    {
        for(int i =0; i<4; ++i)
        {

        }
    }

    public void Awake()
    {
        LineIfo = new List<LineInfo>();
    }

    //To do list? 
    public void SetLineInfo()
    {

    }
    
    public void GetLineInfo()
    {

    }

    public void InitializePlaneSize(int hor, int ver)
    {
        // To - do
        // Default Mode, Default Camera Setting, Default Position, Defualt View ect...
        Plane.GetComponent<RectTransform>().sizeDelta = new Vector2(hor * pivot, ver * pivot);
    }

    public void BuildWall()
    {

    }
}
