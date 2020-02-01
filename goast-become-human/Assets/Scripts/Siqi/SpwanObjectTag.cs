using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanObjectTag : MonoBehaviour
{
    public string name;

    public static int GetNumber(string tagName) {
        var sum = 0;
        foreach (var tagObj in FindObjectsOfType<SpwanObjectTag>()) {
            if (tagObj.name == tagName) {
                sum++;
            }
        }
        return sum;
    }
}
