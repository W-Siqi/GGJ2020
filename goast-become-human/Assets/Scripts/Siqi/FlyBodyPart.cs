using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FlyBodyPart : MonoBehaviour
{
	public void StartFlyAwart(CharacterBodyDisplayer cloneSrc, FlyBodyPartSpawner.Config config) {
        // copy sprite
        var srcSpriteRenderer = cloneSrc.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = srcSpriteRenderer.sprite;

        // sync transform
        transform.localScale = cloneSrc.transform.localScale;
        transform.position = cloneSrc.transform.position;

        // add force
        var rb = GetComponent<Rigidbody2D>();

        var randomDirction = Random.insideUnitCircle;
        randomDirction.y = Mathf.Abs(randomDirction.y);
        var force = Random.Range(config.minForce,config.maxForce);
        rb.AddForce(force*randomDirction);

        var torque = Random.Range(-config.torqueRange,config.torqueRange);
        rb.AddTorque(torque);

        // destory
        Destroy(gameObject, 3f);
	}
}
