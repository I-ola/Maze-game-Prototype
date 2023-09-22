using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAi : MonoBehaviour
{
 
 

    public static event EventHandler PlayerHasPassed;
 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
       
            PlayerHasPassed?.Invoke(this, EventArgs.Empty);
        }
         
    }

  


}
