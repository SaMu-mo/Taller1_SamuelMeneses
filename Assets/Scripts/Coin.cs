using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinUI.instance.AddCoins(value);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirSfx(AudioManager.Instance.sfxMoneda);
            }
            Destroy(gameObject);
        }
    }
}