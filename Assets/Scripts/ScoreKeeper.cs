using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int CorrectAnswers { get; private set; }
    public int QuestionsSeen { get; private set; }

    public void IncrementCorretAnswers()
    {
        CorrectAnswers++;
    }
    public void IncrementQuestionsSeen()
    {
        QuestionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(CorrectAnswers / (float)QuestionsSeen * 100);
    }
}
