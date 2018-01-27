using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject timer;

	private const int TOTAL_TASKS = 10;
	private const int FAIL_LIMIT = 3;
	private const int SECONDS_PER_TASK = 20;
	private int currentTask = 1;
	private int fails = 0;
	private int secondsLeft = 60;

	private InstructionManager IMngr;
	public static GameManager gameManager;

	/// <summary>
	/// Singleton pattern to store reference to game manager
	/// </summary>
	void Awake()
	{
		if (gameManager == null)
		{
			gameManager = this;
		}
		else { Destroy(gameObject); }
	}

	// Use this for initialization
	void Start () {
		IMngr = GetComponent<InstructionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UsedItem(Actions.Verbs _verb, Actions.Colour _colour, Actions.Interactable _interactable) {
		Debug.Log("Item used: " + _verb.ToString() + ", " + _colour.ToString() + ", " + _interactable.ToString());
		
		if (    _verb == IMngr.verb     &&
				_colour == IMngr.colour   &&
				_interactable == IMngr.interactable) {
			currentTask++;
			Debug.Log("success");

			if (currentTask >= 10) {
				Debug.Log("GAME FINISHED");
				SceneManager.LoadScene("MainMenu");
			} else {
				GetComponent<InstructionManager>().NewInstructions("won");
				StopCoroutine("CountDownTimer");
			}
		}
		else
		{

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

	public void StopGas() {
		StopCoroutine("GasTimer");
		GameObject[] gasParticles = GameObject.FindGameObjectsWithTag("GasEffect");
		foreach (GameObject particle in gasParticles) {
			particle.GetComponent<ParticleSystem>().Stop();
		}
		GameObject.FindGameObjectsWithTag("Alarm1")[0].GetComponent<AudioSource>().Stop();
	}

	private void StartGas() { // NO TIMER FOR GAS
		StartCoroutine("GasTimer");
		GameObject[] gasParticles = GameObject.FindGameObjectsWithTag("GasEffect");
		foreach (GameObject particle in gasParticles) {
			particle.GetComponent<ParticleSystem>().Play();
		}
		GameObject.FindGameObjectsWithTag("Alarm1")[0].GetComponent<AudioSource>().Play();
	}

	private void Fire() {

	}

	private IEnumerator CountDownTimer() {
		secondsLeft = SECONDS_PER_TASK;
		while (secondsLeft > 0) {
			yield return new WaitForSeconds(1);
			secondsLeft--;
			timer.GetComponent<Text>().text = secondsLeft.ToString();
		}

		fails++;
		GetComponent<InstructionManager>().NewInstructions("failed");

		if (fails == 1) {
			StartGas();
		} else if (fails == 2) {
			GameObject.FindGameObjectsWithTag("DebrisSpawner")[0].GetComponent<DebrisSpawner>().SpawnDebris();
			GameObject.FindGameObjectsWithTag("Alarm2")[0].GetComponent<AudioSource>().Play();
		} else if (fails >= FAIL_LIMIT) {
			GameObject.FindGameObjectsWithTag("Alarm3")[0].GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(7);
			GameObject.FindGameObjectsWithTag("Alarm2")[0].GetComponent<AudioSource>().Stop();
			GameObject.FindGameObjectsWithTag("Alarm3")[0].GetComponent<AudioSource>().Stop();
			//SceneManager.LoadScene("MainMenu");
		}
	}

	private IEnumerator GasTimer() {
		yield return new WaitForSeconds(10);
		SceneManager.LoadScene("MainMenu");
	}
}


public class Actions
{
	public enum Verbs { PUSH, PULL, ROTATE, SLIDE};
	public enum Colour { RED, BLUE, GREEN, YELLOW };
	public enum Interactable { BUTTON, LEVER, SLIDER, DIAL };

}
