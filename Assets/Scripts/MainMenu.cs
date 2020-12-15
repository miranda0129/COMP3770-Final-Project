using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text coinsText;

    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("currentLevel", level);
        PlayerPrefs.SetInt("coins", 0);
        SceneManager.LoadScene(level);
    }

    void Start()
    {
        coinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }

}
