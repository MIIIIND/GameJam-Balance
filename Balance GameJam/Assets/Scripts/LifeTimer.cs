using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public float CurrentTime;
    public float StartingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownText;


    void Start()
    {
        CurrentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        countdownText.text = CurrentTime.ToString("0");

        if (CurrentTime <= 0) 
        {
            CurrentTime= 0;

            // insert Lose screen  
            
        }
        
    }
}
