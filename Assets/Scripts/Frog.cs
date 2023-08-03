using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] float _jumpDelay = 3;
    [SerializeField] Vector2 _force;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Jump", _jumpDelay, _jumpDelay);
    }

    void Jump()
    {
        _rb.AddForce(_force);
    }
}
