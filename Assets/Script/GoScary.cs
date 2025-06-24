using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScary : MonoBehaviour
{
    public void GoScaryScene()
    {
        SceneManager.LoadScene("ScaryScene_Start");
    }
}
