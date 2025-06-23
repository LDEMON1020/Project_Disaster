using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScaryScene : MonoBehaviour
{
    public void GoScaryScene()
    {
        SceneManager.LoadScene("Play_Scene_Scary");
    }
}
