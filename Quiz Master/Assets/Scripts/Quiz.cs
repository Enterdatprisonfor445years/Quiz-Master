using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int intCorrectAnswerIndex;
    [SerializeField] Sprite sprDefaultAnswerSprite;
    [SerializeField] Sprite sprCorrectAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i< answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    
    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }
        else
        {
            intCorrectAnswerIndex = question.GetCorrectAnswerIndex();
            string strCorrectAnswer = question.GetAnswer(intCorrectAnswerIndex);
            questionText.text = "Sorry the correct answer was;\n" + strCorrectAnswer;
            buttonImage = answerButtons[intCorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = sprCorrectAnswerSprite;
        }
    }
}