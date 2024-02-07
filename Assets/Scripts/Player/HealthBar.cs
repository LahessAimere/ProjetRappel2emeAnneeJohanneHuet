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
        float ratioHealth = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
        _healthBarImage.transform.localScale = new Vector3(ratioHealth, 1f, 1f);
    }
}