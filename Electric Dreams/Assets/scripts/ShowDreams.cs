using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowDreams : MonoBehaviour {

	public GameData gameData;
	public PlayerData playerData;

	public Button previousDreamButton;
	public Button nextDreamButton;

	public Text dreamDescription;

	public int currentDreamIndex = 0;

	void Start () {
		gameData = GameObject.Find ("GameData").GetComponent<GameData> ();
		playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();

		previousDreamButton.onClick.AddListener (delegate { Decrement(); });
		nextDreamButton.onClick.AddListener (delegate { Increment(); }); 

		dreamDescription.text = gameData.playerDreams [(4 * (playerData.playerNumber - 1)) + currentDreamIndex];
	}

	// Update is called once per frame
	void Update () {
		/* Abilita/Disabilita i pulsanti in base al sogno che sto mostrando */
		if (currentDreamIndex == 0)
			previousDreamButton.enabled = false;
		else 
			previousDreamButton.enabled = true;

		if (currentDreamIndex == 3)
			nextDreamButton.enabled = false;
		else 
			nextDreamButton.enabled = true;
	}

	void Increment () {
		currentDreamIndex++;
		dreamDescription.text = gameData.playerDreams [(4 * (playerData.playerNumber - 1)) + currentDreamIndex];
	}

	void Decrement () {
		currentDreamIndex--;
		dreamDescription.text = gameData.playerDreams [(4 * (playerData.playerNumber - 1)) + currentDreamIndex];
	}
}
