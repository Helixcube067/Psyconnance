using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waffle : Character
{
    public static int wafLevel;
    public static int wafExp;
    public static int wafMaxHealth;
    public static int wafCurrHealth;
    public static int wafMaxSp;
    public static int wafCurrSp;
    public static int wafStr;
    public static int wafVit;
    public static int wafMag;
    public static int wafAg;
    public static float wafElecAffinity;
    public static float wafFireAffinity;
    public static float wafIceAffinity;
    public static float wafDarkAffinity;
    public static float wafHolyAffinity;
    public static Stack<int> wafSkillProgress;
    public static Stack wafSkills;

    public Waffle()
    {
        this.name = "Waffle";
        this.exp = wafExp;
        this.level = wafLevel;
        this.maxHealth = wafMaxHealth;
        this.currHealth = wafCurrHealth;
        this.maxSP = wafMaxSp;
        this.currSP = wafCurrSp;
        this.str = wafStr;
        this.vit = wafVit;
        this.mag = wafMag;
        this.ag = wafAg;
        this.elecAffinity = wafElecAffinity;
        this.fireAffinity = wafFireAffinity;
        this.iceAffinity = wafIceAffinity;
        this.darkAffinity = wafDarkAffinity;
        this.holyAffinity = wafHolyAffinity;
        this.skillLevels = wafSkillProgress;
        this.skillStack = wafSkills;
    }

    //15 points total
    public void WaffleJoins() {
        wafExp = 0;
        wafLevel = 1;
        wafMaxHealth = 100;
        wafCurrHealth = wafMaxHealth;
        wafMaxSp = 75;
        wafCurrSp = wafMaxSp;
        wafStr = 5;
        wafVit = 5;
        wafMag = 2;
        wafAg = 3;
        wafElecAffinity = 1.0f;
        wafFireAffinity = 1.0f;
        wafIceAffinity = 1.0f;
        wafDarkAffinity = 0.5f;
        wafHolyAffinity = 1.5f;
        wafSkillProgress = new Stack<int>();
        wafSkillProgress.Push(2);
        wafSkillProgress.Push(3);
        wafSkillProgress.Push(6);
        wafSkills = new Stack();
    }

    public override void LevelUp()
    {
        //I think 0.75f for main stats with 0.50/0.25 for off stats is the beter growth rate
        return;
    }

    public override void LoadMember()
    {
        Waffle loadedWaffle = SaveSystem.LoadWaffle();
        name = "Waffle";

        wafLevel = loadedWaffle.level;
        level = loadedWaffle.level;

        wafExp = loadedWaffle.exp;
        exp = loadedWaffle.exp;

        maxHealth = loadedWaffle.maxHealth;
        wafMaxHealth = loadedWaffle.maxHealth;

        wafCurrHealth = loadedWaffle.currHealth;
        currHealth = loadedWaffle.currHealth;

        wafCurrSp = loadedWaffle.currSP;
        currSP = loadedWaffle.currSP;

        wafMaxSp = loadedWaffle.maxSP;
        maxSP = loadedWaffle.maxSP;

        wafStr = loadedWaffle.str;
        str = loadedWaffle.str;

        vit = loadedWaffle.vit;
        wafVit = loadedWaffle.vit;

        mag = loadedWaffle.mag;
        wafMag = loadedWaffle.mag;

        ag = loadedWaffle.ag;
        wafAg = loadedWaffle.ag;

        wafFireAffinity = loadedWaffle.fireAffinity;
        fireAffinity = loadedWaffle.fireAffinity;

        elecAffinity = loadedWaffle.elecAffinity;
        wafElecAffinity = loadedWaffle.elecAffinity;

        iceAffinity = loadedWaffle.iceAffinity;
        wafIceAffinity = loadedWaffle.iceAffinity;

        holyAffinity = loadedWaffle.holyAffinity;
        wafHolyAffinity = loadedWaffle.holyAffinity;

        darkAffinity = loadedWaffle.darkAffinity;
        wafDarkAffinity = loadedWaffle.darkAffinity;

        skillLevels = loadedWaffle.skillLevels;
        wafSkillProgress = loadedWaffle.skillLevels;

        skillStack = loadedWaffle.skillStack;
        wafSkills = loadedWaffle.skillStack;
    }

    public override void SaveMember()
    {
        Debug.Log("We are attemtping to save waffle");
        SaveSystem.SaveWaffle(this);
    }
}
