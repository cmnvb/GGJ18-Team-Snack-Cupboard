using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject timer;

	private const int TOTAL_TASKS = 10;
	private const int FAIL_LIMIT = 3;
	private int currentTask;
	private int fails;
	private int secondsLeft;

	private string[] verbs = new string[]{"slide", "pull", "rotate", "push"};
	private string[] adjectives = new string[]{"red", "green", "yellow", "blue"};
	private string[] nouns = new string[]{"lever", "button", "dial", "slider"};

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
		currentTask++;
		if (    _verb.ToString().ToLower() == verbs[IMngr.Instructions[0]]     &&
                _colour.ToString().ToLower() == adjectives[IMngr.Instructions[1]]   &&
                _interactable.ToString().ToLower() == nouns[IMngr.Instructions[2]]) {

			if (currentTask >= 10) {
				Debug.Log("GAME FINISHED");
				SceneManager.LoadScene("WinScreen");
			} else {
				GetComponent<InstructionManager>().NewInstructions("won");
				StopCoroutine("CountDownTimer");
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
			timer.GetComponent<Text>().text = secondsLeft.ToString();
		}

		fails++;

		if (fails >= FAIL_LIMIT) {
			Debug.Log("YOU LOSE");
			SceneManager.LoadScene("GameOver");
		} else {
			GetComponent<InstructionManager>().NewInstructions("failed");
		}
	}
}


public class Actions
{
    public enum Verbs { PUSH, PULL, ROTATE, SLIDE};
    public enum Colour { RED, BLUE, GREEN, YELLOW };
    public enum Interactable { BUTTON, LEVER, SLIDER, DIAL };

}
