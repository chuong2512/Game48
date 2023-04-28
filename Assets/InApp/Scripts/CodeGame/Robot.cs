using System.Collections;
using System.Collections.Generic;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;

public class Robot : Singleton<Robot>
{
    [SerializeField] private SpriteRenderer anh;
    private GameDataManager gameData;

    public Rigidbody2D rigidbody;

    void Start()
    {
        gameData = GameDataManager.Instance;

        anh.sprite = gameData.anh[gameData.playerData.currentSkin];
    }

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    [Button]
    public void FrogJump(float power)
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.AddForce(Vector2.one * power, ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Run()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void EndRun()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}