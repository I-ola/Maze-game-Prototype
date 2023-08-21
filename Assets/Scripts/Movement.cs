using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public bool notTouching = true;
    
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
     PlayerMovement();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "wall")
        {
            notTouching = false;
        }

        notTouching = true;
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

      /*  while (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed = 30f;
        }*/

        if (notTouching)
        {
            transform.Translate(new Vector3(0, 0, verticalInput) * speed * Time.deltaTime);
            transform.Translate(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
        }
    }

}
