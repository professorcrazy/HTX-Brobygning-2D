using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
