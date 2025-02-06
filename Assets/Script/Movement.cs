using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Transform Target; 
    private NavMeshAgent agent;

    public GameObject gameOverPanel; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position);
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! Quái đã đến đích!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        Time.timeScale = 0; 
    }
}
