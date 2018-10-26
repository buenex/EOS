using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour {
	public float speed;
	Image img;
	// Use this for initialization
	void Start () {
		img=GetComponent<Image> ();
		img.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		img.fillAmount -= speed;
	}
}
