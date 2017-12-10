using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float rocketDamage = 20f;

	void Start () {
		
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.collider.tag == "Target") 
        {
            col.collider.GetComponent<Target>().TakeDamage(rocketDamage);
            Destroy (gameObject);
        }
    }
}
