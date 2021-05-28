using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

public class Inputsysmng : MonoBehaviour
{
    private float pivotSize = 3.305785f;
    private float width = 0f;
    private float height = 0f;
    string pnum = "";
    public void OnTextEnd(TextMeshProUGUI num)
    {
        //num뒤에 공백이 온다?
        //https://forum.unity.com/threads/textmesh-pro-ugui-hidden-characters.505493/
        pnum = num.text.Trim((char)8203);
        UnityEngine.Debug.Log("num == 0   " + pnum.Length);
        for(int i=0; i<num.text.Length; ++i)
        {
            UnityEngine.Debug.Log("num char =  " + num.text[i]);
        }
        printInt();
    }
    private void printInt()
    {
        UnityEngine.Debug.Log(int.Parse(pnum)*pivotSize);
    }
}
