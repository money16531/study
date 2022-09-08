using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyStates { GUAED,PATROL,CHASE,DEAD}
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControlled : MonoBehaviour
{
    public EnemyStates enemyStates;
    // Start is called before the first frame update
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void SwitchStates()
    {
        switch (enemyStates)
        {
            case EnemyStates.GUAED:
                break;
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                break;
            case EnemyStates.DEAD:
                break;
        }
    }
    void Updata()
    {
        this.SwitchStates();
    }
}
