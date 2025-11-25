using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public LayerMask playerLayer;
    public GameObject playerChecker;
    public GameObject enemySpawnerPos;
    private bool playerClose;
    private bool enemyHasSpawned;
    private Vector2 enemySpawnerPosition;
    private quaternion rotation;
    void Start()
    {
        enemyHasSpawned = false;
    }
    void Update()
    {
        if (!enemyHasSpawned)
        {
            playerClose = Physics2D.OverlapCircle(playerChecker.transform.position, 5f, playerLayer);
            if (playerClose)
            {
                enemySpawnerPosition = transform.position;
                Instantiate(Enemy, enemySpawnerPosition, rotation);
                enemyHasSpawned = true;
            }
        }
    }
}
