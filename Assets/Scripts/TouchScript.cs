using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchScripty : MonoBehaviour {

    Behaviour halo;
	private void Start()
	{
       halo = (Behaviour)GetComponent("Halo");
	}
    //disabling the halo of the cubes
	 void OnMouseDown()
	{
        Debug.Log(this.name);
        halo.enabled = false;
	}

    //
	private void OnMouseExit()
	{
        halo.enabled = true;
	}

	private void OnMouseEnter()
	{
       // add a light to change sizes maybe, halo is a dead end
	}
}
