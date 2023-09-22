using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCompletedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTakenText;
    void Start()
    {
        GameCompleted.Instance.OnGameCompleted += GameCompleted_OnGameCompleted;
        Hide();
    }

    private void GameCompleted_OnGameCompleted(object sender, System.EventArgs e)
    {
        Show();

        timeTakenText.text ="Time Taken:" + CountdownTimer.Instance.GetTimeTaken().ToString("0") + "min";
    }

 

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
