using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIM : MonoBehaviour {

    /* public GoogleAnalyticsV4 googleAnalytics;*/

   /* public Player Player1;
    public Player Player2;*/

   


    // Main Menu



    public void Start()
    {
        /*googleAnalytics.StartSession(); 
        googleAnalytics.LogScreen("C&C UI");
        googleAnalytics.LogEvent("LocationViewing", "HasViewed", "TheMainMenu", 1);

        googleAnalytics.LogEvent(new EventHitBuilder()
        .SetEventCategory("LocationViewing")
        .SetEventAction("HasViewed")
        .SetEventLabel("TheMainMenu")
        .SetEventValue(1));
        P1Ammo = player1Ammo.GetComponent<Gun>().Ammo ;
        P2Ammo = player1Ammo.GetComponent<Gun>().Ammo ;*/
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

       /* googleAnalytics.LogEvent("LocationViewing", "HasViewed", "Level_1", 1);
        googleAnalytics.LogEvent(new EventHitBuilder()
        .SetEventCategory("LocationViewing")
        .SetEventAction("HasViewed")
       .SetEventLabel("Level_1")
        .SetEventValue(1));*/
    }

    public void QuitGame()
    {
      /*  googleAnalytics.LogEvent("LocationViewing", "HasViewed", "Quit", 1);
        googleAnalytics.LogEvent(new EventHitBuilder()
     .SetEventCategory("LocationViewing")
     .SetEventAction("HasViewed")
    .SetEventLabel("QuitGame")
     .SetEventValue(1));*/
        Debug.Log("Quit");
        Application.Quit();
      
    }

    // Sound

    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Graphics

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Fullscreen

    public void SetFullscreen (bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    // Restart Menu

    public GameObject RestartMenu;
    
    public void Restart()

    {

        SceneManager.LoadScene("Level_1");

    }

    // Pause Menu

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
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

        // Restart Menu if:
       

        /*if (Player1.Playerdeath || Player2.Playerdeath == true)
        {
            RestartMenu.SetActive(true);
        }
        else
        {
            RestartMenu.SetActive(false);
        }*/

    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("C&C UI");
    }

    public void QuitGamePause()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

  

}
