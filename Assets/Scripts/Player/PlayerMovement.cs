using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector2 movementInput;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, 0f) * _speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}