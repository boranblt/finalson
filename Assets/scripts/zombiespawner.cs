using UnityEngine;
using UnityEngine.AI;

public class zombiespawner : MonoBehaviour
{

    public GameObject zombiePrefab;
    public Transform spawnPoint;
    public Transform player;
    public float spawnInterval = 5f;
    private float currentSpawnTime = 0f;
    private bool isNight = false;

    void Update()
    {

        float sunAngle = RenderSettings.sun.transform.rotation.eulerAngles.x;
        isNight = sunAngle > 180f && sunAngle < 360f;


        if (isNight)
        {
            currentSpawnTime += Time.deltaTime;
            if (currentSpawnTime >= spawnInterval)
            {
                SpawnZombie();
                currentSpawnTime = 0f;
            }
        }
    }

    void SpawnZombie()
    {
        GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        zombie.GetComponent<NavMeshAgent>().destination = player.position;
    }
}
