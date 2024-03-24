using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PauseCanva : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private PlayerInput _playerInput;
    [FormerlySerializedAs("_objectToToggle")] [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _healthBar;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        StartCoroutine(PauseAfterDelay(0.01f));
    }

    private System.Collections.IEnumerator PauseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Resume();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.timeScale == 0f)
            {
                Resume();
                _playerInput.SwitchCurrentActionMap("Game");
            }
            else
            {
                PauseInGame();
                _playerInput.SwitchCurrentActionMap("UI");
            }
        }
    }

    private void PauseInGame()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _buttonStart.SetActive(false);
        _healthBar.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        _buttonStart.SetActive(true);
        _healthBar.SetActive(true);
    }
}