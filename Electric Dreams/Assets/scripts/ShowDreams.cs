using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowDreams : MonoBehaviour {

	public DreamList dreamList;

	public Button previousDreamButton;
	public Button nextDreamButton;

	public Text dreamDescription;

	public int currentDreamIndex = 0;

	void Start () {
		dreamList = GameObject.Find ("GameData").GetComponent<DreamList> ();

		previousDreamButton.onClick.AddListener (delegate { Decrement(); });
		nextDreamButton.onClick.AddListener (delegate { Increment(); }); 

		dreamDescription.text = dreamList.player1Dreams [0];
	}

	// Update is called once per frame
	void Update () {
		/* Abilita/Disabilita i pulsanti in base al sogno che sto mostrando */
		if (currentDreamIndex == 0)
			previousDreamButton.enabled = false;
		else 
			previousDreamButton.enabled = true;

		if (currentDreamIndex == (dreamList.player1Dreams.Count - 1))
			nextDreamButton.enabled = false;
		else 
			nextDreamButton.enabled = true;


	}

	void Increment () {
		currentDreamIndex++;
		dreamDescription.text = dreamList.player1Dreams [currentDreamIndex];
	}

	void Decrement () {
		currentDreamIndex--;
		dreamDescription.text = dreamList.player1Dreams [currentDreamIndex];
	}
}
