using UnityEngine;
using System.Collections;

public class RandomList : MonoBehaviour {

	public string[] myArray = new string[5];

	// Use this for initialization
	void Start () {
		myArray [0] = "a";
		myArray [1] = "b";
		myArray [2] = "c";
		myArray [3] = "d";
		myArray [4] = "e";

		Shuffle (myArray);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shuffle (string[] a) {
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
}
