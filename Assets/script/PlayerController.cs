using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    public float moveSpeed = 7f;
    public float jumpForce = 10f;

    public int Counter;
    public TextMeshProUGUI ScorText;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();

    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (h != 0)
            spriteRenderer.flipX = h < 0;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Counter++;
            Destroy(collision.gameObject);
            ScorText.text = Counter.ToString() + "" + "$";
            ;
            Debug.Log(Counter);
        }
    }
}
