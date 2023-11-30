// using Unity.AI.Navigation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINewLogic : MonoBehaviour
{
    [Header("Enemy Setting")]
    public float turnSpeed = 15f;
    public Transform target;
    public float ChaseRange;
    private NavMeshAgent agent;
    private float DistancetoTarget;
    private float DistancetoDefault;
    public Animator anim;
    public Animator Transisi;
    public GameObject EnemyKunti;
    public int EnemyCount = 3;
    Vector3 DefaultPosition;
    public GameObject jumpScarePanel;
    public GameObject Light;

    [Header("Enemy SFX")]
    public AudioClip EnemyJumpscare;
    public AudioClip EnemyChase;
    AudioSource EnemyAudio;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        // anim = this.GetComponentInChildren<Animator>();
        EnemyAudio = this.GetComponent<AudioSource>();
        DefaultPosition = this.transform.position;
        Light.SetActive(false);
        // PlaceEnemy();
    }

    private void Update()
    {
        DistancetoTarget = Vector3.Distance(target.position, transform.position);
        DistancetoDefault = Vector3.Distance(DefaultPosition, transform.position);

        if (DistancetoTarget <= ChaseRange && gameObject.tag == "Kunti")
        {
            Show();
            Light.SetActive(true);
            if (DistancetoTarget <= agent.stoppingDistance + 1f)
            {
                JumpScare();
            }
            else
            {
                Debug.Log("Stop");
            }            
        }
        else if (DistancetoTarget <= ChaseRange && gameObject.tag != "Kunti")
        {
            FaceTarget(target.position);
            if (DistancetoTarget > agent.stoppingDistance + 2f)
            {                
                ChaseTarget();
                Debug.Log("Ngejer");
            }
            else if (DistancetoTarget <= agent.stoppingDistance)
            {
                anim.SetBool("Run", false);
            }
        }
        else if (DistancetoTarget >= ChaseRange + 3f && gameObject.tag != "Kunti")
        {
            Debug.Log("Balik");
            Light.SetActive(false);
            agent.SetDestination(DefaultPosition);
            FaceTarget(DefaultPosition);
            if (DistancetoDefault <= agent.stoppingDistance)
            {
                Debug.Log("Time to stop");
                anim.SetBool("Run", false);
            }
        }        
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void Show()
    {
        Transisi.SetBool("Enter", true);
        FaceTarget(target.position);
        EnemyAudio.PlayOneShot(EnemyJumpscare);
        Debug.Log("Kaget");
    }

    public void JumpScare()
    {
        Debug.Log("Jumpscare");
        EnemyAudio.Stop();
        jumpScarePanel.SetActive(true);
        EnemyAudio.clip = EnemyChase;
        EnemyAudio.Play();
        StartCoroutine(disablePanel());
    }

    public void ChaseTarget()
    {
        Light.SetActive(true);
        agent.SetDestination(target.position);
        anim.SetBool("Run", true);
        EnemyAudio.PlayOneShot(EnemyChase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {            
            EnemyAudio.Stop();
            Debug.Log("Jumpscare");            
            EnemyAudio.PlayOneShot(EnemyJumpscare);
            jumpScarePanel.SetActive(true);
            StartCoroutine(disablePanel());
        }
    }

    IEnumerator disablePanel()
    {
        yield return new WaitForSeconds(2);
        jumpScarePanel.SetActive(false);
        EnemyAudio.Stop();
        Destroy(gameObject);
    }

    public void PlaceEnemy()
    {
        int EnemySet = 0;
        for (int i = 0; i < EnemyCount; i++)
        {            
            int x = Random.Range(-19, 20);
            int z = Random.Range(-20, -36);
            if (EnemySet != EnemyCount)
            {
                EnemySet++;
                GameObject enemy = Instantiate(EnemyKunti, new Vector3(x, 0, z), Quaternion.identity);
            }
            else if (EnemySet == EnemyCount)
            {
                Debug.Log("Already Placing All the Enemy");
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}
