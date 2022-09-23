using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] ScoreKeeper scoreKeeper;

    [SerializeField] AudioClip siumSFX;
    [SerializeField] AudioClip diarrheaSFX;

    int finalScore;
    public bool SoundPlayed { get; set; }

    public void ShowFinalScore()
    {
        finalScore = scoreKeeper.CalculateScore();
        finalScoreText.text = "CONGRATULATIONS!\nYOU SCORED: " +
                                finalScore.ToString() + "%";
        
        PlayResultSound();
    }

    void PlayResultSound()
    {
        if (SoundPlayed) { return; }
        
        if (finalScore == 100)
        {
            AudioSource.PlayClipAtPoint(siumSFX, Camera.main.transform.position, 0.2f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(diarrheaSFX, Camera.main.transform.position, 0.2f);
        }
    }
}
