using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] private Button PauseButton;
    [SerializeField] private Canvas PauseScreen;
    private AudioSource BGMusic,SFXSound;

    private GameObject Background, Board, GamePaused, Resume, Settings, Restart, Home
        ,  Music1, SFX1, Back, AreYouSure,SFXOn,SFXOff,MusicOn,MusicOff,Yeslvl,Nolvl,YesQuit,NoQuit,restTxt,QuitTxt;

    private void Start()
    {
        BGMusic = Camera.main.GetComponent<AudioSource>();
        SFXSound=GetComponent<AudioSource>();
        
        foreach(Transform child in PauseScreen.transform)
        {
            if (child.name == "Background")
            {
                Background= child.gameObject;
            }
            if (child.name == "Board")
            {
                Board = child.gameObject;
            }
            if (child.name == "Game Paused")
            {
                GamePaused = child.gameObject;
            }
            if (child.name == "Resume")
            {
                Resume = child.gameObject;
            }
            if (child.name == "Settings")
            {
                Settings = child.gameObject;
            }
            if (child.name == "Restart")
            {
                Restart = child.gameObject;
            }
            if (child.name == "Home")
            {
                Home = child.gameObject;
            }
           
            if (child.name == "Music1")
            {
                Music1 = child.gameObject;
            }
            if (child.name == "SFX1")
            {
                SFX1 = child.gameObject;
            }
            if (child.name == "Back")
            {
                Back = child.gameObject;
            }
            if (child.name == "AreYouSure")
            {
                AreYouSure = child.gameObject;
            }
        }
        foreach(Transform child in SFX1.transform)
        {
            if(child.name=="On (1)")
            {
                SFXOn = child.gameObject;
            }
            if (child.name == "Off (1)")
            {
                SFXOff = child.gameObject;
            }
        }
        foreach (Transform child in Music1.transform)
        {
            if (child.name == "On")
            {
                MusicOn = child.gameObject;
            }
            if (child.name == "Off")
            {
                MusicOff = child.gameObject;
            }
        }
        foreach(Transform child in AreYouSure.transform)
        {
            if (child.name == "RstLvLTxt")
            {
                restTxt = child.gameObject;
            }
            if (child.name == "HomeTxt")
            {
                QuitTxt = child.gameObject;
            }
            if (child.name == "YesLvl")
            {
                Yeslvl=child.gameObject;
            }
            if (child.name == "NoLvl")
            {
                Nolvl=child.gameObject;
            }
            if (child.name == "YesQuit")
            {
                YesQuit=child.gameObject;
            }
            if (child.name == "NoQuit")
            {
                NoQuit=child.gameObject;
            }

        }
        PauseButton.enabled = true;
        PauseScreen.enabled = false;
        


        //end of start
    }

    public void pressPause()
    {
        SFXSound.Play();
        Time.timeScale = 0f;
        BGMusic.mute = true;
        PauseButton.enabled = false;
        PauseScreen.enabled = true;
        Background.SetActive(true);
        Board.SetActive(true);
        GamePaused.SetActive(true);
        Resume.SetActive(true);
        Settings.SetActive(true);
        Restart.SetActive(true);
        Home.SetActive(true);
        
        Music1.SetActive(false);
        SFX1.SetActive(false);
        Back.SetActive(false);
        AreYouSure.SetActive(false);
    }
    public void ResumeTogame()
    {
        SFXSound.Play();
        Time.timeScale = 1f;
        PauseButton.enabled = true;
        PauseScreen.enabled = false;
        if (BGMusic.enabled)
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                BGMusic.mute = false;
            }
            else
            {
                BGMusic.mute = true;
            }
        }
       
    }
    public void MusicSettings()
    {
        SFXSound.Play();
        Resume.SetActive(false);
        Settings.SetActive(false);
        Restart.SetActive(false);
        Home.SetActive(false);
       
        Music1.SetActive(true);
        SFX1.SetActive(true);
        Back.SetActive(true);
        if (PlayerPrefs.GetInt("Music") == 1){
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SFX") == 1)
        {
            SFXOn.SetActive(true);
            SFXOff.SetActive(false);
        }
        else
        {
            SFXOn.SetActive(false);
            SFXOff.SetActive(true);
        }
    }

    public void TurnSFXOn()
    {
        PlayerPrefs.SetInt("SFX", 1);
        SFXOn.SetActive(true);
        SFXOff.SetActive(false);
        SFXSound.enabled = true;
    }
    public void TurnSFXOff()
    {
        PlayerPrefs.SetInt("SFX", 0);
        SFXOn.SetActive(false);
        SFXOff.SetActive(true);
        SFXSound.enabled = false;
    }
    public void TurnMusicOn()
    {
        PlayerPrefs.SetInt("Music", 1);
        MusicOn.SetActive(true);
        MusicOff.SetActive(false);
        BGMusic.enabled = true;
    }
    public void TurnMusicOff()
    {
        PlayerPrefs.SetInt("Music", 0);
        MusicOn.SetActive(false);
        MusicOff.SetActive(true);
        BGMusic.enabled=false;
    }

    public void GoBack()
    {
        SFXSound.Play();
        Resume.SetActive(true);
        Settings.SetActive(true);
        Restart.SetActive(true);
        Home.SetActive(true);
        AreYouSure.SetActive(false);
        Music1.SetActive(false);
        SFX1.SetActive(false);
        Back.SetActive(false);
    }
    public void ConfirmRestart()
    {
        SceneManager.LoadScene(1);
    }
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
    public void PressRestart()
    {
        BillyMovement.r = 3;
        AreYouSure.SetActive(true);

        QuitTxt.SetActive(false);
        NoQuit.SetActive(false);
        YesQuit.SetActive(false);

        Yeslvl.SetActive(true);
        Nolvl.SetActive(true);
        restTxt.SetActive(true);

        Resume.SetActive(false);
        Settings.SetActive(false);
        Restart.SetActive(false);
        Home.SetActive(false);

        Music1.SetActive(false);
        SFX1.SetActive(false);
        Back.SetActive(true);
    }
    public void PressHome()
    {
        AreYouSure.SetActive(true);

        QuitTxt.SetActive(true);
        NoQuit.SetActive(true);
        YesQuit.SetActive(true);

        Yeslvl.SetActive(false);
        Nolvl.SetActive(false);
        restTxt.SetActive(false);

        Resume.SetActive(false);
        Settings.SetActive(false);
        Restart.SetActive(false);
        Home.SetActive(false);

        Music1.SetActive(false);
        SFX1.SetActive(false);
        Back.SetActive(true);
    }
  
}
