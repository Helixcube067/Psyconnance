using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Has all the MC data and also holds the party information
//inherits from character class for its private variables
[System.Serializable]
public class MainCharacter : Character
{
    //These stats are static to be able to reference them anywhere
    //they get converted into privates to be able to safe them since you cant serialize static variables
    [SerializeField]
    private Character[] party;
    [SerializeField]
    private string location;
    [SerializeField]
    private int money;
    public static int staticMoney;
    public static string staticLocation;
    public static string mcName;
    public static int mcLevel;
    public static int mcExp;
    public static int mcMaxHealth;
    public static int mcCurrHealth;
    public static int mcMaxSp;
    public static int mcCurrSp;
    public static int mcStr;
    public static int mcVit;
    public static int mcMag;
    public static int mcAg;
    public static float mcElecAffinity;
    public static float mcFireAffinity;
    public static float mcIceAffinity;
    public static float mcDarkAffinity;
    public static float mcHolyAffinity;
    public static Stack<int> mcSkillProgress;
    public static Stack mcSkills;

    //sets all the private variables here
    public MainCharacter()
    {
        this.name = mcName;
        this.level = mcLevel;
        this.exp = mcExp;
        this.maxHealth = mcMaxHealth;
        this.currHealth = mcCurrHealth;
        this.maxSP = mcMaxSp;
        this.currSP = mcCurrSp;
        this.str = mcStr;
        this.vit = mcVit;
        this.mag = mcMag;
        this.ag = mcAg;
        this.elecAffinity = mcElecAffinity;
        this.fireAffinity = mcFireAffinity;
        this.iceAffinity = mcIceAffinity;
        this.darkAffinity = mcDarkAffinity;
        this.holyAffinity = mcHolyAffinity;
        this.skillLevels = mcSkillProgress;
        this.skillStack = mcSkills;
        location = staticLocation;
    }

    //MC initialization of stats.
    //This automatically gets called during the opening
    public void McJoins() {
        mcExp = 0;
        mcLevel = 1;
        mcMaxHealth = 100;
        mcCurrHealth = mcMaxHealth;
        mcMaxSp = 100;
        mcCurrSp = mcMaxSp;
        mcStr = 4;
        mcVit = 4;
        mcMag = 3;
        mcAg = 4;
        mcElecAffinity = 1.0f;
        mcFireAffinity = 1.0f;
        mcIceAffinity = 1.0f;
        mcDarkAffinity = 1.5f;
        mcHolyAffinity = 0.5f;
        mcSkillProgress = new Stack<int>();
        mcSkillProgress.Push(2);
        mcSkillProgress.Push(3);
        mcSkillProgress.Push(6);
        mcSkills = new Stack();
        staticMoney = 0;
        Party.instance.partyArr = new Character[4] { null, null, null, null };
        Party.instance.AddMember(this);
        Party.instance.PrintParty();
        staticLocation = "Tower 1F";
    }

    public override void LevelUp()
    {
        //maybe 0.75 for one stats cept one and 0.50 for the rest? or vice versa? idk
        return;
    }

    //reloading mc into the game
    public override void LoadMember()
    {
        MainCharacter loadedMc = SaveSystem.LoadMc();
        name = loadedMc.name;
        mcName = loadedMc.name;

        staticMoney = loadedMc.money;
        money = loadedMc.money;

        location = loadedMc.location;
        staticLocation = loadedMc.location;

        mcLevel = loadedMc.level;
        level = loadedMc.level;

        mcExp = loadedMc.exp;
        exp = loadedMc.exp;

        maxHealth = loadedMc.maxHealth;
        mcMaxHealth = loadedMc.maxHealth;

        mcCurrHealth = loadedMc.currHealth;
        currHealth = loadedMc.currHealth;

        mcCurrSp = loadedMc.currSP;
        currSP = loadedMc.currSP;

        mcMaxSp = loadedMc.maxSP;
        maxSP = loadedMc.maxSP;

        mcStr = loadedMc.str;
        str = loadedMc.str;

        vit = loadedMc.vit;
        mcVit = loadedMc.vit;

        mag = loadedMc.mag;
        mcMag = loadedMc.mag;

        ag = loadedMc.ag;
        mcAg = loadedMc.ag;

        mcFireAffinity = loadedMc.fireAffinity;
        fireAffinity = loadedMc.fireAffinity;

        elecAffinity = loadedMc.elecAffinity;
        mcElecAffinity = loadedMc.elecAffinity;

        iceAffinity = loadedMc.iceAffinity;
        mcIceAffinity = loadedMc.iceAffinity;

        holyAffinity = loadedMc.holyAffinity;
        mcHolyAffinity = loadedMc.holyAffinity;

        darkAffinity = loadedMc.darkAffinity;
        mcDarkAffinity = loadedMc.darkAffinity;

        skillLevels = loadedMc.skillLevels;
        mcSkillProgress = loadedMc.skillLevels;

        skillStack = loadedMc.skillStack;
        mcSkills = loadedMc.skillStack;

        party = loadedMc.GetParty();
        Party.instance.partyArr = loadedMc.GetParty();
    }

    //Saving the MC info
    public override void SaveMember()
    {
        party = Party.instance.partyArr;
        Debug.Log("Attempting to save " + name);
        SaveSystem.SaveMc(this);
    }

    public string GetLocation() {
        return location;
    }

    public void SetLocation(string newPlace) {
        staticLocation = newPlace;
        location = newPlace;
    }

    public int GetMoney() {
        return money;
    }

    public Character[] GetParty()
    {
        return party;
    }
}
