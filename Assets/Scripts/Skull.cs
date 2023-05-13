using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
     private Rigidbody2D _rb;
     private CircleCollider2D _col;

    public Vector2 pos
    {
        get { return transform.position; }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        _rb.AddForce(force,ForceMode2D.Impulse);
    }

    public void ActiveRb()
    {
        _rb.isKinematic = false;
    }
    
    public void DeactiveRb()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0f;
        _rb.isKinematic = true;
        
    }
}
