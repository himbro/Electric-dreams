using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Replicants : Photon.MonoBehaviour {

	/* The list of replicant names */
	public List<string> replicantNames = new List<string> ();

	public PlayerData playerData;
	public GameData gameData;
	
	// Update is called once per frame
	void Start () {

		playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		gameData = GameObject.Find ("GameData").GetComponent<GameData> ();

		if (playerData.playerNumber == gameData.playerNumbers [0] || playerData.playerNumber == gameData.playerNumbers [1])
			replicantNames.Add (playerData.playerName);
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting)
			stream.SendNext(replicantNames);
		else
			replicantNames = (List<string>)stream.ReceiveNext();
	}
}
