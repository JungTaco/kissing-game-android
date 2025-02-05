using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
	public GameObject Instructions;

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleSettingsVisibility(bool toggle)
    {
        Settings.SetActive(toggle);
    }

	public void ToggleInstructionsVisibility(bool toggle)
	{
		Instructions.SetActive(toggle);
	}

	public void QuitGame()
    {
        Application.Quit();
    }

}
