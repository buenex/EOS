using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCol : MonoBehaviour {
	public static GameObject card,pilha;
	public notas notinha;
	public GameObject ajuda;
	public static bool pegaPilha =false;
	// Use this for initialization
	void Start () {
		card = null;
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "cartao" ) {
			int.TryParse(col.gameObject.name,out GameController.item);
			GameController.pegaItem = true;
			GameController.colocaItem = true;
			card = col.gameObject;
			ajuda.SetActive (true);
		}
		if (col.tag == "nota") {
			notas.permite = true;
			ajuda.SetActive (true);

		}if(col.tag=="reator"){
			Reator.liga=true;
			ajuda.SetActive (true);	
		}
		if(col.tag=="pilha"){
			pegaPilha=true;
			pilha=col.gameObject;
			ajuda.SetActive (true);	
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "cartao") {
			GameController.pegaItem = false;
			GameController.colocaItem = false;
			card = null;
			notas.permite = false;
			ajuda.SetActive (false);
		}if (col.tag == "nota") {
			ajuda.SetActive (false);
		}
		if(col.tag=="reator"){
			Reator.liga=false;	
			ajuda.SetActive (false);	
		}
		if(col.tag=="pilha"){
			pegaPilha=false;
			ajuda.SetActive (false);	
		}
	}

	public static void Exclude(){
		Destroy (card.gameObject);
	}

	public static void ExcludePilha(){
		Destroy (pilha.gameObject);
	}
}

