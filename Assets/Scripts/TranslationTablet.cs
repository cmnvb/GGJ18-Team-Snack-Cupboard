using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationTablet : MonoBehaviour {

	public GameObject[] screens;
	public float transitionTime;
	public float amountToMove;
	public float speed;

	int currentScreen;
	bool moving;
	Vector3 startPos;
	Vector3 newPos;
	float accumulationTime = 0;


	void Start(){
		startPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

		if(moving){
			transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, Time.deltaTime * speed);
			if(Vector3.Distance(transform.localPosition,newPos) < .1){
				transform.localPosition = newPos;
				moving = false;
			}
//			transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, Mathf.SmoothStep(0, 1, accumulationTime/transitionTime));
//			accumulationTime += Time.deltaTime;

		}

	}

	public void MoveLeft(){
		if(currentScreen < screens.Length - 1){
			currentScreen += 1;
			moving = true;
			newPos = new Vector3(amountToMove * currentScreen, 0, 0);
			accumulationTime = 0;
		}
	}

	public void MoveRight(){
		
		if(currentScreen > 0){
			currentScreen -= 1;
			moving = true;
			newPos = new Vector3(amountToMove * currentScreen, 0, 0);
			accumulationTime = 0;
		}
	}

}
