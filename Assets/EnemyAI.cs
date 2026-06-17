using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int damage = 1;
    public float attackInterval = 1f;

    private float attackTimer;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction =
            (player.position - transform.position).normalized;

        direction.y = 0;

        transform.position +=
            direction * moveSpeed * Time.deltaTime;

        attackTimer += Time.deltaTime;
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (attackTimer < attackInterval)
            return;

        attackTimer = 0;

        PlayerHealth health =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}