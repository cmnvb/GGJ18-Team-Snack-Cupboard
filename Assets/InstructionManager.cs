﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *ACTIONS - Start with BLER
 *Slide = bler-skoon, Pull = bler-shick, Rotate = bler-merl, Push = bler-fresk
 *
 *DESCRIPTIONS - end with ERN
 *Red = ting-ern, Green = lend-ern, Yellow = wolt-ern, Blue = zun-ern,
 *
 *OBJECTS - Have MIK in the middle
 *Lever = gren-mik-to, Button = Com-mik-do, Dial = pring-mik-ha, Throttle = ad-mik-mi
 */

public class InstructionManager : MonoBehaviour {
	private const int VERB_COUNT = 4;
	private const int ADJECTIVE_COUNT = 4;
	private const int NOUN_COUNT = 4;

	public GameObject speaker;

	private int[] instructions = new int[3]; //verb, adjective, noun

	// Use this for initialization
	void Start () {
		StartCoroutine("SendInstruction");
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void CreateInstructions() {
		instructions[0] = Random.Range(0, VERB_COUNT);
		instructions[1] = Random.Range(0, ADJECTIVE_COUNT);
		instructions[2] = Random.Range(0, NOUN_COUNT);
	}

	private void SendToSpeaker() {
		speaker.GetComponent<Speaker>().sayInstruction(instructions);
	}

	public void NewInstructions() {
		CreateInstructions();
		SendToSpeaker();
	}

	private IEnumerator SendInstruction() { // DELETE LATER
		while (true) {
			NewInstructions();
			yield return new WaitForSeconds(10);
		}
	}
}