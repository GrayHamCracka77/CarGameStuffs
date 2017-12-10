using UnityEngine;

public class Target : MonoBehaviour {

    // Use this for initialization
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Rocket") 
		{
			TakeDamage (CarController.rocketDamage);
			Destroy (col.gameObject);
		}
	}
}
