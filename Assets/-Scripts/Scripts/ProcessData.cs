using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessData
{
    //Process
    /********************************************************************/
    public class DCST
    {
        [SerializeField] public List<Food> food;
        [SerializeField] public List<string> Commnet;
    }

    /********************************************************************/

    //Action
    /********************************************************************/
    public class CAtion
    {
        [SerializeField] public string _action;
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
        [SerializeField] public List<FoodInfo> Whats;
    }

    public class FoodInfo
    {
        [SerializeField] public int Count;
        [SerializeField] public int Amount;
        [SerializeField] public string Status;
        [SerializeField] public string BuyingDate;
        [SerializeField] public string ExpireDate;
    }


    public class Food
    {
        [SerializeField] public string name;
        [SerializeField] public string category;
        [SerializeField] public string Status;
        [SerializeField] public string Shape;
        [SerializeField] public string Size;
        [SerializeField] public int count; //amount
        [SerializeField] public List<string> How;
        [SerializeField] public string Time;
    }

    /********************************************************************/
}
