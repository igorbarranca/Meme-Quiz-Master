using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    [SerializeField] GameObject creditsText;
    
    public void ActivateCreditsText()
    {
        creditsText.SetActive(true);
    }
}
