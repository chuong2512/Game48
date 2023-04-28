using RObo;
using Unity.Mathematics;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameDataManager : PersistentSingleton<GameDataManager>
{
    /*----Scriptable data-----------------------------------------------------------------------------------------------*/

    /*----Data variable-------------------------------------------------------------------------------------------------*/
    [HideInInspector] public PlayerData playerData;

    public Sprite[] anh;

    public LevelSO LevelSO;

    [SerializeField] private Vector3 virusPos;
    [SerializeField] private Vector3 knivesPos;

    private GameController _gameController;
    
    //[Space] [Tooltip("data")]
    private LevelData _levelData;
    private int _level;
    private int _remainKnives;

    public int Level => _level;

    private void Start()
    {
        _level = 1;
        Application.targetFrameRate = Mathf.Max(60, Screen.currentResolution.refreshRate);
    }


    private void CreatVirus()
    {
        Cycle cycle = Instantiate(_levelData.Cycle, virusPos, quaternion.identity);
        Virus virus = cycle.GetComponentInChildren<Virus>();
        virus.SetupVirus(_levelData.CycleScale);
    }

    public Knife CreatKnife()
    {
        if (_remainKnives <= 0)
        {
            return null;
        }

        _remainKnives--;
        Knife newKnife = Instantiate(_levelData.Knife, knivesPos, quaternion.identity);
        newKnife.SetKnife(_levelData.Speed);
        return newKnife;
    }
    
    public void CreateLevel()
    {
        _levelData = LevelSO.GetLevelData(_level);
        _remainKnives = _levelData.KnivesAmount;
        CreatVirus();
    }

    public bool IsRemainKnife()
    {
        if (_remainKnives > 0)
        {
            return true;
        }

        return false;
    }

    public void ResetLevel()
    {
        _level = 1;
    }

    public void NextLevel()
    {
        _level++;
    }

    private void OnEnable()
    {
        playerData = new GameObject(Constant.DataKey_PlayerData).AddComponent<PlayerData>();
        playerData.transform.parent = transform;
        playerData.Init();
    }

    public void ResetData()
    {
        playerData.ResetData();
    }
}