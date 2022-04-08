using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public static Party instance;

    void Awake()
    {
        instance = this;    
    }

    public Character[] partyArr; //= new Character[4] {null, null, null, null };

    public Character RemoveMember(string memberName) {
        for (int i = 0; i < partyArr.Length; i++) {
            if (memberName.Equals(partyArr[i].name)) {
                Character returner = partyArr[i];
                partyArr[i] = null;
                return returner;
            }
        }
        Debug.Log("That member was not in the active party");
        return null;
    }

    public void AddMember(Character member) {
        for (int i = 0; i < partyArr.Length; i++)
        {
            if (partyArr[i] == null)
            {
                partyArr[i] = member;
                return;
            }
        }
        Debug.Log("That member was not in the active party");
    }

    public void PrintParty() {
        for (int i = 0; i < partyArr.Length; i++)
        {

            if (partyArr[i] != null)
                Debug.Log(partyArr[i].name);
            else {
                Debug.Log("Empty slot");
            }
        }
    }
}
