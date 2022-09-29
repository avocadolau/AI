using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;


    private void Update()
    {
        Seek();
    }

    void Seek()
    {
        agent.destination = target.transform.position;
    }
}
