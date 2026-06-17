using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    public float invincibleTime = 1f;

    private bool isInvincible = false;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        currentHP -= damage;

        Debug.Log("Player HP : " + currentHP);

        if (currentHP <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(InvincibleCoroutine());
    }

    System.Collections.IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        Debug.Log("Invincible Start");

        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
        Debug.Log("Invincible End");
    }

    void Die()
    {
        Debug.Log("Game Over");

        Time.timeScale = 0;
    }
}