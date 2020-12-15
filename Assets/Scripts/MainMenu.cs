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
        SceneManager.LoadScene(level);
    }

    void Start()
    {
        coinsText.text = "0";
    }

}
