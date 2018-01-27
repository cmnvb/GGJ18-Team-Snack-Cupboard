using System.Collections;
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

	private string[] verbs = new string[]{"slide", "pull", "rotate", "push"}; // Delete
	private string[] adjectives = new string[]{"red", "green", "yellow", "blue"};
	private string[] nouns = new string[]{"lever", "button", "dial", "throttle"}; // Later

	public GameObject speaker;

	public int[] instructions = new int[3]; //verb, adjective, noun

	// Use this for initialization
	void Start () {
		NewInstructions();
		StartCoroutine("NewInstructionsRepeat");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void NewInstructions(string lastTaskOutcome = "won") {
		CreateInstructions();
		speaker.GetComponent<Speaker>().sayIntro(instructions, lastTaskOutcome);
	}

	private void CreateInstructions() {
		instructions[0] = Random.Range(0, VERB_COUNT);
		instructions[1] = Random.Range(0, ADJECTIVE_COUNT);
		instructions[2] = Random.Range(0, NOUN_COUNT);
	}

	private IEnumerator NewInstructionsRepeat() { // DELETE LATER
		while (true) {
			if (Random.Range(0, 1f) < 0.5f) {
				GetComponent<GameManager>().UsedItem(verbs[GetComponent<InstructionManager>().instructions[0]]
			+ adjectives[GetComponent<InstructionManager>().instructions[1]]
			+ nouns[GetComponent<InstructionManager>().instructions[2]]);
			} else {
				GetComponent<GameManager>().UsedItem(verbs[GetComponent<InstructionManager>().instructions[0]]
			+ adjectives[GetComponent<InstructionManager>().instructions[1]]
			+ nouns[GetComponent<InstructionManager>().instructions[2]]);
			}
			yield return new WaitForSeconds(10);
		}
	}
}
