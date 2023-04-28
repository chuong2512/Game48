using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private GameDataManager _dataManager;
    
    private void Start()
    {
        _dataManager = GameDataManager.Instance;
        SetSkin();
    }

    private void SetSkin()
    {
        //Debug.Log(_dataManager.playerData.currentSkin);
        sprite.sprite = _dataManager.anh[_dataManager.playerData.currentSkin];
    }
}
