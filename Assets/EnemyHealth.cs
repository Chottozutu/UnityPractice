using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 3;

    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Debug.Log(
            gameObject.name +
            " HP : " +
            currentHP
        );

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " defeated");

        Destroy(gameObject);
    }
}