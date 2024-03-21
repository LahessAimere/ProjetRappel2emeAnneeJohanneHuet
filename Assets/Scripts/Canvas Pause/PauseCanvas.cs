using UnityEngine;
using UnityEngine.InputSystem;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private PlayerInput _playerInput;

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
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }
}