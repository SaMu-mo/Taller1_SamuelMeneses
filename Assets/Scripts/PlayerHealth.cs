using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public float invulnerableTime = 1f;

    private int currentHealth;
    private bool invulnerable = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (invulnerable)
        {
            return;
        }

        currentHealth -= damage;

        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Sacudir(0.2f, 0.2f);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirSfx(AudioManager.Instance.sfxDanio);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        StartCoroutine(Invulnerable());
    }

    IEnumerator Invulnerable()
    {
        invulnerable = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(invulnerableTime);
        spriteRenderer.color = Color.white;
        invulnerable = false;
    }
}