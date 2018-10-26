using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorButton : MonoBehaviour {
	public GameObject door1,door2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (!door1.GetComponent<Door> ().getAtivar()) {
			door1.GetComponent<Door> ().setAtivar (true);
			door2.GetComponent<Door> ().setAtivar (true);
		}else if (door1.GetComponent<Door> ().getAtivar()) {
			door1.GetComponent<Door> ().setAtivar (false);
			door2.GetComponent<Door> ().setAtivar (false);
		}
	}
}
