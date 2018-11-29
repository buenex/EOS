using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityStandardAssets.Characters.FirstPerson;

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
	public GameObject inv;
	public playerCol pc;
	public Reator reator;
	public FirstPersonController perso;



	void Start(){
		pegaItem = false;
		colocaItem = false;
		Location.location = new Vector3(0,1,0);
			Inventory.itens=new int[7];
			Inventory.itens[0] = 7;
			Inventory.itens[1] = 7;
			Inventory.itens[2] = 7;
			Inventory.itens[3] = 7;
			Inventory.itens[4] = 7;
			Inventory.itens[5] = 7;
			Inventory.flashLight=1;
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

		if(Input.GetKeyDown("i")){
			if (inv.gameObject.activeSelf) {
				inv.SetActive (false);
			} else if (!inv.gameObject.activeSelf) {
				inv.SetActive (true);
			}
		}
		if (Input.GetKeyDown ("e")) {
			if (notas.permite) {
				perso.enabled=false;
				nota.SetActive (true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			if(Reator.liga){
				reator.ligaLuz();
			}

			if(playerCol.pegaPilha){
				flashLight.fillAmount=1;
				playerCol.ExcludePilha();
				pc.ajuda.SetActive (false);
				playerCol.pegaPilha=false;
			
			}
			for (int i = 0; i < 6; i++) {
				if (inventory [i].gameObject.transform.childCount == 0 ) {
					if (colocaItem) {
						GameObject nov = new GameObject ();
						Instantiate (obj [item], inventory [i].transform.position,inventory[i].transform.rotation,inventory [i].transform);
						Inventory.itens [i] = item;
						colocaItem = false;
						playerCol.Exclude ();
						pc.ajuda.SetActive (false);
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
