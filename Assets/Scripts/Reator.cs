using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reator : MonoBehaviour {
	public static bool liga=false;
	public  GameObject luz;

	
	public  void ligaLuz(){
		luz.SetActive(true);
	}
}
