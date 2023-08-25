using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentManager : MonoBehaviour
{
    NavMeshAgent agents;
    // Start is called before the first frame update
    void Start()
    {
        GameObject a = GameObject.FindGameObjectWithTag("AI");
        agents = a.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
