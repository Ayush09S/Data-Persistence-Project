using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PersistenceScript : MonoBehaviour
{
    public static PersistenceScript instance;

   // public Button startButton;

    public string savedCurrentName; // Current User's Name
    public int savedCurrentScore;

    public string savedHighScoreName; // High Score Holder's Name
    public int savedHighScore; 

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(startButton.onClick())
        {
            Debug.Log("Persistance Script Active During Game");
            Debug.Log($"Name: {savedCurrentName}");

        }
        */
    }
}
