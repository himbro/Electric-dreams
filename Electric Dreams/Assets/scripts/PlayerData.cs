using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public string playerName;
	public int playerNumber;
	public bool isReplicant;

	public Text nameField;
	
	void Awake () {
		DontDestroyOnLoad (this);
		isReplicant = false;
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
