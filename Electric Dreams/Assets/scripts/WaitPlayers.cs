using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitPlayers : MonoBehaviour {
	
	public Text[] playerList = new Text[6];

	public Button startButton;

	public void Awake()
	{
		// in case we started this demo with the wrong scene being active, simply load the menu scene
		if (!PhotonNetwork.connected)
		{
			Application.LoadLevel(2);
			return;
		}
		
		// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
		//PhotonNetwork.Instantiate(this.playerPrefab.name, transform.position, Quaternion.identity, 0);
	
		int i = 0;

		foreach (PhotonPlayer player in PhotonNetwork.playerList) {
			playerList[i].text = player.name;
			i++;
		}


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.playerList.Length == 2)
			startButton.enabled = true;
		Debug.Log (PhotonNetwork.playerList.Length);
	}
}
