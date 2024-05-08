using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.SceneManagement;

public class BillyLife : MonoBehaviour
{
    [SerializeField] public static Image heart1, heart2, heart3;
    public static Animator anim,cameraAnim;
    public static bool hurtorvanish = false;
    public static GameObject Billy;
    [SerializeField] private static Material flashmaterial;
    private static SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField] private SimpleFlash FlashEffect;
    private static Animator heart1Anim, heart2Anim, heart3Anim;
    public static bool flash1,flash2, flash3;

    public static AudioSource hurtsound,healsound,deathsound,arrowbreaksound;

    [SerializeField] private Image DialogueBoxImage;
    private static Animator DiaAnim;
    private static TextMeshProUGUI DiaText;
    private static Queue<string> sentences=new Queue<string>();


    [SerializeField] private Canvas HeartsAndSliderCanvas;
    [SerializeField] private Canvas GameOverCanvas;

    private float timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI HighscoreText;

    public static bool noMoreRegen;

    void Start()
    {
        timer = 0;
        noMoreRegen = false;
        GameOverCanvas.enabled = false;
        HeartsAndSliderCanvas.enabled = true;
        rb =GetComponent<Rigidbody2D>();
        DiaAnim = DialogueBoxImage.GetComponent<Animator>();
        foreach(TextMeshProUGUI go in GameObject.FindObjectsOfType<TextMeshProUGUI>())
        {
            if (go.name == "DiaText")
            {
                DiaText = go;
            }
        }
        
        Billy = GameObject.FindGameObjectWithTag("Player");
        Billy.SetActive(true);
        hurtsound=Billy.GetComponents<AudioSource>()[0];
        healsound = Billy.GetComponents<AudioSource>()[1];
        deathsound= Billy.GetComponents<AudioSource>()[2];
        arrowbreaksound = Billy.GetComponents<AudioSource>()[3];
        anim =Billy.GetComponent<Animator>();
        cameraAnim= Camera.main.GetComponent<Animator>();
        sr=Billy.GetComponent<SpriteRenderer>();

        string[] listsentences = { "NO!! I WANTED THAT!" , "Another beloved vegetable gone to waste..." ,
        "That was a perfectly good ,delicious, vegetable you know!!","WHY WOULD YOU DO THAT?!",
        "My heart hurts everytime I see a vegetable in pain..","If you played long enough to see this, you a real one <3"};
       
        foreach(string sen in listsentences)
        {
            sentences.Enqueue(sen);
        }



        Image[] images= GameObject.FindObjectsOfType<Image>();
        for(int i=0;i < images.Length;i++) {

            if (images[i].name == "heart")
            {
                heart1= images[i];
                heart1Anim=heart1.GetComponent<Animator>();
            }else if (images[i].name =="heart (1)")
            {
                heart2= images[i];
                heart2Anim = heart2.GetComponent<Animator>();
            }
            else if (images[i].name =="heart (2)")
            {
                heart3= images[i];
                heart3Anim = heart3.GetComponent<Animator>();
            }
        }
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerString(timer);
    }
    private string UpdateTimerString(float timervalue)
    {
        float mins = 0, secs = 0;
        float temp = timervalue;
        while (temp > 0 && temp > 59)
        {
            mins++;
            temp -= 60;
        }
        secs = Mathf.Floor(temp) + 1;

        string str = "";
        if (mins < 10)
        {
            str += "0" + mins.ToString();
        }
        else
        {
            str += mins.ToString();
        }
        str += ":";
        if (secs < 10)
        {
            str += "0" + secs.ToString();
        }
        else
        {
            str += secs.ToString();
        }

        timerText.text = str;
        return str;
    }
    private void GameOver()
    {
        HeartsAndSliderCanvas.enabled = false;
        GameOverCanvas.enabled = true;
    }

    public void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        BillyMovement.r = 3;
        BillyLife.hurtorvanish = false;
        SceneManager.LoadScene(1);
    }

    public void makehurtboolfalse()
    {
        hurtorvanish = false;
    }
    public void disableBilly()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    public static void RegenHeart()
    {
        Color32 white=new Color32(255,255,255,255); // white
        if (!noMoreRegen)
        {
            if (heart2.color != white)
            {
                heart2.color = white;
                heart2Anim.SetTrigger("regen");
            }
            else if (heart3.color != white)
            {
                heart3.color = white;
                heart3Anim.SetTrigger("regen");
            }
        }
        
        
    }
    public static void TakeHeart(bool veg)
    {
        string sentence;
        Color32 black = new Color32(0, 0, 0, 255); // black
        if (heart3.color != black&&!flash3)
        {
            heart3.color = black;
            heart3Anim.SetTrigger("flash");
            hurtorvanish = true;
            if (!veg)
            {
                anim.Play("hurt");
            }
            else
            {
                sentence=sentences.Dequeue();
                sentences.Enqueue(sentence);
                DiaText.text= sentence;
                anim.Play("SlurSide");
                if (sr.flipX == false)
                {
                    DiaAnim.SetBool("IsOpenLeft", true);
                }
                else
                {
                    DiaAnim.SetBool("IsOpenRight", true);
                }
            }
            
            cameraAnim.SetTrigger("shake");
            hurtsound.Play();
        }
        else if (heart2.color != black&&!flash2)
        {
            heart2.color = black;
            heart2Anim.SetTrigger("flash");
            hurtorvanish = true;
            if (!veg)
            {
                anim.Play("hurt");
            }
            else
            {
                sentence = sentences.Dequeue();
                sentences.Enqueue(sentence);
                DiaText.text = sentence;
                anim.Play("SlurSide");
                if (sr.flipX == false)
                {
                    DiaAnim.SetBool("IsOpenLeft", true);
                }
                else
                {
                    DiaAnim.SetBool("IsOpenRight", true);
                }
            }
            cameraAnim.SetTrigger("shake");
            hurtsound.Play();
        }
        else if (heart1.color != black && !flash1) // game over
        {
            Camera.main.GetComponent<AudioSource>().mute = true;
            deathsound.Play();
            heart1.color = black;
            noMoreRegen = true;
            heart1Anim.SetTrigger("flash");
            hurtorvanish = true;
            DiaText.text = "AAAAAAAAAAHHHHHHHHHHHHH";
            if (sr.flipX == false)
            {
                DiaAnim.SetBool("IsOpenLeft", true);
            }
            else
            {
                DiaAnim.SetBool("IsOpenRight", true);
            }
            anim.Play("vanish");
            cameraAnim.enabled = false;
            cameraAnim.SetTrigger("shake");
            hurtsound.Play();


            

        }
       
        
        
       
    }
    public void UpdateHighScores()
    {
        int diff = PlayerPrefs.GetInt("Diff");
        if (diff == 0)
        {
            if (PlayerPrefs.GetFloat("EasyHS", 0) < timer)
            {
                PlayerPrefs.SetFloat("EasyHS", timer);
            }
            HighscoreText.text = UpdateTimerString(timer)+" ,Not bad!\r\n\r\nThe longest time you helped Billy survive in this difficulty is: " + UpdateTimerString(PlayerPrefs.GetFloat("EasyHS"));

        }
        else if (diff == 1)
        {
            if (PlayerPrefs.GetFloat("MedHS", 0) < timer)
            {
                PlayerPrefs.SetFloat("MedHS", timer);
            }
            HighscoreText.text = UpdateTimerString(timer) + " ,Not bad!\r\n\r\nThe longest time you helped Billy survive in this difficulty is: " + UpdateTimerString(PlayerPrefs.GetFloat("MedHS"));
        }
        else if (diff == 2)
        {
            if (PlayerPrefs.GetFloat("HardHS", 0) < timer)
            {
                PlayerPrefs.SetFloat("HardHS", timer);
            }
            HighscoreText.text = UpdateTimerString(timer) + " ,Not bad!\r\n\r\nThe longest time you helped Billy survive in this difficulty is: " + UpdateTimerString(PlayerPrefs.GetFloat("HardHS"));
        }
        else if (diff == 3)
        {
            if (PlayerPrefs.GetFloat("HellHS", 0) < timer)
            {
                PlayerPrefs.SetFloat("HellHS", timer);
            }
            HighscoreText.text = UpdateTimerString(timer) + " ,Not bad!\r\n\r\nThe longest time you helped Billy survive in this difficulty is: " + UpdateTimerString(PlayerPrefs.GetFloat("HellHS"));
        }
        

    }

    public void FreezeX()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    public void UnFreezeX()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("normalarrow"))
        {
            TakeHeart(false);
            
            Color red = new Color(255, 0, 0, 255); // red
            FlashEffect.Flash(red);
        }else if (collision.gameObject.CompareTag("vegetable"))
        {
            Color green = new Color(0, 255, 0, 255); // green
            FlashEffect.Flash(green);
            RegenHeart();
            healsound.Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
            RegenHeart();
            healsound.Play();
            Color green = new Color(0, 255, 0, 255); // green
            FlashEffect.Flash(green);
        }
    }
}
