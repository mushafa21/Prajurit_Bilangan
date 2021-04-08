using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject confirmUi;
    public GameObject ConfirmUiMenang;
    public GameObject ConfirmUiKalah;
    public GameObject winScreen;
    public GameObject mulaiUi;
    public AudioClip ui1;
    public AudioClip ui2;
    public AudioClip ui3;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {
       
    }

    public void Pause()
    {
        SoundManager.instance.PlayGanti(ui1);
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        SoundManager.instance.PlayGanti(ui2);
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Manager.winCon = 0;

    }

    public void LoadConfirm()
    {
        SoundManager.instance.PlayGanti(ui1);
        confirmUi.SetActive(true);
        pauseMenuUi.SetActive(false);
    }
    public void Back()
    {
        SoundManager.instance.PlayGanti(ui2);
        confirmUi.SetActive(false);
        pauseMenuUi.SetActive(true);

    }

    public void LoadConfirmMenang()
    {
        SoundManager.instance.PlayGanti(ui1);
        ConfirmUiMenang.SetActive(true);
        winScreen.SetActive(false);
    }

    public void BackMenang()
    {
        SoundManager.instance.PlayGanti(ui2);
        ConfirmUiMenang.SetActive(false);
        winScreen.SetActive(true);
    }

    public void Mulai()
    {
        SoundManager.instance.PlayGanti(ui2);
        mulaiUi.SetActive(false);
        Time.timeScale = 1f;
    }

}
