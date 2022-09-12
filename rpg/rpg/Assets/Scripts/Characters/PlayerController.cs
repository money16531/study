using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private Animator anim;

    private GameObject attackTarget;
    private float lastAttactTime;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void MoveToTarget(Vector3 target)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = target;
    }
    void Start()
    {
        print("Ìí¼Ó¼àÌýOnMouseClicked");
     //   MouseManager.instance.OnMouseClicked += MoveToTarget;
        MouseManager.instance.OnMouseClicked += MoveToTarget;
        MouseManager.instance.OnEnemyClicked += EventArract;
    }





    // Update is called once per frame
    private void Update()
    {
        this.SwitchAnimation();
        lastAttactTime -= Time.deltaTime;
    }
    private void SwitchAnimation()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
    private void EventArract(GameObject target)
    {
        Debug.Log("target====", target);
        if(target != null)
        {
            attackTarget = target;
            StartCoroutine(MoveToAttackTarget());

        }
    }
    IEnumerator MoveToAttackTarget()
    {
        agent.isStopped = true;
        transform.LookAt(attackTarget.transform);
        Debug.Log("=======================" + (Vector3.Distance(attackTarget.transform.position, transform.position)));
        while (Vector3.Distance(attackTarget.transform.position,transform.position) > 1)
        {
            agent.destination = attackTarget.transform.position;
            yield return null;

        }
        agent.isStopped = true;
        if(lastAttactTime < 0)
        {
            anim.SetTrigger("Attack");
            lastAttactTime = 0.5f;
        }
    }


}
