using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject line,normalarrow,carrotarrow,onionarrow,Billy,emptyObject;
    private GameObject LineInstance,NormalArrowInstance, CarrotArrowInstance,OnionArrowInstance;
    private Vector2 cameraTopRightCorner;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject emptyline;
    private bool left = false;

    private int gameDifficulty=2;
    private float rateVegetable,rateArrow;
    

    private void Awake()
    {
        cameraTopRightCorner = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        cameraTopRightCorner = Camera.main.ScreenToWorldPoint(cameraTopRightCorner);
        NormalArrowInstance = emptyObject;
        
    }
    private void Start()
    {

       

        gameDifficulty = PlayerPrefs.GetInt("Diff", 1);
        if(gameDifficulty == 0)//easy
        {
            rateArrow = 0.75f;
            rateVegetable = 10f;
        }else if(gameDifficulty == 1) // medium
        {
            rateArrow = 0.5f;
            rateVegetable = 8f;
        }else if (gameDifficulty == 2) // hard
        {
            rateArrow = 0.25f; // should be 0.25
            rateVegetable = 5f;
        }
        InvokeRepeating("MakeNewArrow", 2f, rateArrow);
        InvokeRepeating("MakeNewCarrot", rateVegetable, rateVegetable*2);
        InvokeRepeating("MakeNewOnion", rateVegetable*2, rateVegetable*2);


    }
    
    private void MakeNewArrow()
    {
        NormalArrowInstance = Instantiate(normalarrow);
        NormalArrowInstance.transform.position = GenerateRandomArrowCoords();
        Rigidbody2D arrowrb = NormalArrowInstance.GetComponent<Rigidbody2D>();
        if (left)
        {
            arrowrb.velocity = new Vector2(13f, arrowrb.velocity.y);
        }
        else
        {
            arrowrb.velocity = new Vector2(-13f, arrowrb.velocity.y);
        }

        Destroy(NormalArrowInstance, 8f);
        
        
    }
    private void MakeNewCarrot()
    {
        CarrotArrowInstance = Instantiate(carrotarrow);
        CarrotArrowInstance.transform.position = GenerateRandomArrowCoords();
        Rigidbody2D arrowrb = CarrotArrowInstance.GetComponent<Rigidbody2D>();
        if (left)
        {
            arrowrb.velocity = new Vector2(13f, arrowrb.velocity.y);
        }
        else
        {
            arrowrb.velocity = new Vector2(-13f, arrowrb.velocity.y);
        }

        
        Destroy(CarrotArrowInstance, 15f);


    }
    private void MakeNewOnion()
    {
        OnionArrowInstance = Instantiate(onionarrow);
        OnionArrowInstance.transform.position = GenerateRandomArrowCoords();
        Rigidbody2D arrowrb = OnionArrowInstance.GetComponent<Rigidbody2D>();
        if (left)
        {
            arrowrb.velocity = new Vector2(13f, arrowrb.velocity.y);
        }
        else
        {
            arrowrb.velocity = new Vector2(-13f, arrowrb.velocity.y);
        }


        Destroy(OnionArrowInstance, 15f);


    }
    private Vector2 GenerateRandomArrowCoords()
    {
       
        Vector2 arrowCoords;
        float randomY;
        int leftOrRightSide = Random.Range(0, 2);

        randomY = Random.Range(0, cameraTopRightCorner.y);
        if (leftOrRightSide == 0)//left side
        {
            arrowCoords = new Vector2(-cameraTopRightCorner.x, randomY);
            left = true;
        }
        else // right side
        {
            arrowCoords = new Vector2(cameraTopRightCorner.x, randomY);
            left = false;
        }

        

        return arrowCoords;
    }
    private void Update()
    {
        
        if (Input.GetMouseButton(0)&&!LineDraw.loading)
        {
            LineInstance = Instantiate(line);
            Destroy(LineInstance, 0.5f);
        }

        if (GameObject.FindGameObjectWithTag("drawnwall") == null)
        {
            emptyline.SetActive(true);
        }
        else
        {
            emptyline.SetActive(false);
        }


    }
}