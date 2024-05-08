using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeGameManager : MonoBehaviour
{
    [SerializeField] private Canvas Startmenu, DiffMenu,HowTo;
    [SerializeField] private GameObject sceneChanger;
    private Animator anim;
    [SerializeField] private AudioSource clickSound, startLevelSound;
    [SerializeField] private GameObject arrows, draw, vegdmg, vegheal, gl;
    [SerializeField] private Button left, right;
    private int page = 1;
    void Start()
    {
        Time.timeScale = 1f;
        Startmenu.enabled = true;
        DiffMenu.enabled = false;
        HowTo.enabled = false;
        anim=sceneChanger.GetComponent<Animator>();
        PlayerPrefs.SetInt("Music", 1);
        PlayerPrefs.SetInt("SFX", 1);
    }


    void Update()
    {
        
    }
    public void GoPlay()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Easy()
    {
        PlayerPrefs.SetInt("Diff", 0);
        anim.SetTrigger("FadeOut");
        startLevelSound.Play();
    }
    public void Medium()
    {
        PlayerPrefs.SetInt("Diff", 1);
        anim.SetTrigger("FadeOut");
        startLevelSound.Play();

    }
    public void Hard()
    {
        PlayerPrefs.SetInt("Diff", 2);
        anim.SetTrigger("FadeOut");
        startLevelSound.Play();

    }
    public void Hell()
    {
        PlayerPrefs.SetInt("Diff", 3);
        anim.SetTrigger("FadeOut");
        startLevelSound.Play();

    }

    public void StartButton()
    {
        Startmenu.enabled = false;
        DiffMenu.enabled = true;
        HowTo.enabled = false;
        clickSound.Play();
    }
    public void GoBackToStartMenu()
    {
        Startmenu.enabled = true;
        DiffMenu.enabled = false;
        HowTo.enabled = false;
        clickSound.Play();
    }
    public void ShowHowToPlay()
    {
        page = 1;
        left.interactable = false;
        right.interactable = true;
        Startmenu.enabled = false;
        DiffMenu.enabled = false;
        HowTo.enabled = true;

        left.interactable = false;
        arrows.SetActive(true);
        draw.SetActive(false);
        vegdmg.SetActive(false);
        vegheal.SetActive(false);   
        gl.SetActive(false);

        clickSound.Play();
    }
    public void NextHowTo()
    {
        if (page == 1)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(true);
            vegdmg.SetActive(false);
            vegheal.SetActive(false);
            gl.SetActive(false);
        }
        if (page == 2)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(false);
            vegdmg.SetActive(true);
            vegheal.SetActive(false);
            gl.SetActive(false);
        }
        if (page == 3)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(false);
            vegdmg.SetActive(false);
            vegheal.SetActive(true);
            gl.SetActive(false);
        }
        if (page == 4)
        {
            left.interactable = true;
            right.interactable = false;
            arrows.SetActive(false);
            draw.SetActive(false);
            vegdmg.SetActive(false);
            vegheal.SetActive(false);
            gl.SetActive(true);
        }
        page++;
        
    }

    public void PrevHowTo()
    {
        if (page == 2)
        {
            left.interactable = false;
            right.interactable = true;
            arrows.SetActive(true);
            draw.SetActive(false);
            vegdmg.SetActive(false);
            vegheal.SetActive(false);
            gl.SetActive(false);
        }
        if (page == 3)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(true);
            vegdmg.SetActive(false);
            vegheal.SetActive(false);
            gl.SetActive(false);
        }
        if (page == 4)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(false);
            vegdmg.SetActive(true);
            vegheal.SetActive(false);
            gl.SetActive(false);
        }
        if (page == 5)
        {
            left.interactable = true;
            right.interactable = true;
            arrows.SetActive(false);
            draw.SetActive(false);
            vegdmg.SetActive(false);
            vegheal.SetActive(true);
            gl.SetActive(false);
        }
        page--;

    }

}
