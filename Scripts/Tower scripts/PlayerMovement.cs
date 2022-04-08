using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This script controls the movement and animations of the player
/// This gets MOUSE INPUT for now
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCam;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    public int speed;
    public SceneMovement sceneMover;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float speedSetter = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speedSetter, .1f, Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                transform.LookAt(hit.point);
                agent.destination = hit.point;
            }

        }
        //else if (Input.GetMouseButtonDown(1))
        //{
        //    Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 100))
        //    {
        //            if (hit.collider.tag == "Monster")
        //            {
        //                Debug.Log(Vector3.Distance(hit.collider.gameObject.transform.position, this.gameObject.transform.position));
        //                if (Vector3.Distance(hit.collider.gameObject.transform.position, this.gameObject.transform.position) < 4.0f) {
        //                    Monster monster = hit.collider.GetComponent<Monster>();
        //                    if (monster != null)
        //                    {
        //                        if (Vector3.Distance(this.gameObject.transform.position, hit.collider.gameObject.transform.position) <= 4.0f)
        //                            AttackMonster(monster);
        //                    }
        //                }
        //            }
        //            else if (hit.collider.tag == "Stairs") {
        //                if (Vector3.Distance(hit.collider.gameObject.transform.position, this.gameObject.transform.position) < 4.0f)
        //                {
        //                Debug.Log("Stairs encountered");
        //                    //Stairs stairs = hit.collider.GetComponent<Stairs>();
        //                    //sceneMover.LoadLevel(stairs.destination);
        //                }
        //            }
        //    }
        //}
    }

    #region MovementStuff
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        target = null;
        agent.updateRotation = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x * 2.5f, 0f, direction.z * 2.5f));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    #endregion

    //public void AttackMonster(Monster monster)
    //{
    //    Debug.Log("Engage!");
    //    BattleSystem.randomMonster = monster;
    //    StartCoroutine(Engage(1.5f));
    //}

    //IEnumerator Engage(float delay/*, GameObject enemyToSpawn*/)
    //{
    //    yield return new WaitForSeconds(delay);
    //    sceneMover.LoadLevel("Battle Scene");
    //}
}
