using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _jumpEndTime;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] float _jumpVelocity = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
