using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSpaceShip : MonoBehaviour {
	public float speed;
	Vector3 axis;
	// Use this for initialization
	void Start () {
		axis = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (axis, speed);
	}
}
