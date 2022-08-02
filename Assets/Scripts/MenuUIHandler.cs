using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
            
        if (ScoreManager.Instance.CurrentPlayer != "")
        {
            inputField.text = ScoreManager.Instance.CurrentPlayer;
        }
    }

    public void StartGame()
    {
        ScoreManager.Instance.CurrentPlayer = inputField.text;

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        
        
        Application.Quit();
    }
}
