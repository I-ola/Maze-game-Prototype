using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleted : MonoBehaviour
{
    public event EventHandler OnGameCompleted;

    public static GameCompleted Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnGameCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
