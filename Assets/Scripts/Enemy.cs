using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float startX = 0;
	bool right = true;

	// Use this for initialization
	void Start () {

		startX = transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(right){

			if(transform.position.x < startX + 8){
				GetComponent<Rigidbody>().velocity = new Vector3(1, GetComponent<Rigidbody>().velocity.y, 0);
			}else{
				right = false;
			}

		}else{

			if(transform.position.x > startX){
				GetComponent<Rigidbody>().velocity = new Vector3(-1, GetComponent<Rigidbody>().velocity.y, 0);
			}else{
				right = true;
			}

		}

	}
}
