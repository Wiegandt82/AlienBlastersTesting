using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _horizontalVelocity = 8f;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] float _jumpVelocity = 5;
    [SerializeField] Sprite _jumpSprite;

    public bool IsGrounded;

    float _jumpEndTime;
    SpriteRenderer _spriteRenderer;
    Sprite _defaultSprite;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }

    void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
    }

    void Update()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - _spriteRenderer.bounds.extents.y);
        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider) 
        {
            IsGrounded = true;
            _spriteRenderer.sprite = _defaultSprite;
        }
        else
        {
            IsGrounded = false;
            _spriteRenderer.sprite = _jumpSprite;
        }
            

        var horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        var vertical = rb.velocity.y;

        if (Input.GetButtonDown("Fire1") && IsGrounded)
            _jumpEndTime = Time.time + _jumpDuration;

            if (Input.GetButtonDown("Fire1") && _jumpEndTime > Time.time)
            vertical = _jumpVelocity;

        horizontal *= _horizontalVelocity;

        rb.velocity = new Vector2(horizontal, vertical);
    }
}
