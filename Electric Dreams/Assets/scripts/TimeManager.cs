using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Tale classe serve per contenere il tempo.
 * */

public class TimeManager : MonoBehaviour 
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

		InvokeRepeating ("DecreaseTimer", 1, 1);
	}

	void DecreaseTimer () {
		guiTimer.text = string.Format ("{0}:{1}", guiMinutes, stringSeconds);
		/* Decrease the remaining time */
		timeRemaining -= 1;
		/* Calculate the minutes for the UI */
		guiMinutes = timeRemaining / 60;
		/* Calculate the seconds for the UI */
		guiSeconds = timeRemaining % 60;

		if (guiSeconds >= 10) {
			stringSeconds = guiSeconds.ToString();
		}
		else {
			stringSeconds = "0" + guiSeconds.ToString();
		}

		/* Check if time elapsed */
		if (timeRemaining < 0)
			Invoke ("TimeElapsed", 1);
	}

	void TimeElapsed () {
		Application.LoadLevel (5);
	}
}