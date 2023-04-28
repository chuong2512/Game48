using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinItem : MonoBehaviour
{
    private bool isUnlock;

    public GameObject lockObj;
    public GameObject unlockObj;
    public GameObject chooseObj;
    public Image iconImage;


    public void Init(Sprite sprite, bool isLock)
    {
    }

    public void Choose()
    {
        chooseObj.SetActive(true);
    }

    public void UnChoose()
    {
        chooseObj.SetActive(false);
        
        lockObj.SetActive(!isUnlock);
    }

    public void Unlock()
    {
        isUnlock = true;
        chooseObj.SetActive(true);
        unlockObj.SetActive(true);
        lockObj.SetActive(false);
    }
}