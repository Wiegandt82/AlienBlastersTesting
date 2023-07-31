using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _horizontalVelocity = 8f;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] float _jumpVelocity = 5;

    public bool IsGrounded;

    float _jumpEndTime;

    void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
    }

    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);
        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider)
            IsGrounded = true;
        else
            IsGrounded = false;

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
