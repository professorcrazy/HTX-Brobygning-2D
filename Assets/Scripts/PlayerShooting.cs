using NUnit;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] float rpm = 120f;
    [SerializeField] float shotDelay;
    [SerializeField] GameObject bulletPrefab;
    bool canShoot = true;
    [SerializeField] KeyCode shootKey = KeyCode.Mouse0;
    private void Start() {
        shotDelay = 60f/rpm ;
    }

    void Update() {
        if (canShoot && Input.GetKey(shootKey)) {
            Shoot();
            Debug.Log("Shoot a bullet");
        }
    }

    void Shoot() { 
        canShoot = false;
        GameObject shot = Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        shot.GetComponent<Rigidbody2D>().linearVelocity = 
            (Vector2)(transform.right * shot.GetComponent<Bullet>()?.bulletSpeed);
        Invoke("resetCanShoot", shotDelay);
    }
    void resetCanShoot() {
        canShoot = true;
    }
}
