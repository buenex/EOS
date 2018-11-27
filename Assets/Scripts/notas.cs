using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notas : MonoBehaviour {
	public Text txtNota;
	public string text;
	public static bool permite;

	// Use this for initialization
	void Start () {
		permite = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			permite = true;
			txtNota.text = text;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			permite = false;
		}
	}
}
