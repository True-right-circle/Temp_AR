using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessData
{
    //Process
    /********************************************************************/
    public class DCST
    {
        [SerializeField] public string What;
        [SerializeField] public string How;
        [SerializeField] public string Time;
        [SerializeField] public string Status;
    }
    /********************************************************************/


    //Tools
    /********************************************************************/
    public class Tools
    {
        [SerializeField] public List<cTool> Whats;
    }

    public class cTool
    {
        [SerializeField] public string Category;
        [SerializeField] public string Color;
        [SerializeField] public string Brand;
    }
    /********************************************************************/


    //obj
    /********************************************************************/
    public class MyBusket
    {
        [SerializeField] public List<mObject> Whats;
    }

    public class mObject
    {
        [SerializeField] public int Count;
        [SerializeField] public int Amount;
        [SerializeField] public string Status;
        [SerializeField] public string BuyingDate;
        [SerializeField] public string ExpireDate;
    }
    /********************************************************************/
}
