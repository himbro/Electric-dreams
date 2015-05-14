using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Replicants : Photon.MonoBehaviour {

	/* The list of replicant names */
	public List<string> replicantNames = new List<string> ();

	public PlayerData playerData;
	public GameData gameData;

	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Update is called once per frame
	void Start () {

		playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		gameData = GameObject.Find ("GameData").GetComponent<GameData> ();

		if (playerData.playerNumber == gameData.playerNumbers [0] || playerData.playerNumber == gameData.playerNumbers [1]) {
			replicantNames.Add (playerData.playerName);
			Debug.Log ("I am a replicant!");
			playerData.isReplicant = true;
		}
		else 
			Debug.Log ("I am NOT a replicant!");
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting)
			stream.SendNext(replicantNames);
		else
			replicantNames = (List<string>)stream.ReceiveNext();
	}
}
