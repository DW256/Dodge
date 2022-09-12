using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject GOverMenu;
    public int viewtracker; // tar ganti enum kalau ingat; 1 Start, 2 Game, 3 GOver;
    // Start is called before the first frame update
    void Start()
    {
        PauseTime();
        viewtracker = 1;
        StartMenu.SetActive(true);
        GOverMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        ResumeTime();
        StartMenu.SetActive(false);
        viewtracker = 2;
    }

    public void GOver()
    {
        PauseTime();
        GOverMenu.SetActive(true);
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
