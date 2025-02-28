using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float lookDistance = 15f;
    [SerializeField] float speed = 1f;
    Vector3 targetPos;
    Rigidbody2D rb;

    Transform player;
    [SerializeField] LayerMask searchLayer;
    NavMeshAgent agent;

    Vector2 targetDir;
    private Vector2 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        agent = GetComponent<NavMeshAgent>();
        targetDir = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) {
            return;
        }
        transform.right = targetDir;
        Vector2 playerDir = (player.position-transform.position).normalized;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, playerDir, lookDistance, searchLayer);
        if (ray.collider.CompareTag("Player")) {
            Debug.Log("I see you!");
            targetDir = playerDir;
            target = player.position;
            //rb.linearVelocity = playerDir * speed;
            
            agent.SetDestination(target);
            transform.right = targetDir;
        }

    }
}
