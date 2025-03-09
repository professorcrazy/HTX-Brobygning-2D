using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float speed = 3f;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce = 5f;
    Vector2 dir;
    [SerializeField] KeyCode jumpBtn = KeyCode.Space;
    [SerializeField] int nJumps = 2;
    [SerializeField] int jumpCount;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        runSpeed = speed * 1.5f;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        dir.x = Input.GetAxisRaw("Horizontal") * speed;
        dir.y = rb.linearVelocityY;

        if (Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, groundLayer)) {
            jumpCount = 0;
        }
        if (jumpCount < nJumps && Input.GetKeyDown(jumpBtn)) {
            jumpCount++;
            rb.linearVelocityY = 0;
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
    void FixedUpdate() {
        rb.linearVelocity = dir;
    }

}
