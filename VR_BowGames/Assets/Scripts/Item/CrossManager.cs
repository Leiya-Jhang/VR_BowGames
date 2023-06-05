using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrossManager : MonoBehaviour
{
    private GameObject onRoad;
    public GameObject[] cars;
    public Transform[] spawnPos;

    private void Start()
    {
        StartCoroutine(Carspawn());
    }

    IEnumerator Carspawn()
    {
        while (true)
        {
            int i = Random.Range(0, 2);
            int car = Random.Range(0, 2);
            CarSpawn(i,car);
            yield return new WaitForSeconds(2);
        }
    }

    private void CarSpawn(int i,int car)
    {
        if (onRoad==null)
        {
            onRoad = Instantiate(cars[car], spawnPos[i].position, spawnPos[i].rotation);
        }
    }
}