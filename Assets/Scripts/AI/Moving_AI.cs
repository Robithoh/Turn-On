using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Moving_AI : MonoBehaviour
{
    [SerializeField] private float Radius = 20;
    [SerializeField] private float ChaseRadius = 5; // Radius untuk pengejaran pemain
    [SerializeField] private bool Debug_Bool;
    private NavMeshAgent My_Agent;
    private Vector3 Next_Position;
    private Transform player; // Referensi ke transform pemain

    // Start is called before the first frame update
    void Start()
    {
        My_Agent = GetComponent<NavMeshAgent>();
        Next_Position = transform.position;
        player = GameObject.FindWithTag("Player").transform; // Diasumsikan pemain memiliki tag "Player".
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= ChaseRadius)
        {
            // Jika pemain dalam radius pengejaran, kejar pemain.
            My_Agent.SetDestination(player.position);
        }
        else if (distanceToPlayer > ChaseRadius && Vector3.Distance(transform.position, Next_Position) <= 1.5)
        {
            // Jika pemain di luar radius pengejaran dan musuh mencapai tujuan sebelumnya, pindahkan musuh ke tujuan baru.
            Next_Position = Generic_Random_Point_Generator.R_Point_Ge(transform.position, Radius);
            My_Agent.SetDestination(Next_Position);
        }
    }

    void OnDrawGizmos()
    {
        if (Debug_Bool == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}
