using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private Image _healthBarImage;

    private void Start()
    {
        _healthBarImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _playerHealth.MaxHealth -= 10;
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        float normalizedHealth = (float)_playerHealth.CurrentHealth / _playerHealth.MaxHealth;
        _healthBarImage.transform.localScale = new Vector3(normalizedHealth, 1f, 1f);
    }
}