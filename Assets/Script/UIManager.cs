using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameStartButtonAction()
    {
        SceneManager.LoadScene("Play_Scene");
        
    }

    
}
