using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    // ★ WaveManagerはPrefabに入れない前提でもOK
    public System.Action onDeath;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Debug.Log(gameObject.name + " HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        // ★ WaveManagerではなくイベント通知
        onDeath?.Invoke();

        Destroy(gameObject);
    }
}