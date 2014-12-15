using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float attackDelay = 3f;

	// Use this for initialization
	void Start () {
	
		if (attackDelay > 0) {
			StartCoroutine(OnAttack());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnAttack()
	{
		yield return new WaitForSeconds (attackDelay);
		GetComponent<AttackBehavior> ().Attack();
		StartCoroutine (OnAttack ());
	}
}
