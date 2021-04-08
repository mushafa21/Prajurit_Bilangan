using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float radius;
    public float time;
    public GameObject[] musuh;
    protected float Timer;
    public float berhenti;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Getar").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * radius;

        Instantiate(musuh[Random.Range(0, musuh.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        Timer += Time.deltaTime;
        if (Timer <= berhenti)
            StartCoroutine(spawnEnemy());
        
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if (Timer >= berhenti)
        {
            StopCoroutine(spawnEnemy());
        }
    }

}
