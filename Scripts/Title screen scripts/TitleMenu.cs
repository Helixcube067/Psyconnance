using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleMenu : MonoBehaviour
{
    public TextMeshProUGUI ToD;
    public TextMeshProUGUI date;
    public TextMeshProUGUI day;
    public TextMeshProUGUI level;
    public TextMeshProUGUI mcname;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI sp;
    public TextMeshProUGUI money;
    public TextMeshProUGUI location;
    public GameObject mcInfo;
    public GameObject noSaveText;
    public GameObject loadButton;

    public void LoadMenuUIUpdate() {
        MainCharacter mc = new MainCharacter();
        mc.LoadMember();
        if (SaveSystem.LoadMc() != null)
        {
            level.text = "pLvl: " + mc.level.ToString();
            mcname.text = mc.name;
            hp.text = "Hp: " + mc.currHealth + "/" + mc.maxHealth;
            sp.text = "Sp: " + mc.currSP + "/" + mc.maxSP;
            money.text = "Money: " + mc.GetMoney();
            location.text = mc.GetLocation();
        }
        else {
            Debug.Log("Theres no save data");
            mcInfo.SetActive(false);
            loadButton.SetActive(false);
            noSaveText.SetActive(true);
        }
            
    }
}
