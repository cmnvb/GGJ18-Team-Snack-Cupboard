using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMask : MonoBehaviour {
	private GameObject managerCollection;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Head") {
			Destroy(this.gameObject);
			managerCollection.GetComponent<GameManager>().StopGas(); // Fix to actually call gm
		}
	} 
}
