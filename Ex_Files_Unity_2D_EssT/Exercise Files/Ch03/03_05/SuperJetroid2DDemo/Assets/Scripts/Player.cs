using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);

		if (absVelY < .2f) {
			standing = true;
		} else {
			standing = false;
		}

		if (Input.GetKey ("right")) {

			if(absVelX < maxVelocity.x)
				forceX = standing ? speed : (speed * airSpeedMultiplier);

			transform.localScale = new Vector3(1, 1, 1);

		} else if (Input.GetKey ("left")) {

			if(absVelX < maxVelocity.x)
				forceX = standing ? -speed : (-speed * airSpeedMultiplier);

			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetKey ("up")) {
			if(absVelY < maxVelocity.y)
				forceY = jetSpeed;
		}

		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	}
}
