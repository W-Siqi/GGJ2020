using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBodyPartSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Config {
        public float maxForce = 100f;
        public float minForce = 20f;
        public float torqueRange = 50f;
    }

    public static FlyBodyPartSpawner instance = null;

    public GameObject flyBodyPartPrefab;
    public Config config;

    private void Start()
    {
        instance = this;
    }

    public static void SpawnFlyBodyPart(CharacterBodyDisplayer cloneSrc) {
        if (instance) {
            var GO = GameObject.Instantiate(instance.flyBodyPartPrefab);
            var flybody = GO.GetComponent<FlyBodyPart>();
            flybody.StartFlyAwart(cloneSrc, instance.config);
        }
    }
}
