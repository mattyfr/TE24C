using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private int a;
    private bool hasBeenHit;
    public GameObject colisionCheck;
    public LayerMask hurtfullStuff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // transform.position = Spawner.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        double movementx = Math.Sin(Time.time * Math.PI / 10);
        if (movementx <= 0)
        {
            a = 1;
        }
        else
        {
            a = -1;
        }
        Vector2 movement = Vector2.right * a;
        transform.Translate(movement * Time.deltaTime);
        hasBeenHit = Physics2D.OverlapCircle(colisionCheck.transform.position, 0.25f, hurtfullStuff);
    }
    void FixedUpdate()
    {
        if (hasBeenHit)
        {
            JustKillItAll();
        }
    }
    void JustKillItAll()
    {
        Destroy(gameObject);
    }
}
