using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static int IdPlayer{ get; set; }
	public static string LoginPlayer{ get; set; }
	public static int item;
	public GameObject Player;
	public GameObject cameraPlayer;
	public GameObject[] inventory;
	public GameObject[] obj;
	public static bool pegaItem;
	public static bool colocaItem;
	public Image flashLight;
	public  GameObject nota;

	void Start(){
		pegaItem = false;
		colocaItem = true;
		if(Player != null && inventory != null){
			Player.transform.position = Location.location;
			Player.transform.rotation = new Quaternion (0,Location.Rotation.y,0,0);
			cameraPlayer.transform.rotation = new Quaternion( Location.Rotation.x,0,0,0);
			flashLight.fillAmount = Inventory.flashLight;

			for (int i = 0; i < 6; i++) {
				GameObject nov = new GameObject();
				Instantiate (obj [Inventory.itens[i]], inventory[i].transform);
			}
		}
	}
	void Update(){
		#region SAVE
		if(Input.GetKeyDown("p")){
			Debug.Log("save inicio");
			Location.location = Player.transform.position;
			Location.Rotation = new Vector3(cameraPlayer.transform.rotation.x,Player.transform.rotation.y,cameraPlayer.transform.rotation.z);
			Inventory.flashLight =flashLight.fillAmount ;
			DBAcces.updateLocation (LoginPlayer, Location.location.x, Location.location.y, Location.location.z, Location.Rotation.x, Location.Rotation.y, Location.Rotation.z);
			DBAcces.updateInventory (LoginPlayer, Inventory.itens [0], Inventory.itens [1], Inventory.itens [2], Inventory.itens [3], Inventory.itens [4], Inventory.itens [5], Inventory.flashLight);
			Debug.Log("save fim");
		}
		#endregion
		if (Input.GetKeyDown ("e")) {
			if (notas.permite) {
				nota.SetActive (true);
			}
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
