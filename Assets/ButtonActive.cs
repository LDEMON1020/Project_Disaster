using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    public Button GameRestart;
    public Button GameTitle;

    public bool ButtonActivate = false;

    public float timer = 0.0f;

    void Start()
    {
        GameRestart.gameObject.SetActive(false);
        GameTitle.gameObject.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!ButtonActivate && timer >= 4f)
        {
            ButtonActivate = true;
            ActivatingButton();
        }
    }

    void ActivatingButton()
    {
        GameRestart.gameObject.SetActive(true);
        GameTitle.gameObject.SetActive(true);
    }
}