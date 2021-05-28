using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

//올림 : Math.ceiling()
//내림 : Math.Truncate
//반올림 : Math.Round(값,자릿수)
public class Inputsysmng : MonoBehaviour
{
    //M 단위
    private float pivotSize = 3.305785f;
    private float width = 0f;
    private float height = 0f;
    private float totalSize = 0.0f;
    private string pnum = "";

    public Canvas PlaneCanvas;
    public GameObject Cude_Panel;
    public GameObject Default_Cude; 
    public List<GameObject> Cubes;

    public void OnTextEnd(TextMeshProUGUI num)
    {
        Cubes = new List<GameObject>();

        //num뒤에 공백이 온다?
        //https://forum.unity.com/threads/textmesh-pro-ugui-hidden-characters.505493/
        pnum = num.text.Trim((char)8203);
        totalSize = int.Parse(pnum) * pivotSize;
    }
    public void OnTextEndWidth(TextMeshProUGUI num)
    {
        string swidth = num.text.Trim((char)8203);
        UnityEngine.Debug.Log(swidth);
        width = float.Parse(swidth);
        height = totalSize / width;
        double dheight = Math.Round(totalSize / width,2);
        height = (float)dheight;
        UnityEngine.Debug.Log("Total = " + totalSize);
        UnityEngine.Debug.Log("width = " + width);
        UnityEngine.Debug.Log("height = " + height);
        UnityEngine.Debug.Log("height = " + dheight);
        BuildPlane();
    }

    private void BuildPlane()
    {
        if (!PlaneCanvas.gameObject.activeSelf)
            PlaneCanvas.gameObject.SetActive(true);

        PlaneCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        TurnOnCude();
    }

    public void TurnOnCude()
    {
        for(int i=0; i<(int)totalSize; ++i)
        {
            Cude_Panel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}
