using UnityEngine;

public class bulletController : MonoBehaviour
{
    
    private float directionOfErrection;
    private float time;
    public int left = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 7.5f * left);
        time += Time.deltaTime;
    }
    void FixedUpdate()
    {
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