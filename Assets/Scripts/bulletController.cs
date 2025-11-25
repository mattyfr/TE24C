using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject colisionCheck;
    public LayerMask hurtfullStuff;
    private bool hitEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 5);
        hitEnemy = Physics2D.OverlapCircle(colisionCheck.transform.position, .5f, hurtfullStuff);
    }
    void FixedUpdate()
    {
        if (hitEnemy)
        {
            JustKillItAll();
        }
    }
    void JustKillItAll()
    {
        Destroy(gameObject);
    }
}