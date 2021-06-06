using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
    ROtate,
    Block,
    Shit
}
//Plane Edit Mode
public class PlanManager : MonoBehaviour
{
    public static PlanManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    //back
    public void OnClickUndo()
    {

    }

    //Delete
    public void Alldelete()
    {

    }

    //Save
    public void Save()
    {

    }

    public void ModeChange(Mode m)
    {

    }
}
