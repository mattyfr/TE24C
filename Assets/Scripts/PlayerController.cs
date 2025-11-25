using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1f;
    public float jumpForce = 1f;
    public LayerMask groundLayer;
    public LayerMask hurtfullStuff;
    public GameObject groundChecker;
    public GameObject Hitbox;
    public GameObject shootPrefab;
    private float shootCooldown;
    private bool jumpPressed;
    private bool shootPressed;
    private bool isGrounded;
    private bool playerGotHit;
    void Start()
    {
        shootCooldown = 0;
    }
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = Vector2.right * inputX;

        transform.Translate(movement * playerSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumpPressed = true;
        }
        if (Input.GetButtonDown("Shoot") && shootCooldown <= 0)
        {
            shootPressed = true;
            shootCooldown = 1;
        }
        if (shootCooldown > -1)
        {
            shootCooldown -= Time.deltaTime;
        }
        
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, .5f, groundLayer);
        playerGotHit = Physics2D.OverlapCircle(Hitbox.transform.position, .5f, hurtfullStuff);
        if (jumpPressed)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpPressed = false;
        }
        if (playerGotHit)
        {
            transform.position = new Vector2(0f, 0f);
        }
        if (shootPressed)
        {
            Instantiate(shootPrefab, transform.position, Quaternion.identity);
            shootPressed = false;
        }
    }
}