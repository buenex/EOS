using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static int IdPlayer{ get; set; }
	public static string LoginPlayer{ get; set; }
	// Use this for initialization
	void Awake () {
		DBAcces.select ("buenex");

		//IdPlayer = (int)DBAcces.reader ["id"];
		//LoginPlayer = DBAcces.reader ["login"].ToString();
		Debug.Log (IdPlayer);
	}
}
