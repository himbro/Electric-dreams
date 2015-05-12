using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public string playerName;

	public Text nameField;
	
	void Awake () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName () {
		if (nameField.text.Length != 0) {
			this.playerName = nameField.text.ToString ();
		}	
		else {
			this.playerName = "Guest" + Random.Range(1, 9999);
		}
	}
}
