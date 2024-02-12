using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        Resume();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.timeScale == 0f)
            {
                Resume();
            }
            else
            {
                PauseInGame();
            }
        }
    }

    private void PauseInGame()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _playerInput.SwitchCurrentActionMap("UI");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        _playerInput.SwitchCurrentActionMap("Game");
    }
}
