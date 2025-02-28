using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
                                        Input.GetAxisRaw("Vertical")).normalized * speed;

        Vector2 mouseDistance = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnDestroy() {
        Debug.Log("GameOver");
    }
}
