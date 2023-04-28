using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //private void 

    public void CheckPassLevel()
    {
        if (GameDataManager.Instance.IsRemainKnife())
        {
            return;
        }

        GameUI.Instance.ShowWin();
    }

    public void Lose()
    {
        Debug.Log("Lose");
        GameController.Instance.SetState(StateGame.Pause);
        GameUI.Instance.ShowLose();
    }
}