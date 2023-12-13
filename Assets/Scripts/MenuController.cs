using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{

    public Button Play_Button;
    public Button Info_Button;
    public Button Quit_Button;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Information()
    {
        SceneManager.LoadScene(2);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit_game()
    {
        Application.Quit();
        Debug.Log("Closed Application");
    }
}
