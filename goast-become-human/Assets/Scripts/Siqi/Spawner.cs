﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spwanStartTime = 0f;
    public int maxCount = 3;
    public Vector2 spawnInterval = new Vector2(2f, 3f);
    public Vector2 spawnRange = new Vector2(1f, 1f);
    public GameObject spawnPrefab = null;

    private const string NONE_TAG = "none";
    private string spawnTagName = NONE_TAG;

    void Start() {
        spawnTagName = spawnPrefab.GetComponent<SpwanObjectTag>().name;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop() {
        yield return new WaitForSeconds(spwanStartTime);

        while (true) {
            if (isUnderCount) {
                var spawnPos = GetSpawnPos();
                GameObject.Instantiate(spawnPrefab, spawnPos, Quaternion.identity);
            }
            var interval = Random.Range(spawnInterval.x, spawnInterval.y);
            yield return new WaitForSeconds(interval);
        }
    }

    private Vector3 GetSpawnPos() {
        var randomBias = new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y),0);
        return transform.position + randomBias;
    }

    private bool isUnderCount {
        get {
            if (spawnTagName == NONE_TAG)
                return false;
            else if (SpwanObjectTag.GetNumber(spawnTagName) < maxCount)
                return true;
            else
                return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.3f);
    }
}
