using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    //Start up UI
    public GameObject startUpUI;

    public Button startButton;
    public Button optionButton;
    public Button exitButton;
    public Button confirmButton;
    public Button backButton;

    public Button resumeButtonOnPause;
    public Button optionButtonOnPause;
    public Button exitButtonOnPause;

    public Transform television;
    public Transform startPanel;
    public Transform optionPanel;
    public Transform pauseCanvas;

    public AudioClip enter;
    private bool isPause = false;
    private bool isEnterMenuShown = true;

	void Start () {
        Time.timeScale = 0;
        startUpUI.SetActive(true);



    startButton.onClick.AddListener(ShowEnterMenu);
        optionButton.onClick.AddListener(ShowOptionMenu);
        backButton.onClick.AddListener(ShowEnterMenu);
        exitButton.onClick.AddListener(ExitGame);
        confirmButton.onClick.AddListener(ActivateGame);
        resumeButtonOnPause.onClick.AddListener(PauseGame);
        exitButtonOnPause.onClick.AddListener(ExitGame);
        Cursor.visible = true;
        television.GetComponent<ChangeSize>().SetMax();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
    }
    private void ShowOptionMenu()
    {
        if (isEnterMenuShown)
        {
            startPanel.gameObject.SetActive(false);
            optionPanel.gameObject.SetActive(true);
            isEnterMenuShown = false;
        }
    }
    private void ShowEnterMenu()
    {
        if (!isEnterMenuShown)
        {
            startPanel.gameObject.SetActive(true);
            optionPanel.gameObject.SetActive(false);
            isEnterMenuShown = true;
        }
    }
    private void ActivateGame()
    {
        Time.timeScale = 1;
        television.GetComponent<ChangeSize>().Complete();
        startUpUI.SetActive(false);
        Cursor.visible = false;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void PauseGame()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
            Cursor.visible = false;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);
            Cursor.visible = true;
            isPause = true;
        }
    }
}
