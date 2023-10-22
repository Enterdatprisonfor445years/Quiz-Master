using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float flTimeToCompleteQuestion = 30f;
    [SerializeField] float flTimeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float flFillFraction;

    float flTimerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        flTimerValue = 0f;
    }

    void UpdateTimer()
    {
        flTimerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if (flTimerValue > 0)
            {
                flFillFraction = flTimerValue / flTimeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                flTimerValue = flTimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(flTimerValue > 0)
            {
                flFillFraction = flTimerValue / flTimeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                flTimerValue = flTimeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnsweringQuestion + ": " +flTimerValue + "=" + flFillFraction);
    }
}
