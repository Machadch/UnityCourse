using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer Instance = null;
	
	void Awake() {
	print ("Music Awake: " + GetInstanceID());
		if (Instance != null) {
			Destroy(gameObject);
		} else {
			Instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	
	// Use this for initialization
	void Start () {

	}
		
	// Update is called once per frame
	void Update () {
	
	}
}

