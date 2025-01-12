using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditorInternal;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField nameInput; // Saves user's name in Persistence Script

    public GameObject invalidName;

    public TMP_Text recentScoreValueText; // Recent Score Visual Text

    public TMP_Text highScoreValueText; // High Score Visual Text

    public GameObject mainMenu;
    public GameObject recentScoreMenu;
    public GameObject highScoreMenu;
    public GameObject exitMenu;

    private bool isInvalidNameActive = false;

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

    public void Update()
    {
        // Check if the invalidName message is active and any key is pressed
        if (isInvalidNameActive && Input.anyKeyDown)
        {
            invalidName.gameObject.SetActive(false); // Hide the invalidName message
            isInvalidNameActive = false; // Reset the flag
        }
    }

    public void StartGameAndCheckName()
    {
        Debug.Log($"nameInput Text: {nameInput.text}");
        Debug.Log("Button Clicked");

        // Hide the invalidName message if it was previously active
        invalidName.gameObject.SetActive(false);

        // Check if the name input is empty
        if (string.IsNullOrWhiteSpace(nameInput.text))
        {
            invalidName.gameObject.SetActive(true); // Show the invalid name message
            isInvalidNameActive = true; // Set the flag
            return; // Exit the method
        }

        // Save the name and load the next scene
        PersistenceScript.instance.savedCurrentName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void FromOrToRecentScoreMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        recentScoreMenu.SetActive(!recentScoreMenu.activeSelf);
    }

    public void FromOrToHighScoreMenu() 
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        highScoreMenu.SetActive(!highScoreMenu.activeSelf);
    }

    public void FromOrToExitMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        exitMenu.SetActive(!exitMenu.activeSelf);
        Debug.Log($"Exit Menu {exitMenu.activeSelf}");
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
