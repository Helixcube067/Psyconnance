using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Script that controls the enemy to move towards the player. 
public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        float speedSetter = agent.velocity.magnitude / agent.speed;
        if(animator != null)
            animator.SetFloat("EnemyAction", speedSetter, .1f, Time.deltaTime);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
