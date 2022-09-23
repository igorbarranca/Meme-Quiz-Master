using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float loadEndScreenDelay = 1f;

    Quiz quiz;
    EndScreen endScreen;
    
    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }
    // Start is called before the first frame update
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

        endScreen.SoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete)
        {
            Invoke(nameof(LoadEndScreen), loadEndScreenDelay);
        }
    }

    void LoadEndScreen()
    {
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(true);
        endScreen.ShowFinalScore();

        endScreen.SoundPlayed = true;
    }
}
