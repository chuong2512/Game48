using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public float speed = 0.002f;

    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite =
            GameDataManager.Instance.anh[GameDataManager.Instance.playerData.currentSkin];

        SpriteRenderer.flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameUI.Instance.currentState == StateGame.Playing)
        {
            Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            Rigidbody2D.velocity = Vector2.right * speed + Vector2.down;
        }
        else
        {
            Rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DoiHuong"))
        {
            speed *= -1;
            
            SpriteRenderer.flipX = !(speed > 0);
        }
        else if (col.gameObject.CompareTag("Win"))
        {
            GameUI.Instance.ShowWin();
        }
        else if (col.gameObject.CompareTag("Lose"))
        {
            GameUI.Instance.ShowLose();
        }
    }
}