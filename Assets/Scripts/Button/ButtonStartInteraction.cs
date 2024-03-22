using UnityEngine;

public class ButtonStartInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _objectToToggle;

    public void ToggleGameObject()
    {
        if (_objectToToggle != null)
        {
            _objectToToggle.SetActive(!_objectToToggle.activeSelf);
        }
    }
}