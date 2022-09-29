using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Hide : MonoBehaviour
{
    public float distance = 1.0f;
    public GameObject target;
    public NavMeshAgent agent;
    public GameObject[] hidingSpots;



    // Start is called before the first frame update
    void Start()
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("HIDE");
        HideAndRun();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    

    void HideAndRun()
    {
        Func<GameObject, float> distance =
            (hs) => Vector3.Distance(target.transform.position,
                                     hs.transform.position);
        GameObject hidingSpot = hidingSpots.Select(
            ho => (distance(ho), ho)
            ).Min().Item2;
        Vector3 dir = hidingSpot.transform.position - target.transform.position;
        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        Debug.Log(info.point);

        agent.destination = (info.point + dir.normalized);

    }
}
