using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	float y = 0;
	float startX, startY;

	// Use this for initialization
	void Start () {
	
		y = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if(!Game.gameOver){
	
			transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + 5, y, transform.position.z);

			y = Mathf.Lerp(y, PlayerMovement.currentY + 3, 10 * Time.deltaTime);

			startX = transform.position.x;
			startY = transform.position.y;

		}else{

			startX = Mathf.Lerp(startX, GameObject.FindGameObjectWithTag("Player").transform.position.x, 2 * Time.deltaTime);
			startY = Mathf.Lerp(startY, GameObject.FindGameObjectWithTag("Player").transform.position.y, 100 * Time.deltaTime);

			transform.position = new Vector3(startX, startY, transform.position.z);

			if(GetComponent<Camera>().fieldOfView > 40){
				GetComponent<Camera>().fieldOfView -=  10 * Time.deltaTime;
			}

		}

	}
}
