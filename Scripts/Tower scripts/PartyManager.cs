using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this might be cleaner compared to the player manager script but im keeping this here juuuuust in case
public class PartyManager : MonoBehaviour
{
    #region singleton
    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}
