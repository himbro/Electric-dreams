using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class voteIt : MonoBehaviour {

	public PlayerData playerData;

	public int votes;

	public Text[] playerList = new Text[6];

	void Awake () {
		/* Stop the automatic sync of scenes */
		PhotonNetwork.automaticallySyncScene = false;

		playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> () as PlayerData;
		
		/* Show the list of players */
		ShowPlayers ();

		votes = 0;
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
