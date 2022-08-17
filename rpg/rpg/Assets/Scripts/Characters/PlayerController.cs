using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
    void Start()
    {
        print("Ìí¼Ó¼àÌýOnMouseClicked");
     //   MouseManager.instance.OnMouseClicked += MoveToTarget;
        MouseManager.instance.OnMouseClicked += MoveToTarget;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
