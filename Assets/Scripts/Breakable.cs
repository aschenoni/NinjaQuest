using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {

	static int numberLayers = 6;
	public int layer; //Block Color
	public int tier; //headband
	       int hp;

	Sprite[] blocks;
	Sprite[] headbands;

	Transform headband;

	//Find more graceful way to load all sprites from memory based
	//on the number of layers
	public Sprite Block0;
	public Sprite Block1;
	public Sprite Block2;
	public Sprite Block3;
	public Sprite Block4;
	public Sprite Block5;

	public Sprite HB0;
	public Sprite HB1;
	public Sprite HB2;
	public Sprite HB3;
	public Sprite HB4;
	public Sprite HB5;

	// Use this for initialization
	void Start () {
		hp = (tier * 6) + layer;

		headband = transform.Find("Headband");
		initSprites();
		renderSprite();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Shuriken") {
			Break();
		}
	}

	void Break(){
		Debug.Log ("Broke layer: " + layer);
		if (hp > 0) {
			hp--;
			renderSprite ();
		} else {
			Destroy(gameObject);
		}

	}

	public void initSprites() {
		blocks = new Sprite[6] {Block0,Block1,Block2,Block3,Block4,Block5};
		headbands = new Sprite[7] {null,HB0,HB1,HB2,HB3,HB4,HB5};
	}

	public void renderSprite() {
		gameObject.GetComponent<SpriteRenderer>().sprite = blocks [(hp % 6)];
		headband.GetComponent<SpriteRenderer> ().sprite = headbands [hp / 6];
	}
}
