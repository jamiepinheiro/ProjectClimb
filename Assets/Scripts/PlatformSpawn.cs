using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {

	public GameObject platform, enemy;
	float y = 0;
	float x = 0;
	float timer = 100;

	// Use this for initialization
	void Start () {
		y = 0;
		x = 0;
		timer = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if(Game.playing && !Game.gameOver){

			timer += Time.deltaTime;

			if(timer > 10){

				float max = x + 100;

				for(float xPos = x; xPos < max; xPos += 10){

					if(Random.Range(0.0f, 1.0f) > 0.5f){
						Instantiate(platform, new Vector3(xPos, y, 0), Quaternion.Euler(0, 0, 0));
						if(Random.Range(0.0f, 1.0f) > 0.6f){
							Instantiate(enemy, new Vector3(xPos - 5, y + 3, 0), Quaternion.Euler(0, 0, 0));
						}
					}else{
						Instantiate(platform, new Vector3(xPos, y + 5, 0), Quaternion.Euler(0, 0, 0));
					}

					y++;

				}

				x += 100;

				timer = 0;

			}

		}
	
	}
}
