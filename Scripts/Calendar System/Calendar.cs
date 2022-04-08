using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;

    private void Awake()
    {
        instance = this;
    }

    public Month[] monthQueue;
}
