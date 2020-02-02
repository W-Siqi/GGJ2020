using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyWeaponPart : CharacterBodyDisplayer
{
    public GameObject respawnPrefab;
    protected override void OnPaintCanceled()
    {
        GameObject.Instantiate(respawnPrefab, transform.position, Quaternion.identity);
    }
}
