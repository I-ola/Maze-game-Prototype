using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
   /* private float speed = 5.0f;
    public GameObject player;
    private float rotSpeed = 5.0f;
    public bool canChase = false; */

    public NavMeshAgent agent;
    public GameObject player;
    public GameObject activateMe;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(player.transform.position);
        
    }

   /* public void Awake()
    {
        if (canChase)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            Vector3 direction = (player.transform.position - this.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
            this.transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
        }
    }*/
}
