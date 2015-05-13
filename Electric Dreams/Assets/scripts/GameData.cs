using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : Photon.MonoBehaviour {

	public string[] playerDreams;
	public int[] playerNumbers;

	void Awake () {
		DontDestroyOnLoad (this);
	}

	public void Shuffle (string[] a) {
		/* Uses the Fisher-Yates algorithm to shuffle the array */
		/* Loops through the array */
		for (int i = a.Length - 1; i > 0; i--) {
			
			/* Radomizes a number between 0 and i - the range decreases each time */
			int rnd = Random.Range (0, i);
			
			/* Save the value of the current i */
			string temp = a[i];
			
			/* Swap the new and old values */
			a[i] 	= a[rnd];
			a[rnd] 	= temp;
		}
	}

	public void ShuffleInt (int[] a) {
		/* Uses the Fisher-Yates algorithm to shuffle the array */
		/* Loops through the array */
		for (int i = a.Length - 1; i > 0; i--) {
			
			/* Radomizes a number between 0 and i - the range decreases each time */
			int rnd = Random.Range (0, i);
			
			/* Save the value of the current i */
			int temp = a[i];
			
			/* Swap the new and old values */
			a[i] 	= a[rnd];
			a[rnd] 	= temp;
		}
	}


	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting)
			stream.SendNext(playerDreams);
		else
			playerDreams = (string[])stream.ReceiveNext();
	}
}
