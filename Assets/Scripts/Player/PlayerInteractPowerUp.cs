using UnityEngine;

public class PlayerInteractPowerUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            
        }
    }
}
