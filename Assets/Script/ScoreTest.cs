using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI FieldScore;
    // Start is called before the first frame update
    void Start()
    {
     FieldScore.text = "Score : " + HighScore.Load(1).ToString();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
