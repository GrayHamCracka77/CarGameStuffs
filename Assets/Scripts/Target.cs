using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;
    public static float damage = 10f;

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
}
