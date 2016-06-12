using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

	public GameObject player;
	public AudioClip swing;
	public static bool hit = false;
	public static Vector3 point;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(player.transform.position.x + 1.25f, player.transform.position.y + 2.5f, 0);

		if(hit){

			GetComponent<LineRenderer>().SetPosition(0, player.transform.position);
			GetComponent<LineRenderer>().SetPosition(1, point);

		}

	}

	void OnCollisionStay (Collision col) {

		if(col.gameObject.tag == "Platform"){

			if(!hit && PlayerMovement.ropeActive){

				GetComponent<AudioSource>().PlayOneShot(swing);
				point = new Vector3(col.contacts[0].point.x, col.gameObject.transform.position.y - 0.5f, 0);
				hit = true;
				if(point.x < player.transform.position.x){
					hit = false;
				}

			}

		}

	}
}
