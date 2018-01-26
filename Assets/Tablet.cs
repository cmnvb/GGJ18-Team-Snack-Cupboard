using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {
	private GameObject verb;
	private GameObject adjective;
	private GameObject noun;

	public Material[] symbols = new Material[4];

	// Use this for initialization
	void Awake () {
		verb = transform.GetChild(0).gameObject;
		adjective = transform.GetChild(1).gameObject;
		noun = transform.GetChild(2).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void printInstruction(int[] instructions) {
		verb.GetComponent<Renderer>().material = symbols[instructions[0]];
		adjective.GetComponent<Renderer>().material = symbols[instructions[1]];
		noun.GetComponent<Renderer>().material = symbols[instructions[2]];
	}
}
