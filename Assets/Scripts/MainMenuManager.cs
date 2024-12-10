using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField nameInput; // Saves user's name in Persistence Script

    public TMP_Text recentScoreValueText; // Recent Score Visual Text

    public TMP_Text highScoreValueText; // High Score Visual Text

    public GameObject exitMenu;

    public void Awake()
    {
        if (PersistenceScript.instance.savedRecentScore != 0)
        {
            highScoreValueText.text = PersistenceScript.instance.savedHighName + ": " + PersistenceScript.instance.savedHighScore; // Displays high score with the Player Name
            recentScoreValueText.text = PersistenceScript.instance.savedRecentName + ": " + PersistenceScript.instance.savedRecentScore; // Displays recent score with the Player Name
        }
        else
        {
            highScoreValueText.text = "0";
            recentScoreValueText.text = "0";
        }
    }

    public void StartGame()
    {
        Debug.Log("Button Clicked");
        PersistenceScript.instance.savedCurrentName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitMenu()
    {
        exitMenu.SetActive(true);
    }
    public void ReturnToMenu()
    {
        exitMenu.SetActive(false);
    }
    public void ConfirmedExitGame()
    {
        PersistenceScript.instance.SaveScores();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
