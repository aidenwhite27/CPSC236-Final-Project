using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;

    Rigidbody2D rb;

    float movement = 0f;

    public GameManager theGameManager;

    public float jump = 10f;

    private float jumpTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        jumpTimeLeft -= Time.deltaTime;
        if(jumpTimeLeft < 0)
        {
            jump = 10f;
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
        }
    }

    public void AddJump(float jumpToAdd)
    {
        jump += jumpToAdd;
        jumpTimeLeft = 1f;
    }
}
