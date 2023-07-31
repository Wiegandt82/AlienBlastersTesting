using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _jumpEndTime;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] float _jumpVelocity = 5;

    void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float bottomY = spriteRenderer.bounds.extents.y;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - bottomY);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
    }


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        var vertical = rb.velocity.y;

        if (Input.GetButtonDown("Fire1"))
            _jumpEndTime = Time.time + _jumpDuration;

            if (Input.GetButtonDown("Fire1") && _jumpEndTime > Time.time)
            vertical = _jumpVelocity; 

        rb.velocity = new Vector2(horizontal, vertical);
    }
}
