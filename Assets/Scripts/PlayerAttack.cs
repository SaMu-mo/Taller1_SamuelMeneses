using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int damage = 1;
    public float attackCooldown = 0.4f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 attackOffset;
    private float nextAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackOffset = attackPoint.localPosition;
    }

    void Update()
    {
        float side = spriteRenderer.flipX ? -1f : 1f;
        attackPoint.localPosition = new Vector3(Mathf.Abs(attackOffset.x) * side, attackOffset.y, attackOffset.z);

        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}