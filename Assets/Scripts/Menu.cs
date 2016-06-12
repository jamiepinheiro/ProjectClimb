using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MusicButton (Button button) {

		ColorBlock cb = button.colors;

		if(AudioListener.volume == 1.0f){
			AudioListener.volume = 0.0f;
			cb.highlightedColor =  new Color(1, 1, 1, 0.6f);

		}else{
			AudioListener.volume = 1.0f;
			cb.highlightedColor =  Color.white;
		}

		button.colors = cb;

	}

	public void PlayButton () {

		Game.playing = true;

	}

	public void RateButton () {

		Application.OpenURL(GlobalSettings.storeLink);

	}

	public void Help () {
		
		Application.LoadLevel("Tutorial");
		
	}
}
