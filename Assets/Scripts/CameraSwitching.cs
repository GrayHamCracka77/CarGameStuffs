using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour {

    public Camera close;
    public Camera far;

	// Use this for initialization
	void Start () {
        close.enabled = true;
        far.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
        {
            close.enabled = !close.enabled;
            far.enabled = !far.enabled;
        }
	}
}
