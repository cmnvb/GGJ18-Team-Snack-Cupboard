using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	public GameObject console;
	public GameObject managerCollection;
	public AudioClip[] intros = new AudioClip[10];
	public AudioClip[] failIntros = new AudioClip[3];
	public AudioClip[] verbs = new AudioClip[4];
	public AudioClip[] adjectives = new AudioClip[4];
	public AudioClip[] nouns = new AudioClip[4];

	private int[] instructions;
	private AudioSource speaker;

	// Use this for initialization
	void Awake() {
		speaker = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void sayIntro(int[] instructions, string lastTaskOutcome) {
		this.instructions = instructions;
		if (lastTaskOutcome != "failed") {
			speaker.clip = intros[managerCollection.GetComponent<GameManager>().GetCurrentTask()];
		} else {
			speaker.clip = failIntros[managerCollection.GetComponent<GameManager>().GetFails()];
		}
		speaker.Play();
		StartCoroutine("AfterIntro");
	}

	private void UpdateConsole() {
		console.GetComponent<Console>().printInstruction(instructions);
	}

	private IEnumerator AfterIntro() {
		yield return new WaitForSeconds(speaker.clip.length);
		speaker.clip = verbs[instructions[0]];
		speaker.Play();
		yield return new WaitForSeconds(verbs[instructions[0]].length);
		speaker.clip = adjectives[instructions[1]];
		speaker.Play();
		yield return new WaitForSeconds(adjectives[instructions[1]].length);
		speaker.clip = nouns[instructions[2]];
		speaker.Play();
		managerCollection.GetComponent<GameManager>().StartCountDown();
		UpdateConsole();
	}
}
