using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float rocketDamage = 20f;
    public GameObject explosionPrefab;

	void Start () {
		
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.collider.tag == "Target") 
        {
            col.collider.GetComponent<Target>().TakeDamage(rocketDamage);
            // Effect will start itself and destroy itself when finished so we don't need to destroy it
            Instantiate(explosionPrefab, col.transform.position, Quaternion.AngleAxis(180f, explosionPrefab.transform.right));
            Destroy (gameObject);
        }
    }
}
