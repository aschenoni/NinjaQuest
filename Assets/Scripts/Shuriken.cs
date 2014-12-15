using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

	public float rotationRate = 1.5f;
	public float constantSpeed = 25f;
	public float minV = 0.5f;
	int rotationDirection = 1;

	// Use this for initialization
	void Start () {
		Vector2 v0 = new Vector2(Random.Range(-10,10),Random.Range(-10,10));
		rigidbody2D.velocity = constantSpeed * v0.normalized;
	}
	
	// Update is called once per frame
	void Update () {
		var rotations = (rotationRate * Time.deltaTime * 360);
		transform.Rotate(new Vector3 (0, 0, rotationDirection * rotations));
		rigidbody2D.velocity = constantSpeed * rigidbody2D.velocity.normalized;

		checkValidVelocity ();
	}

	void OnCollisionEnter2D(Collision2D target) {
		rotationDirection *= -1;
		if (Mathf.Abs (rigidbody2D.velocity.x) < minV || 
				Mathf.Abs (rigidbody2D.velocity.y) < minV) {
			Unstick(target);		
		}

		if(target.gameObject.tag == "Ninja") {
			GameObject ninja = target.gameObject;

			Empower(ninja.GetComponent<Element>().getElement());
		}

	}

	//TODO
	void Unstick(Collision2D target) {
		Debug.Log ("Attempting to unstick");
	}

	void checkValidVelocity () {
		if (Mathf.Abs(rigidbody2D.velocity.y) < minV) {
			Debug.Log (Mathf.Abs (rigidbody2D.velocity.y));
			rigidbody2D.velocity = new Vector2(Random.Range(-10,10),Random.Range(-10,10));
		}
		if (Mathf.Abs(rigidbody2D.velocity.x) < minV) {
			Debug.Log (Mathf.Abs (rigidbody2D.velocity.x));
			rigidbody2D.velocity = new Vector2(Random.Range(-10,10),Random.Range(-10,10));
		}
	}

	void Empower(string element) {
		switch (element) {
			case "Fire":
			Debug.Log ("Fire!");
			break;
		default:
			Debug.Log ("No Element");
			break;
		}
	}
}
