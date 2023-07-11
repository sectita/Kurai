using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AmmoText.ammoAmount = 40;
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
