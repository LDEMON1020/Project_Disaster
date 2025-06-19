using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDiasaster : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public GameObject currentDisaster;
    public int currentDisasterType;

    public bool isGameOver;

    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void SpawnNewFruit()
    {
        if (!isGameOver)
        {
            

        }
    }
}
