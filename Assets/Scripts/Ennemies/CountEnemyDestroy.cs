using TMPro;
using UnityEngine;

public class CountEnemyDestroy : MonoBehaviour, ISerializable<EnemyDestroyDTO>
{
    [SerializeField] private TextMeshProUGUI _numOfKilltext;
    
    private int _numOfKill = 0;

    public void UpdateNumberOfKill(int numOfKill)
    {
        _numOfKill += numOfKill;
        string scoreString = _numOfKill.ToString();
        _numOfKilltext.text = scoreString;
    }
    
    public void Deserialize(EnemyDestroyDTO dataTransferObject)
    {
        _numOfKill = dataTransferObject.NumberOfEnemyDestroy;
    }

    public EnemyDestroyDTO Serialized()
    {
        return new EnemyDestroyDTO()
        {
            NumberOfEnemyDestroy = _numOfKill
        };
    }
}