using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject PausePanel;
    public AudioMixer audioMixer;
    public static bool GameIsPaused = false;


    private void Start()
    {
        PausePanel.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgainBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // public void SettingsBtn()
    // {
    //     SettingPanel.SetActive(true);
    // }

    // public void CloseSettingsBtn()
    // {
    //     SettingPanel.SetActive(false);
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        SettingPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SetMusic(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
    public void SetSound()
    {
        //SettingPanel.SetActive(false);
    }
    public void SetFullScreen(bool open)
    {
        Screen.fullScreen = open;
    }

    public void ClosePauseBtn()
    {
        PausePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
