using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class dusman : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    void Start()
    {
        // NavMeshAgent bileþenini al
        agent = GetComponent<NavMeshAgent>();

        // Oyuncuyu bul
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("");
        }
    }
    void Update()
    {
        // Oyuncunun pozisyonuna git
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void Die()
    {
        Respawn();
    }
    void Respawn()
    {
        Vector3 randomspawnPos = new Vector3(Random.Range(140, 30), 0, Random.Range(140, 450));
        transform.position = randomspawnPos;
    }

}


