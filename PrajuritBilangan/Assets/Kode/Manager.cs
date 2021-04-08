using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public GameObject panel;
    public Weapon currentWeapon;
    public GameObject musicManager;
    public Weapon currentWeapon1;
    public Weapon currentWeapon2;
    public AudioClip ui1;
    public AudioClip ui2;
    public AudioClip paper;
    public Button button1;
    public GameObject wep;
    public Button button2;
    public AudioClip ganti;
    public static int winCon = 0;
    public GameObject winScreen;
    public int jumlahMenang;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI textWaveKe;
    public TextMeshProUGUI textWaveMulai;
    public Animator animator;
    public string jenisStage;
    public int levelKe;
    public bool menu = false;
    public int jumlahWave = 1;
    public int waveKe = 0;
    public int waveKeText;
    public GameObject go;
    public WaveSpawner other;
    void Start()
    {
        waveKeText = waveKe + 2;
        winCon = 0;
        if (!menu)
        {
            textWaveMulai.enabled = false;
            if (jumlahWave < 2)
                textWaveKe.enabled = false;
            if (jumlahWave > 1)
            {
                go = GameObject.Find("WaveSpawner");
                other = (WaveSpawner)go.GetComponent(typeof(WaveSpawner));
            }
        }
          if (menu)
            Time.timeScale = 1;
        if (button1 != null && button2 != null)
        {
            ColorBlock colors = button2.colors;
            colors.normalColor = new Color32(100, 100, 100, 150);
            colors.highlightedColor = new Color32(100, 100, 100, 120);
            button2.colors = colors;


            ColorBlock colors2 = button1.colors;
            colors2.normalColor = Color.white;
            colors2.highlightedColor = new Color32(255, 255, 255, 255);
            button1.colors = colors2;
        }
        musicManager = GameObject.Find("MusicManager");
        

    }

    void Update()
    {
        waveKeText = waveKe + 2;
        if (tmp != null)
        {
            tmp.text = winCon.ToString() + " / " + jumlahMenang.ToString();
            if (winCon == jumlahMenang)
            {
                if(jumlahWave != 0)
                {
                    jumlahWave = jumlahWave - 1;
                }
                if (jumlahWave == 0)
                {
                    Menang();
                    tmp.enabled = false;
                    jumlahMenang = 0;
                    winCon = 0;
                }
                else
                {
                    jumlahMenang = 0;
                    StartCoroutine(NextWave());
                }
    
            }
        }

        if (wep != null)
        {
            wep.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSprite;
        }
    }
    public void Menang()
    {
        if (PlayerPrefs.GetInt(jenisStage) < levelKe)
        {
            PlayerPrefs.SetInt(jenisStage, levelKe);
        }
        StartCoroutine(PlayWin());
    }
    IEnumerator NextWave()
    {
        tmp.enabled = false;
        textWaveKe.enabled = false;
        textWaveMulai.text = "Gelombang Ke-" + waveKeText.ToString() + " Akan Dimulai!";
        textWaveMulai.enabled = true;
        winCon = 0;
        jumlahMenang = other.jumlahMenangUpdate[waveKe];
        yield return new WaitForSeconds(2f);
        textWaveMulai.enabled = false;
        textWaveKe.enabled = true;
        textWaveKe.text = "Gelombang Ke-" + waveKeText.ToString();
        other.SpawnWave(waveKe);
        waveKe = waveKe + 1;
        tmp.enabled = true;
    }
    IEnumerator PlayWin()
    {
        yield return new WaitForSeconds(.5f);
        SoundManager.instance.Stop();
        yield return new WaitForSeconds(.5f);
        winScreen.SetActive(true);
        SoundManager.instance.WinMusic();
        Time.timeScale = 0f;
    }

    public void Aktif()
    {
        SoundManager.instance.PlayGanti(ganti);
        ColorBlock colors = button1.colors;
        colors.normalColor = new Color32(100, 100, 100, 150);
        colors.highlightedColor = new Color32(100, 100, 100, 120);
        button1.colors = colors;


        ColorBlock colors2 = button2.colors;
        colors2.normalColor = Color.white;
        colors2.highlightedColor = new Color32(255, 255, 255, 255);
        button2.colors = colors2;
    }

    public void Aktif2()
    {
        SoundManager.instance.PlayGanti(ganti);
        ColorBlock colors = button2.colors;
        colors.normalColor = new Color32(100, 100, 100, 150);
        colors.highlightedColor = new Color32(100, 100, 100, 120);
        button2.colors = colors;


        ColorBlock colors2 = button1.colors;
        colors2.normalColor = Color.white;
        colors2.highlightedColor = new Color32(255, 255, 255, 255);
        button1.colors = colors2;
    }

    public void Wep1()
    {
        currentWeapon = currentWeapon1;
    }

    public void Wep2()
    {
        currentWeapon = currentWeapon2;
    }
    public void SwitchScene(string keScene)
    {
        SceneManager.LoadScene(keScene);
    }

    public void ShowPanel(GameObject show)
    {
        MusicManager.instance.PlayUI(ui1);
        show.SetActive(true);
    }

    public void HidePanel(GameObject hide)
    {
        MusicManager.instance.PlayUI(ui2);
        hide.SetActive(false);
    }

    public void NextSlide(string scene)
    {
        StartCoroutine(SlideNext(scene));
    }
    public void PrevSlide(string scene)
    {
        StartCoroutine(SlidePrev(scene));
    }

    IEnumerator SlideNext(string scene)
    {
        panel.SetActive(false);
        MusicManager.instance.PlayUI(paper);
        animator.SetTrigger("ToNext");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);

    }
    IEnumerator SlidePrev(string scene)
    {
        panel.SetActive(false);
        MusicManager.instance.PlayUI(paper);
        animator.SetTrigger("ToBack");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);

    }
    public void KeLevel(string level)
    {
        Destroy(musicManager);
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void FromBG(string scene)
    {
        StartCoroutine(BGFrom(scene));
    }

    public void ToBG(string scene)
    {
        StartCoroutine(BGTo(scene));
    }

    IEnumerator BGTo(string scene)
    {
        panel.SetActive(false);
        MusicManager.instance.PlayUI(paper);
        animator.SetTrigger("ToBG");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(scene);

    }

    IEnumerator BGFrom(string scene)
    {
        panel.SetActive(false);
        animator.SetTrigger("FromBG");
        yield return new WaitForSeconds(0.3f);
        MusicManager.instance.PlayUI(paper);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);

    }

}

