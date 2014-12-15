using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour {
	
	private Animator animator;
	public float speed;
	Vector3 playerSize;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetInteger ("AnimState", 1);
		playerSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey ("right")) {
			transform.localScale = playerSize;
			animator.SetInteger("AnimState", 0);
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
			
		} else if(Input.GetKey ("left")) {
			Vector3 tempSize = playerSize;
			tempSize.x = -1 * tempSize.x;
			transform.localScale = tempSize;
			
			animator.SetInteger ("AnimState", 0);
			rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
		} else {
			rigidbody2D.velocity = new Vector2(0,0);
			animator.SetInteger ("AnimState", 1);
		}
		
		
	}
	
	
}
