using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    public float invincibleTime = 1f;
    public int CurrentHP => currentHP;

    private bool isInvincible = false;
    private int currentHP;
    private UIManager uiManager;

    void Start()
    {
        currentHP = maxHP;

        uiManager = FindFirstObjectByType<UIManager>();

        uiManager.UpdateHP(currentHP);
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        currentHP -= damage;
        uiManager.UpdateHP(currentHP);

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