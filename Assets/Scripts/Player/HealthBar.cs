using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealthData _playerHealthData;
    private Image _healthBarImage;

    private void Awake()
    {
        _healthBarImage = GetComponent<Image>();
        _playerHealthData.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        _playerHealthData.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float ratioHealth = currentHealth / maxHealth;
        _healthBarImage.transform.localScale = new Vector3(ratioHealth, 1f, 1f);
    }
}