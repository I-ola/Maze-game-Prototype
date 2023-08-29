using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 10.0f;
    CharacterController body;
    private bool activateMap = false;
    public GameObject miniMap;
   
    // Start is called before the first frame update
    void Start()
    {
      body = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ActivateMap();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        body.Move(speed * Time.deltaTime * move); 
    }

    private void ActivateMap()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            activateMap = true;        
        }

         if(activateMap == true)
        {
            miniMap.SetActive(true);
        }   
    }
}
    


