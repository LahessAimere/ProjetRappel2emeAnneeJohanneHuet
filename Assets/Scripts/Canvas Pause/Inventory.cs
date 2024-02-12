using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float _size = 400f;
    [SerializeField] private int _numPoint = 3;

    private ListItemDatasInventory _listItemDatas;

    private InputAction _navigationAction;
    private Vector2 _navigationInput;
    private int _selectedButtonIndex = 0;
    

    private void OnEnable()
    {
        _navigationAction.performed += OnNavigation;
        _navigationAction.Enable();
    }

    private void OnDisable()
    {
        _navigationAction.performed -= OnNavigation;
        _navigationAction.Disable();
    }

    public void OnNavigation(InputAction.CallbackContext context)
    {
        _navigationInput = context.ReadValue<Vector2>();

        if (_navigationInput.x > 0)
        {
            _selectedButtonIndex = (_selectedButtonIndex + 1) % _numPoint;
        }
        else if (_navigationInput.x < 0)
        {
            _selectedButtonIndex = (_selectedButtonIndex - 1 + _numPoint) % _numPoint;
        }
    }
    
    private void OnDrawGizmos()
    {
        float tauMultiplier = 2 * Mathf.PI / _numPoint;

        for (int i = 0; i < _numPoint; i++)
        {
            float tau = tauMultiplier * i;
            float x = Mathf.Cos(tau) * _size;
            float y = Mathf.Sin(tau) * _size;

            Vector3 currentPoint = transform.position + new Vector3(x, y, 0);

            float buttonSize = 0.1f;
            float buttonRadius = buttonSize * HandleUtility.GetHandleSize(currentPoint);

            if (i == _selectedButtonIndex)
            {
                Handles.color = Color.green;
            }
            else
            {
                Handles.color = Color.white;
            }

            Handles.DrawSolidDisc(currentPoint, Vector3.forward, buttonRadius);

            float nextX = Mathf.Cos(2 * Mathf.PI * (i + 1) / _numPoint) * _size;
            float nextY = Mathf.Sin(2 * Mathf.PI * (i + 1) / _numPoint) * _size;

            Vector3 nextPoint = transform.position + new Vector3(nextX, nextY, 0);

            Handles.color = Color.magenta;
            Handles.DrawLine(currentPoint, nextPoint);
        }

        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, _size);
    }
}
