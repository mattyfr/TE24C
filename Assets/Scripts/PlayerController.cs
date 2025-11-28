using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1f;
    public float jumpForce = 1f;
    public LayerMask groundLayer;
    public LayerMask hurtfullStuff;
    public LayerMask checkPointLayer;
    public GameObject groundChecker;
    public GameObject Hitbox;
    public GameObject shootPrefabRight;
    public GameObject shootPrefabLeft;
    private float shootCooldown;
    private bool jumpPressed;
    private bool shootPressed;
    private bool isGrounded;
    private bool playerGotHit;
    private bool left; 
    private Vector3 lastCheckPointPos;
    void Start()
    {
        shootCooldown = 0;
        lastCheckPointPos = new Vector2(0,0);
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
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") <= 0)
            {
                left = true;
            }
            else
            {
                left = false;
            }
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, .5f, groundLayer);
        playerGotHit = Physics2D.OverlapCircle(Hitbox.transform.position, .5f, hurtfullStuff);
        if (Physics2D.OverlapCircle(Hitbox.transform.position, .5f, checkPointLayer))
        {
            lastCheckPointPos = transform.position;
        }
        if (jumpPressed)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpPressed = false;
        }
        if (playerGotHit)
        {
            transform.position = lastCheckPointPos;
        }
        if (shootPressed)
        {
            if (left)
            {
                Instantiate(shootPrefabLeft, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(shootPrefabRight, transform.position, Quaternion.identity);
            }
            shootPressed = false;
        }
    }
}