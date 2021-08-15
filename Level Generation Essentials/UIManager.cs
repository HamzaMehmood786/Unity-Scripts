using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startScreen;
    public GameObject inGameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    public Text levelText;
    public Canvas canvas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        levelText.gameObject.SetActive(false);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        startScreen.SetActive(false);
        inGameScreen.SetActive(false);
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowStartScreenPanel()
    {
        levelText.gameObject.SetActive(true);
        inGameScreen.SetActive(false);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void ShowInGameScreen()
    {
        levelText.gameObject.SetActive(true);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        startScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }


    public IEnumerator ShowGameWinScreenPanel()
    {
        yield return new WaitForSeconds(1f);
        levelText.gameObject.SetActive(false);
        inGameScreen.SetActive(false);
        loseScreen.SetActive(false);
        startScreen.SetActive(false);
        winScreen.SetActive(true);
    }

    public IEnumerator ShowGameOverScreenPanel()
    {
        yield return new WaitForSeconds(1f);
        levelText.gameObject.SetActive(false);
        winScreen.SetActive(false);
        inGameScreen.SetActive(false);
        startScreen.SetActive(false);
        loseScreen.SetActive(true);
    }
}
