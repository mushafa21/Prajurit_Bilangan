using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] spawner;
    [SerializeField]
    public int[] jumlahMenangUpdate;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SpawnWave(int wave)
    {
        spawner[wave].SetActive(true);
    }
}
