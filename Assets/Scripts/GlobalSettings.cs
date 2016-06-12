using UnityEngine;
using System.Collections;
using ChartboostSDK;

public class GlobalSettings : MonoBehaviour {
	
	public static string storeLink;
	public string GooglePlayLink, AmazonLink, IosLink, AmazonAppId;
	public enum storeOptions {GooglePlay, Amazon, Ios};
	public storeOptions store;
	
	private static GlobalSettings instance = null;
	public static GlobalSettings Instance {
		get { return instance; }
	}
	
	float timer = 0;
	
	// Use this for initialization
	void Start () {
		
		timer = 0;
		if(store ==  storeOptions.GooglePlay){
			storeLink = GooglePlayLink;
		}else if(store == storeOptions.Amazon){
			storeLink = AmazonLink;
		}else if(store == storeOptions.Ios){
			storeLink = IosLink;
		}
		
		if(PlayerPrefs.GetInt("AdsRemoved") != 1){
			Chartboost.cacheInterstitial(CBLocation.Default);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		if(timer > 1.5f && Application.loadedLevel == 0){
			if(PlayerPrefs.GetInt("GamesPlayed") != 0){
				Application.LoadLevel("Game");
			}else{
				Application.LoadLevel("Tutorial");
			}
			if(PlayerPrefs.GetInt("GamesPlayed") > 5){
				ShowAd();
			}
		}
		
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		}else{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	public static void ShowAd () {
		
		if(PlayerPrefs.GetInt("AdsRemoved") != 1){
			
			if(Chartboost.hasInterstitial(CBLocation.Default)){
				Chartboost.showInterstitial(CBLocation.Default);
				Chartboost.cacheInterstitial(CBLocation.Default);
			}
		}
		
	}
	
}
