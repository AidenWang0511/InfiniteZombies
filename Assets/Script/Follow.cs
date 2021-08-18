using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshAgent agent;
    public float speed = 100.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        agent.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, -step);


    }
}
