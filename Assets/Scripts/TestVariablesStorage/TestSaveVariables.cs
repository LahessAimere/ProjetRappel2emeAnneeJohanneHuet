using UnityEngine;

public class TestSaveVariables : MonoBehaviour
{
    [SerializeField] private SaveVariables saveVariables;

    private void Start()
    {
        saveVariables = GetComponent<SaveVariables>();
        
        // Test Float
        saveVariables.SetFloat("PlayerHealth", 100f);
        float playerHealth = saveVariables.GetFloat("PlayerHealth");
        Debug.Log("Player Health: " + playerHealth);
        
        
        // Test String
        saveVariables.SetString("PlayerName", "Pikachu");
        string playerName = saveVariables.GetString("PlayerName");
        Debug.Log("Player Name: " + playerName);
        
        // Test Bool
        saveVariables.SetBool("IsPlayerAlive", true);
        bool isPlayerAlive = saveVariables.GetBool("IsPlayerAlive");
        Debug.Log("Is Player Alive: " + isPlayerAlive);
    }
}