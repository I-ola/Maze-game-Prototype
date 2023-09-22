using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    
    CharacterController body;
    //  private bool activateMap = false;
    // public GameObject miniMap;

    private bool canSprint = true;
    
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameCompleted.Instance.OnGameCompleted += GameCompleted_OnGameCompleted;

        body = GetComponent<CharacterController>();
       
    }


    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
           // Debug.Log("movement stopped");
            speed = 0f;
        }
    }

    private void GameCompleted_OnGameCompleted(object sender, System.EventArgs e)
    {
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        
        PlayerMovement();

        if (Input.GetKey(KeyCode.LeftShift) && canSprint)
        {
            speed = 20f;
            StartCoroutine(SprintCountdown());
     
        }
        else
        {
            StartCoroutine(CanSprintAgain());
        }

        //ActivateMap();
    }

    IEnumerator SprintCountdown()
    {
        
        yield return new WaitForSeconds(10);
        canSprint = false;
        speed = 10f;
    }
    
    IEnumerator CanSprintAgain()
    {
        yield return new WaitForSeconds(20);
        canSprint = true;
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        body.Move(speed * Time.deltaTime * move);

       
    }

   /* private void ActivateMap()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            activateMap = true;        
        }

         if(activateMap == true)
        {
            miniMap.SetActive(true);
        }   
    }*/
}
    


