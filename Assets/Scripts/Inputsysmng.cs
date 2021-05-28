using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inputsysmng : MonoBehaviour
{

    public void OnTextEnd(TextMeshProUGUI num)
    {
        UnityEngine.Debug.Log("num == "+ num.text);
    }
}
