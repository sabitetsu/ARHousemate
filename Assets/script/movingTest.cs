using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movingTest : MonoBehaviour
{
    private NavMeshAgent nma;
    [SerializeField] Vector3 pos;
    private Rigidbody rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.destination = pos;
        if(rb.transform.position != pos)
        {
            anim.Play("Run");
        }
    }
}
