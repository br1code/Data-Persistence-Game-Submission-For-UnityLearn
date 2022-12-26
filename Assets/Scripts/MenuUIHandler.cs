using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerNameInput;

    private void Start()
    {
        if (GameManager.Instance != null && !string.IsNullOrEmpty(GameManager.Instance.BestScorePlayerName))
        {
            bestScoreText.text =
                $"Best Score: {GameManager.Instance.BestScorePlayerName} - {GameManager.Instance.BestScoreValue} points";
        }
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(playerNameInput.text))
        {
            return;
        }

        GameManager.Instance.PlayerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}