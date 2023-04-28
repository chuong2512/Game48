using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Virus : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void SetupVirus(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
