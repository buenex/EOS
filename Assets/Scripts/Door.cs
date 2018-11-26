using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public bool door1, door2;
	public float location, maxLocation,speed;
	bool ativar;
	public bool requerItem;
	public int itemName;
	// Use this for initialization
	void Start () {
		ativar = false;
		location = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (ativar) {
			if (door1 && this.transform.position.y < maxLocation) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);
			} else if (door2 && this.transform.position.y > maxLocation) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
			}
		}else if(!ativar) {
			if (door1 && this.transform.position.y >= location) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
			} else if (door2 && this.transform.position.y <=location) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);
			}
		}
	}
	public void setAtivar(bool condition){
		this.ativar = condition;
	}
	public bool getAtivar(){
		return this.ativar;
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player"){
			if (requerItem) {
				foreach (int item in Inventory.itens) {
					if (item == itemName) {
						ativar = true;
					}
				}
			} else {
				ativar = true;
			}
		}	
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Player")
			ativar = false;
	}
}
