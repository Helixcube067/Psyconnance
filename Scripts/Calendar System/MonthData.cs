using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonthName { Jan, Feb, Mar }

[System.Serializable]
public class MonthData
{
    public int month;
    public MonthName monthName;
    public Days[] days;
}
