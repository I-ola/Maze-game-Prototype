using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    private float timerTime;

    public static CountdownTimer Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    
        
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            timerImage.fillAmount = 0;   
        }
        else if (GameManager.Instance.IsGameCompleted())
        {
           
            timerTime = timerImage.fillAmount;
            timerImage.fillAmount = 0;
           
           
        }
       
    }

    private void Update()
    {
        timerImage.fillAmount = GameManager.Instance.GetPlayingTime();
        timerTime = timerImage.fillAmount;
        

    }

    public float GetTimeTaken()
    {
      
        return timerTime ;
       
    }
 
    
    
    

    
    
}
