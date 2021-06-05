using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanManager : MonoBehaviour
{
    public static PlanManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
