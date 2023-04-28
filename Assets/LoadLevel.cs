using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SetState(StateGame.Playing);
        GameController.Instance.LoadGame();
    }
}
