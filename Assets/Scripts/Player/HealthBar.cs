using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBarImage;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _healthBarImage = GetComponent<Image>();
        _playerHealth.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float ratioHealth = currentHealth / maxHealth;
        _healthBarImage.transform.localScale = new Vector3(ratioHealth, 1f, 1f);
    }
}