using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Knife : MonoBehaviour
{
    [SerializeField] private float countdown = 0.05f;
    private float _speed;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private bool _isStatic;

    private void Start()
    {
        _isStatic = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(countdown);
        _collider.isTrigger = false;
    }

    public void ThrowingKnife()
    {
        
        _rigidbody.AddForce(new Vector2(0,_speed), ForceMode2D.Impulse);
    }

    public void SetKnife(float speed)
    {
        _speed = speed;
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Virus");
        if (col.CompareTag("Virus"))
        {
            Transform cycle = col.transform.parent;
            transform.SetParent(cycle);
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _isStatic = true;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Virus"))
        {
            Transform cycle = col.transform.parent;
            transform.SetParent(cycle);
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.bodyType = RigidbodyType2D.Static;
            _isStatic = true;
            //Check win 
            GameManager.Instance.CheckPassLevel();
        }
        else if(col.gameObject.CompareTag("Knife") && !_isStatic)
        {
            GameManager.Instance.Lose();
            float ranX =   Random.Range(4.5f, 6f);
            float ranY = - Random.Range(4.5f, 6f);
            _rigidbody.velocity = new Vector2(ranX,ranY);
            _collider.isTrigger = true;
        }
    }
}
