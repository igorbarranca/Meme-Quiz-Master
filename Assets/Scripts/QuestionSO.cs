using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,5)]
    [SerializeField] string question = "Enter new question here";
    //[SerializeField] AnswerButton[] answers = new AnswerButton[2];
    [SerializeField] string[] answers = new string[2];
    [Header("Answer Button Sprites")]
    [SerializeField] Sprite[] buttonSprites = new Sprite[2];
    
    [field: SerializeField] public Sprite BackgroundSprite { get; private set; }
    [field: SerializeField] public AudioClip QuestionSFX { get; private set; }
    [field: SerializeField] public AudioClip CorrectAnswerSFX { get; private set; }
    [field: SerializeField] public AudioClip WrongAnswerSFX { get; private set; }

    [SerializeField] int correctAnswerIndex;

    
    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
    public Sprite GetButtonSprite(int index)
    {
        return buttonSprites[index];
    }
}
