using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public PersistenceScript persistenceScript;

    public TMP_InputField nameInput; // Saves user's name in Persistence Script

    public TMP_Text recentScoreText; // Recent Score Visual Text

    public TMP_Text highScoreText; // High Score Visual Text

    public void StartGame()
    {
        Debug.Log("Button Clicked");
        persistenceScript.savedCurrentName = nameInput.text;
        SceneManager.LoadScene(1);
    }
}
