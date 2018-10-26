using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMain : MonoBehaviour {
	public GameObject target;
	public float speedRotation;
	Vector3 axis;
	// Use this for initialization
	void Start () {
		axis = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (target.transform.position, axis, speedRotation);
	}
}
