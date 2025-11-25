using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject colisionCheck;
    public LayerMask hurtfullStuff;
    private bool hitEnemy;
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 7.5f);
        hitEnemy = Physics2D.OverlapCircle(colisionCheck.transform.position, .5f, hurtfullStuff);
        time += Time.deltaTime;
    }
    void FixedUpdate()
    {
        while (hitEnemy)
        {
            float timeA;
            timeA = Time.deltaTime;
            if (timeA >= 0.1f)
            {
                JustKillItAll();
            }
        }
        if (time >= 5)
        {
            JustKillItAll();
        }
    }
    void JustKillItAll()
    {
        Destroy(gameObject);
    }
}