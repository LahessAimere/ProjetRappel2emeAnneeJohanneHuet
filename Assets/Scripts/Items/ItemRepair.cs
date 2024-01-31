using UnityEngine;

public class ItemRepair : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
