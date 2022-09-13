using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public ScoreManager Score_Manager;
    public GameObject StartMenu;
    public GameObject GOverMenu;
    public TextMeshProUGUI Times;
    public TextMeshProUGUI GameOverMessage;

    public int viewtracker; // tar ganti enum kalau ingat; 1 Start, 2 Game, 3 GOver;
    // Start is called before the first frame update
    void Start()
    {
        PauseTime();
        viewtracker = 1;
        StartMenu.SetActive(true);
        GOverMenu.SetActive(false);
        Times.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (viewtracker == 2)
        {
            Times.text = TimeSpan.FromSeconds(Score_Manager.GetSeconds()).ToString("hh':'mm':'ss");
        }
    }

    public void startGame()
    {
        ResumeTime();
        StartMenu.SetActive(false);
        Times.gameObject.SetActive(true);
        viewtracker = 2;
    }

    public void GOver()
    {
        PauseTime();
        GOverMenu.SetActive(true);
        Times.gameObject.SetActive(false);
        GameOverMessage.text = "You Survived for : \n" + TimeSpan.FromSeconds(Score_Manager.GetSeconds()).ToString("hh':'mm':'ss");
        viewtracker = 3;
    }

    private void PauseTime()
    {
        Time.timeScale = 0;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Test_Scene");
    }

}
