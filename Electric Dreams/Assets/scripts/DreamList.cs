using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DreamList : MonoBehaviour {

	public List<string> player1Dreams = new List<string> ();

	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		player1Dreams.Add ("Dream 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
		player1Dreams.Add ("Dream 2 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
		player1Dreams.Add ("Dream 3 Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
