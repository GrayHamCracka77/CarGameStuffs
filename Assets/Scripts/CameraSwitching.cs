using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour {

    public Camera close;
    public Camera far;

	// Use this for initialization
	void Start () {
        close.enabled = true;
        close.GetComponent<AudioListener>().enabled = true;
        far.enabled = false;
        far.GetComponent<AudioListener>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
        {
            close.enabled = !close.enabled;
            // Camera enable has already been set, don't need opposite
            close.GetComponent<AudioListener>().enabled = close.enabled;
            far.enabled = !far.enabled;
            far.GetComponent<AudioListener>().enabled = far.enabled;
        }
	}
}
