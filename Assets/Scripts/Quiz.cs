using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] Image backgroundImage;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    int questionIndex = 0;
    
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly = true;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    private void Start()
    {
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }
    private void Update()
    {
        timerImage.fillAmount = timer.FillFraction;

        if (timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    // This function is connected to the OnClick() of the answer buttons 
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }

    void DisplayAnswer(int index)
    {
        if(index == -1) { return; }
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.color = new Color32(130, 255, 100, 255);

            AudioSource.PlayClipAtPoint(currentQuestion.CorrectAnswerSFX, Camera.main.transform.position, .2f);

            scoreKeeper.IncrementCorretAnswers();
        }
        else if (index != currentQuestion.GetCorrectAnswerIndex())
        {
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.color = new Color32(255, 70, 70, 255);

            AudioSource.PlayClipAtPoint(currentQuestion.WrongAnswerSFX, Camera.main.transform.position, .2f);
        }

    }

    void GetNextQuestion()
    {
        ManageQuestionIndex();

        SetButtonState(true);
        DisplayQuestion();
        SetupButtons();
        SetupBackground();

        progressBar.value++;
        scoreKeeper.IncrementQuestionsSeen();
    }

    void ManageQuestionIndex()
    {
        currentQuestion = questions[questionIndex];
        
        questionIndex++;
        if(questionIndex == questions.Count)
        {
            //FINE DEL GIOCO
            questionIndex = 0;
        }
    }
    
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        AudioSource.PlayClipAtPoint(currentQuestion.QuestionSFX, Camera.main.transform.position, 0.15f);  
    }

    void SetupButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);

            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = currentQuestion.GetButtonSprite(i);

            buttonImage.color = new Color(255, 255, 255, 255);
        }
    }

    void SetupBackground()
    {
        backgroundImage.sprite = currentQuestion.BackgroundSprite;
    }
}
