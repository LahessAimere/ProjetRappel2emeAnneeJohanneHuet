using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CountEnemyDestroy : MonoBehaviour, ISerializable<EnemyDestroyDTO>
{
    [FormerlySerializedAs("_numOfKilltext")] [SerializeField] private TextMeshProUGUI _numberOfKilltext;
    
    private int _numberOfKill = 0;

    public void UpdateNumberOfKill(int numberOfKill)
    {
        _numberOfKill += numberOfKill;
        string scoreString = _numberOfKill.ToString();
        _numberOfKilltext.text = scoreString;
    }
    
    public void Deserialize(EnemyDestroyDTO dataTransferObject)
    {
        _numberOfKill = dataTransferObject.NumberOfEnemyDestroy;
    }

    public EnemyDestroyDTO Serialized()
    {
        return new EnemyDestroyDTO()
        {
            NumberOfEnemyDestroy = _numberOfKill
        };
    }
}