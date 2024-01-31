using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float maxLife = 100f;
    public float MaxLife
    {
        get => maxLife;
        set => maxLife = value;
    }
}