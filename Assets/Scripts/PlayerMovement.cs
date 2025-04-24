using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 moveInput;
    private float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool hasJumped;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2D.AddForce(moveInput * speed);
        
        /*move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);*/

        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            rb2D.AddForce(new Vector2(rb2D.linearVelocity.x, jumpForce));
            Debug.Log("Jumped");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            hasJumped = true;
        }
    }
}
