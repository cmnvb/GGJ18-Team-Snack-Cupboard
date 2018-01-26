using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {
	public GameObject tablet;
	public AudioClip[] intros = new AudioClip[3];
	public AudioClip[] symbols = new AudioClip[3];

	private int currentIntro = 0;

	private int[] instructions;
	private AudioSource speaker;

	// Use this for initialization
	void Start () {
		speaker = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sayInstruction(int[] instructions) {
		this.instructions = instructions;
		speaker.clip = intros[currentIntro];
		speaker.Play();
		StartCoroutine("CheckStillIntro");
	}

	private void UpdateTablet() {
		tablet.GetComponent<Tablet>().printInstruction(instructions);
	}

	private IEnumerator CheckStillIntro() {
		yield return new WaitForSeconds(intros[currentIntro].length);
		speaker.clip = symbols[0];
		speaker.Play();
		UpdateTablet();
		currentIntro++;
	}
}
