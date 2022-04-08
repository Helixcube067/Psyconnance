using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToD { MORNING, AFTERNOON, NIGHT, TOWER }
public enum Weekdays { Mon, Tues, Weds, Thur, Fri, Sat, Sun }
public enum Mood { Fine, Depressed, Great }

[System.Serializable]
public class DayData
{
    public int month;
    public int day;
    public ToD tod;
    public Weekdays weekdays;
    public Mood mood;
}
