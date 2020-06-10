using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavigation : MonoBehaviour
{
    NavMeshAgent NMA;
    GameObject Player;

    void Start()
    {
        NMA = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        NMA.SetDestination(Player.transform.position);
    }
}
