using RObo;
using UnityEngine;

public enum StateGame
{
    Playing,
    Pause
}

public class GameController : Singleton<GameController>
{
    private StateGame _currentState = StateGame.Pause;
    private GameDataManager gameDataManager;
    private Knife _currentKnife;

    public void SetState(StateGame stateGame)
    {
        _currentState = stateGame;
    }

    public bool CheckState(StateGame stateGame)
    {
        return _currentState == stateGame;
    }

    private void Awake()
    {
        gameDataManager = GameDataManager.Instance;
    }


    public void LoadGame()
    {
        gameDataManager.CreateLevel();
        _currentKnife = gameDataManager.CreatKnife();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckState(StateGame.Playing))
        {
            if (_currentKnife == null)
            {
                return;
            }

            _currentKnife.ThrowingKnife();
            _currentKnife = gameDataManager.CreatKnife();
        }
    }
}