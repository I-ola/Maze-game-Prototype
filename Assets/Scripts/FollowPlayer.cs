using System;
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

    public static FollowPlayer Instance { get; private set; }

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;

    public event EventHandler CaughtPlayer;

    private float dist;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        TriggerAi.PlayerHasPassed += TriggerAI_PlayerHasPassed;

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void TriggerAI_PlayerHasPassed(object sender, EventArgs e)
    {
        
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Hide();
        }
    }


    void Update()
    {
        agent.SetDestination(player.transform.position);

        dist = Vector3.Distance(agent.transform.position, player.transform.position);
        CaughtPlayer?.Invoke(this, EventArgs.Empty);
        //Debug.Log(dist);

       

    }

 

    private void Show()
    {
        gameObject.SetActive(true);
    }  
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool HasPlayerBeenCaught()
    {
       // Debug.Log("player is near");
        return dist < 20;
        

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
