using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Tale classe serve per contenere il tempo.
 * */

public class TimeManager : Photon.MonoBehaviour 
{
	/* we want a 3-minutes timer */
	public int timeRemaining = 180; 

	/* GUI values */
	public int guiMinutes;
	public int guiSeconds;
	public string stringSeconds;

	/* The Timer OnScreen */
	public Text guiTimer;
	
	// Use this for initialization
	void Start () 
	{
		/* Decrease the timer by 1 second every seconds */
		guiMinutes = 3;
		guiSeconds = 0;
		/* we want 2 decimals */
		stringSeconds = "0" + guiSeconds.ToString ();
		guiTimer.text = string.Format ("{0}:{1}", guiMinutes, stringSeconds);

		/* Only the master client manages the time */
		if (PhotonNetwork.isMasterClient)
			InvokeRepeating ("DecreaseTimer", 1, 1);
	}

	void Update () {
		/* Calculate the minutes for the UI */
		guiMinutes = timeRemaining / 60;
		if (guiMinutes < 0) guiMinutes = 0;
		/* Calculate the seconds for the UI */
		guiSeconds = timeRemaining % 60;
		if (guiSeconds < 0) guiSeconds = 0;
		
		if (guiSeconds >= 10) {
			stringSeconds = guiSeconds.ToString();
		}
		else {
			stringSeconds = "0" + guiSeconds.ToString();
		}

		guiTimer.text = string.Format ("{0}:{1}", guiMinutes, stringSeconds);
		
		/* Check if time elapsed */		
		if (timeRemaining < 0)
			Invoke ("TimeElapsed", 1);
	}

	[RPC] void DecreaseTimer () {
		/* Decrease the remaining time */
		timeRemaining -= 1;
		if (PhotonNetwork.isMasterClient) 
			photonView.RPC("DecreaseTimer", PhotonTargets.OthersBuffered);
	}

	void TimeElapsed () {
		Application.LoadLevel (4);
	}
}