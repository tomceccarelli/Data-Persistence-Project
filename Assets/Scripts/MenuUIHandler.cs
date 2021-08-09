using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerNameField;

    // Set the player name to the value of your input field
    public void NewPlayerName()
    {
        string playerName = playerNameField.text;
        MainManager.Instance.playerName = playerName;
    }

    // Load main scene
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
