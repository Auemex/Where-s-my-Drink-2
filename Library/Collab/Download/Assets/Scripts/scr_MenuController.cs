using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_MenuController : MonoBehaviour
{
    public Button mm_button;
    public Button st_button;
    public Button quit_button;
    public Button c_button;
    public Button resume_button;
    public GameObject PauseText;
    public bool isPaused = false;

    void Start()
    {

        Button MMB = mm_button.GetComponent<Button>();
        MMB.onClick.AddListener(MMOnClick);

        Button STB = st_button.GetComponent<Button>();
        STB.onClick.AddListener(StartOnClick);

        Button CB = c_button.GetComponent<Button>();
        CB.onClick.AddListener(ControlsOnClick);

        Button QB = quit_button.GetComponent<Button>();
        QB.onClick.AddListener(QuitOnClick);

        Button RB = resume_button.GetComponent<Button>();
        RB.onClick.AddListener(ResumeOnClick);

    }

    void MMOnClick()
    {
        Debug.Log("You have clicked the main menu button");
        SceneManager.LoadScene(sceneName: "Main Menu");
    }

    void StartOnClick()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene(sceneName: "S_Demo");
    }

    void ControlsOnClick()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene(sceneName: "Controls");
    }

    void QuitOnClick()
    {   
        Application.Quit();
        Debug.Log("You have clicked the quit button");
    }

    void ResumeOnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        scr_exitgame P = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_exitgame>();
        Debug.Log("You have clicked the resume button");
        Time.timeScale = 1;
        PauseText.SetActive(false);
        P.isPaused = false;
    }

}
