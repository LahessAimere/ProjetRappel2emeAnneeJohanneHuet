using UnityEngine;

public class ButtonStartInteraction : MonoBehaviour
{
    public GameObject objectToToggle;

    public void ToggleGameObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(true);
        }
        else
        {
            Debug.LogError("GameObject à basculer non défini !");
        }
    }
}