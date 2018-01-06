using UnityEngine;

public class Rocket : MonoBehaviour {

    public float rocketDamage = 20f;
    public GameObject explosionPrefab;

	void Start () {
		
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.collider.tag != "Player")
        {
            // Effect will start itself and destroy itself when finished so we don't need to destroy it
            Instantiate(explosionPrefab, transform.position, transform.rotation);//Quaternion.AngleAxis(0f, explosionPrefab.transform.up));
            Destroy (gameObject);
        }
        if (col.collider.tag == "Target") 
        {
            col.collider.GetComponent<Target>().TakeDamage(rocketDamage);
        }
    }
}
