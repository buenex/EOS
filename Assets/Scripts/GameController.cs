using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static int IdPlayer{ get; set; }
	public static string LoginPlayer{ get; set; }
	public static int item;
	public GameObject Player;
	public GameObject[] inventory;
	public GameObject[] obj;
	public static bool pegaItem;
	public static bool colocaItem;

	void Start(){
		pegaItem = false;
		colocaItem = true;
		if(Player != null && inventory != null){
			Player.transform.position = Location.location;
			Player.transform.rotation = new Quaternion( Location.Rotation.x,Location.Rotation.y,Location.Rotation.z,Player.transform.rotation.w);

			for (int i = 0; i < 6; i++) {
				GameObject nov = new GameObject();
				Instantiate (obj [Inventory.itens[i]], inventory[i].transform);
			}
		}
	}
	void Update(){
		if (Input.GetKeyDown ("e")) {
			for (int i = 0; i < 6; i++) {
				if (inventory [i].gameObject.transform.childCount == 0 ) {
					if (colocaItem) {
						GameObject nov = new GameObject ();
						Instantiate (obj [item], inventory [i].transform);
						Inventory.itens [i] = item;
						colocaItem = false;
						playerCol.Exclude ();
					}
				}
			}
		}
	}
}

public class Location : MonoBehaviour{
	public static Vector3 location{ get; set; }
	public static Vector3 Rotation{ get; set; }
}

public class Inventory{
	public static int[] itens{ get; set; }
	public static float flashLight{ get; set; }
}
