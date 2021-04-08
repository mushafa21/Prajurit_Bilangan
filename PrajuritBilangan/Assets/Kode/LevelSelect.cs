using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;
    public bool stage1;
    public bool stage2;
    public bool stage3;
    public Sprite levelLock1;
    public Sprite levelLock2;
    public Sprite levelLock3;

    void Start()
    {
        if (stage1)
        {
            int levelReached_1 = PlayerPrefs.GetInt("levelReached_1", 1);

            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i + 1 > levelReached_1)
                {
                    levelButtons[i].interactable = false;
                    levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    levelButtons[i].GetComponent<Image>().sprite = levelLock1;
                }
            }
        }
        if (stage2)
        {
            int levelReached_2 = PlayerPrefs.GetInt("levelReached_2", 1);

            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i + 1 > levelReached_2)
                {
                    levelButtons[i].interactable = false;
                    levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    levelButtons[i].GetComponent<Image>().sprite = levelLock2;
                }
            }
        }
        if (stage3)
        {
            int levelReached_3 = PlayerPrefs.GetInt("levelReached_3", 1);

            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i + 1 > levelReached_3)
                {
                    levelButtons[i].interactable = false;
                    levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    levelButtons[i].GetComponent<Image>().sprite = levelLock3;
                }
            }
        }
    }

    
}
