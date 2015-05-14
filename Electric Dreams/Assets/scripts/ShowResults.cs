using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowResults : MonoBehaviour {

	public Replicants replicants;

	public Text[] replicantList = new Text[2];

	void Awake () {
		replicants = GameObject.Find ("Replicants").GetComponent<Replicants> ();

		/* Show the list of replicants */
		ShowReplicants ();
	}
	
	void ShowReplicants() {
		/* Show the list of resulting replicants */
		int i = 0;
		
		foreach (string player in replicants.replicantNames) {
			replicantList[i].text = replicants.name;
			i++;
		}
	}
}
