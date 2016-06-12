using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	
	public GameObject[] tutorials;
	int tutorialNumber = 0;
	float tutorialTimer = 0;
	
	// Use this for initialization
	void Start () {
		tutorialNumber = 0;
		tutorialTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		tutorialTimer += Time.deltaTime;

		if(tutorialTimer > 1){

			if(Input.GetMouseButtonUp(0)){

				tutorialNumber ++;
				tutorialTimer = 0;

			}

		}

		if(tutorialNumber > tutorials.Length - 1){

			Application.LoadLevel("Game");

		}

		for(int i = 0; i < tutorials.Length; i++){

			if(i != tutorialNumber){
				tutorials[i].SetActive(false);
			}else{
				tutorials[i].SetActive(true);
			}

		}
				
	}
}
