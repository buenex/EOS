using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour {
	public float speed;
	Image img;
	public GameObject lamp;
	// Use this for initialization
	void Start () {
		img=GetComponent<Image> ();
		img.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (lamp.activeInHierarchy==true)
		{
			if (img.fillAmount > 0) {
				img.fillAmount -= speed;
			}
			if (img.fillAmount <= 0) {
				lamp.SetActive (false);
			} else if (img.fillAmount == 1) {
				lamp.SetActive (true);
			}
		}
		else 
		{
			
		}
		if (Input.GetKeyDown(KeyCode.F)&&lamp.activeInHierarchy==true)
		{
			lamp.SetActive(false);
		}
		else if((Input.GetKeyDown(KeyCode.F)) && lamp.activeInHierarchy==false)

			{

			lamp.SetActive(true);
			}

	}
}
