using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public void OnStartButtonPress()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
