using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public Canvas replayMenu;
    public Button replayButton;
    public Button quitToMenuButton;
    public Button quitGameButton;
    public string firstScene = "FPS";
    public string mainMenu = "StartMenu";

    void Start()
    {
        /*
        replayMenu = GetComponent<Image>();
        replayButton = replayButton.GetComponent<Button>();
        quitToMenuButton = quitToMenuButton.GetComponent<Button>();
        quitGameButton = quitGameButton.GetComponent<Button>();
        */
        Debug.Log("Disabling replay menu");
        replayMenu.enabled = false;
    }

    public void EnableMenu()
    {
        Debug.Log("Enabling replay menu");
        replayMenu.enabled = true;
        replayButton.enabled = true;
        quitToMenuButton.enabled = true;
        quitGameButton.enabled = true;
    }

    public void PlayAgain()
    {
        Debug.Log("Play Again pressed");
        SceneManager.LoadScene(firstScene);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }


}
