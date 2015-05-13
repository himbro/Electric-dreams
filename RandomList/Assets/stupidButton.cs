using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class stupidButton : MonoBehaviour {

	public Button theButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.A)) {
			theButton.interactable = true;
		}
	}
}
