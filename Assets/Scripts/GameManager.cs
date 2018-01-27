using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private const int TOTAL_TASKS = 10;
	private const int FAIL_LIMIT = 3;
	private int currentTask;
	private int fails;
	private int secondsLeft;

	private string[] verbs = new string[]{"slide", "pull", "rotate", "push"};
	private string[] adjectives = new string[]{"red", "green", "yellow", "blue"};
	private string[] nouns = new string[]{"lever", "button", "dial", "slider"};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UsedItem(string itemUsed) {
		currentTask++;
		if (itemUsed.ToLower() == verbs[GetComponent<InstructionManager>().instructions[0]]
			+ adjectives[GetComponent<InstructionManager>().instructions[1]]
			+ nouns[GetComponent<InstructionManager>().instructions[2]]) {

			if (currentTask >= 10) {
				Debug.Log("GAME FINISHED");
				SceneManager.LoadScene("WinScreen");
			} else {
				GetComponent<InstructionManager>().NewInstructions("won");
				StopCoroutine("CountDownTimer");
			}
		} else {
			fails++;

			if (fails >= FAIL_LIMIT) {
				Debug.Log("YOU LOSE");
				SceneManager.LoadScene("GameOver");
			} else {
				GetComponent<InstructionManager>().NewInstructions("failed");
			}

		}

		Debug.Log(currentTask + " " + fails);
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

	private IEnumerator CountDownTimer() {
		secondsLeft = 60;
		while (secondsLeft > 0) {
			yield return new WaitForSeconds(1);
			secondsLeft--;
		}
	}
}
