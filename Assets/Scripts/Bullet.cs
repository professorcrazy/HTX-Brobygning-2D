using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    public float bulletSpeed = 5f;
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<Health>()?.TakeDamage(damage);
        Destroy(gameObject);
    }
}
