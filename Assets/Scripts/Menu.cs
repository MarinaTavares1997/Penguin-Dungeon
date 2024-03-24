using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public GameObject creditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(cena);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsPanel.SetActive(false);
    }
}
