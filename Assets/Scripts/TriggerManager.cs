using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public TriggerAi trigger;
    public GameObject aiMonster;
  
    
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.startChase == true)
        {
            aiMonster.SetActive(true);
        }
    }
}
