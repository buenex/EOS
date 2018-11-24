using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static int IdPlayer{ get; set; }
	public static string LoginPlayer{ get; set; }

}

public class Location : MonoBehaviour{
	public static Vector3 location{ get; set; }
	public static Vector3 Rotation{ get; set; }
}

public class Inventory{
	public static int[] itens;
	public static float flashLight{ get; set; }
}
