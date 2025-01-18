using UnityEngine;
using UnityEngine.AI;

public class armyspawner : MonoBehaviour
{
    public GameObject armyPrefab; // G�nd�z do�acak prefab
    public Transform spawnPoint;
    public Transform player;
    public float spawnInterval = 5f;
    private float currentSpawnTime = 0f;
    private bool isNight = false;

    void Update()
    {
        float sunAngle = RenderSettings.sun.transform.rotation.eulerAngles.x;
        isNight = sunAngle > 180f && sunAngle < 360f;

        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime >= spawnInterval)
        {
            if (!isNight)
            {
                SpawnArmy(); // G�nd�z army prefab�n� do�ur
            }
            currentSpawnTime = 0f;
        }
    }

    void SpawnArmy()
    {
        GameObject army = Instantiate(armyPrefab, spawnPoint.position, spawnPoint.rotation);
        army.GetComponent<NavMeshAgent>().destination = player.position; // Army i�in hedef oyuncu
    }
}
