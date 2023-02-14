using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] public List<Transform> list;
    private NavMeshAgent navMeshAgent;
    private int currentIndex = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
        {
            currentIndex = (currentIndex + 1) % list.Count;
            navMeshAgent.destination = list[currentIndex].position;
        }
    }
}