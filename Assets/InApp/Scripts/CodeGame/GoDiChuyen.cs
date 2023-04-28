using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;

public class GoDiChuyen : Singleton<GoDiChuyen>
{
    public float lastPoint = 2.2f;
    public float Add = 0.5f;
    public float speed = 1.5f;
    public Vector3 pos;

    public cau cau;

    public GameObject[] cols;

    public void GenCol()
    {
        lastPoint += Random.Range(0.8f, 3f);

        var col = Instantiate(cols[Random.Range(0, cols.Length)]
            ,transform);
        
        col.transform.localPosition = pos + Vector3.right * lastPoint;
    }

    [Button]
    public void Move(float x)
    {
        for (int i = 0; i < 3; i++)
        {
            GenCol();
        }
       
        Robot.Instance.Run();
        transform.DOMoveX(transform.position.x - x - Add, Mathf.Abs((x+Add) / speed)).SetEase(Ease.Linear).OnComplete(() =>
        {
            cau.Reset();
            Robot.Instance.EndRun();
            //GameUI.Instance.SetState(State.Stop);
        });

        cau.transform.DOMoveX(cau.transform.position.x - x - Add, Mathf.Abs((x+Add) / speed)).SetEase(Ease.Linear);
    }
}