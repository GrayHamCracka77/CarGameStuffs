using UnityEngine;

public class CameraSwitching : MonoBehaviour {

    public Camera close;
    public Camera far;

	void Start () {
        close.enabled = true;
        close.GetComponent<AudioListener>().enabled = true;
        far.enabled = false;
        far.GetComponent<AudioListener>().enabled = false;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
        {
            close.enabled = !close.enabled;
            close.GetComponent<AudioListener>().enabled = close.enabled;
            far.enabled = !far.enabled;
            far.GetComponent<AudioListener>().enabled = far.enabled;
        }
	}
}
