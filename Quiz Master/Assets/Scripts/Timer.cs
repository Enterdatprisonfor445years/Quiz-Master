using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float flTimeToCompleteQuestion = 30f;
    [SerializeField] float flTimeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue<=0)
            {
                isAnsweringQuestion = false;
                timerValue = flTimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue<=0)
            {
                isAnsweringQuestion = true;
                timerValue = flTimeToCompleteQuestion;
            }
        }

        Debug.Log(timerValue);
    }
}
