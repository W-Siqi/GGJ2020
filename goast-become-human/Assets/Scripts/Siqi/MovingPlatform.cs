using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed =1f;
    public float moveRange = 1f;
    public bool isMoving = true;
	public bool isInitMovingLeft = true;
    private float left;
    private float right;
    private bool towardsLeft;

    private void Start()
    {
        towardsLeft = true;
        left = transform.position.x - moveRange;
        right = transform.position.x + moveRange;

		if (isInitMovingLeft)
			towardsLeft = true;
		else
			towardsLeft = false;
    }

    private void Update()
    {
        if (isMoving) {
            if (towardsLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                if (transform.position.x < left)
                    towardsLeft = false;
            }
            else {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (transform.position.x > right)
                    towardsLeft = true;
            }
        }
    }
}
