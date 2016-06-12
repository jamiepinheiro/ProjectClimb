using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject rope;
	public AudioClip jump, ground;
	public static float currentY;
	public static bool ropeActive = false;
	float oldX = 5;
	int jumpNum = 0;

	// Use this for initialization
	void Start () {
		currentY = 0;
		oldX = 5;
		jumpNum = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(Game.playing){

			if(!Game.gameOver){

				if(transform.position.x > oldX){
					oldX += 10;
					currentY++;
					if(currentY % 3 == 0){
						Background.backgroundColor = Background.GetRandomColor();
					}
				}

				if(transform.position.y < currentY - 3){
					Game.gameOver = true;
				}

				if(!Rope.hit){

					GetComponent<Rigidbody>().velocity = new Vector3(7.5f, GetComponent<Rigidbody>().velocity.y, 0);

					if(Input.GetMouseButtonDown(0)){

						if(Input.mousePosition.x > Screen.width/2){

							ropeActive = false;

							if(GetComponent<Rigidbody>().velocity.y == 0){
								jumpNum ++;
								GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
								GetComponent<Rigidbody>().AddForce(new Vector3(0, 3000, 0));
								GetComponent<AudioSource>().PlayOneShot(jump);
							}else if(jumpNum < 2){
								jumpNum ++;
								GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
								GetComponent<Rigidbody>().AddForce(new Vector3(0, 3000, 0));
								GetComponent<AudioSource>().PlayOneShot(jump);
							}

						}else{

							ropeActive = true;

						}

					}

				}else{

					GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
					transform.RotateAround(Rope.point, Vector3.forward, 150 * Time.deltaTime);

					if(Input.GetMouseButtonUp(0)){

						GameObject.FindGameObjectWithTag("Rope").GetComponent<LineRenderer>().SetPosition(0, transform.position);
						GameObject.FindGameObjectWithTag("Rope").GetComponent<LineRenderer>().SetPosition(1, transform.position);
						ropeActive = false;
						Rope.hit = false;
						
					}

				}

			}else{

				GetComponent<Rigidbody>().useGravity = false;
				GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
				GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)));

				if(GameObject.FindGameObjectWithTag("Rope") != null){
					GameObject.FindGameObjectWithTag("Rope").GetComponent<LineRenderer>().SetPosition(0, transform.position);
					GameObject.FindGameObjectWithTag("Rope").GetComponent<LineRenderer>().SetPosition(1, transform.position);
					ropeActive = false;
					Rope.hit = false;
				}

			}

		}
	
	}


	void OnCollisionEnter (Collision col){

		if(col.gameObject.tag == "Platform"){
			if(jumpNum != 0){
				GetComponent<AudioSource>().PlayOneShot(ground);
			}
			jumpNum = 0;
			if(col.gameObject.transform.position.y + 0.5f> transform.position.y){
				GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				Game.gameOver = true;
			}
		}

		if(col.gameObject.tag == "Enemy"){
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			Game.gameOver = true; 
		}

	}

}
