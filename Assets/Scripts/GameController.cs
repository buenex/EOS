using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static int IdPlayer{ get; set; }
	public static string LoginPlayer{ get; set; }
	int item;
	public GameObject Player;
	public GameObject[] inventory;
	public GameObject[] obj;
	bool pegaItem;

	void Start(){
		pegaItem = false;
		if(Player != null && inventory != null){
			Player.transform.position = Location.location;
			Player.transform.rotation = new Quaternion( Location.Rotation.x,Location.Rotation.y,Location.Rotation.z,Player.transform.rotation.w);

			for (int i = 0; i < 6; i++) {
				GameObject nov = new GameObject();
				Instantiate (obj [1], inventory[i].transform);
			}
		}

		if (Input.GetKeyDown ("E") && pegaItem) {
			
			foreach (var i in obj) {
				if (i.transform.GetChild (0) == null) {
					Instantiate (obj [item].gameObject,i.transform).transform.SetParent (i.transform);
					pegaItem = false;
				}
			}
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "cartao") {
			int.TryParse(col.gameObject.name,out item);
			Debug.Log (item);
			pegaItem = true;
			Destroy (col.gameObject);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "cartao") {
			pegaItem = false;
		}
	}
}

public class Location : MonoBehaviour{
	public static Vector3 location{ get; set; }
	public static Vector3 Rotation{ get; set; }
}

public class Inventory{
	public static int[] itens;
	public static float flashLight{ get; set; }
}
