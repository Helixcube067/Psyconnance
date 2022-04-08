using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character
{
    public string name;
    public int level;
    public int exp;
    public int maxHealth;
    public int currHealth;
    public int maxSP;
    public int currSP;
    public int str;
    public int vit;
    public int mag;
    public int ag;

    public float elecAffinity;
    public float fireAffinity;
    public float iceAffinity;
    public float holyAffinity;
    public float darkAffinity;

    public Stack<int> skillLevels;
    public Stack skillStack;

    public virtual void LevelUp() {
        return;
    }

    public virtual void SaveMember() {
        return;
    }

    public virtual void LoadMember() {
        return;
    }

    public int TakeDamage(int dmg)
    {
        //int damage = dmg - def;
        currHealth -= dmg;
        //returning damage because will calculate armor stuff possibly later
        return dmg;
    }

    public bool AliveCheck()
    {
        if (currHealth <= 0)
            return true;
        else
            return false;
    }
}
