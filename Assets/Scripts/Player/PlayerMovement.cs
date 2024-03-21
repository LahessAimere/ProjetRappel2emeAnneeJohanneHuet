using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Vector2 _movementInput;

    private void Update()
    {
        Vector3 movement = new Vector3(_movementInput.x, _movementInput.y, 0f) * _speed * Time.deltaTime;
        transform.Translate(movement);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }
}