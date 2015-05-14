using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitPlayers : MonoBehaviour {

	public PlayerData playerData;

	public Text[] playerList = new Text[6];

	public Button startButton;

	public void Awake()
	{
		playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> () as PlayerData;

		/* Show the list of players */
		ShowPlayers ();

		/* Set a number for the player */
		playerData.playerNumber = PhotonNetwork.room.playerCount;

		/* Disable the button if is not the master client */
		if (!PhotonNetwork.isMasterClient) {
			startButton.gameObject.SetActive (false);
		}
		else startButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("I'm the player number " + playerData.playerNumber);

		/* Refresh players list */
		ShowPlayers ();

		if (PhotonNetwork.room.playerCount == 1 && PhotonNetwork.isMasterClient)
			startButton.interactable = true;
	}

	void ShowPlayers () {
		/* Show the list of connected players */
		int i = 0;
		
		foreach (PhotonPlayer player in PhotonNetwork.playerList) {
			playerList[i].text = player.name;
			i++;
		}
	}
}
