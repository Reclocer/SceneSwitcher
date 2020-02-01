using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance { get; private set; }

    [SerializeField] private PlayerDataProviderBase _dataProvider;
    public PlayerDataProviderBase DataProvider => _dataProvider;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
