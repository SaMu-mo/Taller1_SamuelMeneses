using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public float wallDistance = 0.6f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        RaycastHit2D groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);

        Vector2 wallOrigin = (Vector2)transform.position + Vector2.up * 0.5f;
        RaycastHit2D wallHit = Physics2D.Raycast(wallOrigin, Vector2.right * direction, wallDistance, groundLayer);

        if (groundHit.collider == null || wallHit.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null)
        {
            return;
        }

        float direction = transform.localScale.x > 0 ? 1f : -1f;
        Vector3 wallOrigin = transform.position + Vector3.up * 0.5f;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallOrigin, wallOrigin + Vector3.right * direction * wallDistance);
    }
}