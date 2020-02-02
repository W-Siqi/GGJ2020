using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUIMonitor : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public GameObject UI;

    private void Update()
    {
        if (characterInfo.equippedItem != ItemInfo.ItemType.None)
            UI.SetActive(true);
        else
            UI.SetActive(false);
    }
}
