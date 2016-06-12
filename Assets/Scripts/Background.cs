using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public static Color backgroundColor = new Color(0, 0, 0);
	Color color = new Color(0, 0, 0);

	// Use this for initialization
	void Start () {

		color = new Color(0, 0, 0);
		backgroundColor = GetRandomColor();

	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.GetComponent<Camera>().backgroundColor = color;
		color = Color.Lerp(color, backgroundColor, 3 * Time.deltaTime);

	}

	public static Color GetRandomColor (){

		float r = 0, g = 0, b = 0;

		float rand = Random.Range(0, 2);
		float rand2 = Random.Range(50.0f, 150.0f);

		if(rand == 0){
			r = (55.0f/255.0f);
			g = (rand2/255.0f);
			b = ((200-rand2)/255.0f);
		}else if(rand == 1){
			g = (55.0f/255.0f);
			r = (rand2/255.0f);
			b = ((200-rand2)/255.0f);
		}else if(rand == 1){
			b = (55.0f/255.0f);
			g = (rand2/255.0f);
			r = ((200-rand2)/255.0f);
		}

		return new Color(r, g, b);

	}
}
