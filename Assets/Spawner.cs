using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawns;

    // Start is called before the first frame update
    void Start()
    {
        if (spawns != null && spawns.Length > 0)
        {
            Instantiate(spawns[Random.Range(0, spawns.Length)]);
        }
    }
}