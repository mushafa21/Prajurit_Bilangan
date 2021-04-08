using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
   
    public GameObject[] scene;
    public int index = 0;
    public int indexN;
    public int indexP;
    public GameObject backButton;
    public GameObject nextButton;
    public AudioClip nextSound;
    public AudioClip backSound;
    void Start()
    {
       
    }

    
    void Update()
    {
        indexN = index + 1;
        indexP = index - 1;
        if (index == 0)
            indexP = scene.Length - 1;
        if (index == scene.Length - 1)
            indexN = 0;
        scene[indexN].SetActive(false);
        scene[indexP].SetActive(false);
        scene[index].SetActive(true);
        if (index == 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);

        }
        if (index == scene.Length - 1)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        index++;
        SoundManager.instance.PlayGanti(nextSound);
    }
    public void Back()
    {
        index--;
        SoundManager.instance.PlayGanti(backSound);
    }
}
