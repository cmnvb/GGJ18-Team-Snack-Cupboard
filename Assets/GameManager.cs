using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private int currentTask;
	private int fails;

	private int secondsLeft;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WonTask() {
		currentTask++;
		GetComponent<InstructionManager>().NewInstructions("won");
	}

	public void FailedTask() {
		currentTask++;
		fails++;

		if (fails >= 3) {
			Debug.Log("YOU LOSE");
		}

		GetComponent<InstructionManager>().NewInstructions("failed");
	}

	public int GetCurrentTask() {
		return currentTask;
	}

	public int GetFails() {
		return fails;
	}

	public int GetWins() {
		return currentTask - fails;
	}

	public void StartCountDown() {
		StartCoroutine("CountDownTimer");
	}

	public void StopCountDown() {
		StopCoroutine("CountDownTimer");
	}

	private IEnumerator CountDownTimer() {
		secondsLeft = 60;
		while (secondsLeft > 0) {
			yield return new WaitForSeconds(1);
			secondsLeft--;
		}
	}
}
