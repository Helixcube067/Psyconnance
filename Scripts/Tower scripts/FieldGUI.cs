using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FieldGUI : MonoBehaviour
{
    public GameObject GUIPanel;
    public GameObject pausePanel;
    public TextMeshProUGUI floorName;

    public TextMeshProUGUI todText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spText;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        floorName.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausePanel.activeInHierarchy)
            GUIPanel.SetActive(false);
        else
            GUIPanel.SetActive(true);
    }

    public void UpdateFieldGUI() {
        floorName.text = SceneManager.GetActiveScene().name;
    }

    public void PauseMenuStatsUpdate() {
        MainCharacter mc = new MainCharacter();
        mc.LoadMember();
        levelText.text = "pLvl: " + mc.level.ToString();
        nameText.text = mc.name;
        hpText.text = "Hp: " + mc.currHealth + "/" + mc.maxHealth;
        spText.text = "Sp: " + mc.currSP + "/" + mc.maxSP;
        moneyText.text = "Money: " + mc.GetMoney();

    }
}
