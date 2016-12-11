using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas helpMenu;
	public Button startText;
	public Button exitText;
	public string firstLevel = "FPS";

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		helpMenu.enabled = false;
	}

	private void DisableMainMenu() {
		startText.enabled = false;
		exitText.enabled = false;
	}

	private void EnableMainMenu() {
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void HelpPress() {
		helpMenu.enabled = true;
		DisableMainMenu ();
	}

	public void CloseHelp() {
		helpMenu.enabled = false;
		EnableMainMenu ();
	}

	/**
	 * Bring up the quit dialogue when player presses quit button.
	 */ 
	public void QuitPress() {
		quitMenu.enabled = true;
		DisableMainMenu ();
	}

	/**
	 * If player does not want to quit in the quit dialogue.
	 */
	public void DoNotQuitPress() {
		quitMenu.enabled = false;
		EnableMainMenu ();
	}

	public void StartLevel() {
		SceneManager.LoadScene (firstLevel);
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
