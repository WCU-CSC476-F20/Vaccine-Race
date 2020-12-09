using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public int coins;

    [Header("Game Settings")]
    public float spawnBuffer = 0.5f;
    public bool isPaused = true;
    public bool gameOver = false;

    [Header("UI Control")]
    public Text scoreText;
    public GameObject gameUI;
    public GameObject startUI;
    public GameObject finalScoreUI;
    public GameObject highScoreUI;
    public GameObject shopUI;
    public GameObject openshopUI;
    public GameObject closeshopUI;
    public Text currentScore;
    public Text topScore;
    public GameObject purchaseRed;
    public GameObject equipRed;
    public GameObject purchaseBlue;
    public GameObject equipBlue;
    public GameObject purchaseGreen;
    public GameObject equipGreen;
    public GameObject purchaseTeal;
    public GameObject equipTeal;
    public GameObject purchasePurple;
    public GameObject equipPurple;
    public Text coinsUI;

    [Header("Sprites")]
    public Sprite redCorona;
    public Sprite greenCorona;
    public Sprite tealCorona;
    public Sprite blueCorona;
    public Sprite purpleCorona;

    private BoxCollider2D spawnBounds;
    private Sprite playersprite;
    private void Awake()
    {
        gameOver = false;
        spawnBounds = GameObject.FindGameObjectWithTag("Spawn Bounds").GetComponent<BoxCollider2D>();
        playersprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite;
        if (PlayerPrefs.HasKey("Coins"))
        {
            int COINS = PlayerPrefs.GetInt("Coins");
            coins = COINS;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnBounds();

        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;


        //Updates the score display
        scoreText.text = score.ToString();
        coinsUI.text = coins.ToString();

        
    }

    private void SetSpawnBounds()
    {
        Camera mainCamera = Camera.main;
        spawnBounds.gameObject.transform.position = mainCamera.transform.position;

        spawnBounds.size = new Vector2(mainCamera.aspect * 2f * mainCamera.orthographicSize + spawnBuffer, 2f * mainCamera.orthographicSize);
    }

    public void RestartLevel()
    {
        isPaused = true;
        gameOver = true;
        finalScoreUI.SetActive(true);
        gameUI.SetActive(false);
        
        SaveScores();

        Invoke("ReloadScene", 4f);
    }

    private void SaveScores()
    {
        //Checks score against highest saved score
        if(PlayerPrefs.HasKey("TopScore"))
        {
            int top = PlayerPrefs.GetInt("TopScore");

            if(score > top)
            {
                highScoreUI.SetActive(true);
                PlayerPrefs.SetInt("TopScore", score);
            }

            topScore.text = "High Score: " + PlayerPrefs.GetInt("TopScore").ToString();
        }
        else
        {
            highScoreUI.SetActive(true);
            PlayerPrefs.SetInt("TopScore", score);
            topScore.text = "High Score: " + score.ToString();
        }
        

        currentScore.text = "Current Score: " + score.ToString();
    }
    public void PlayerCoins()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            int COINS = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.SetInt("Coins", COINS + 1);
            coinsUI.text = COINS.ToString();
            coins = COINS;
        }
        else
        {
            PlayerPrefs.SetInt("Coins", coins);
        }
    }
    public void OpenShop()
    {
        shopUI.SetActive(true);
        openshopUI.SetActive(false);
        closeshopUI.SetActive(true);
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
        closeshopUI.SetActive(false);
        openshopUI.SetActive(true);
    }
    public void PurchaseRed()
    {
        if (coins >= 5)
        {
            coins = coins - 5;
            coinsUI.text = coins.ToString();
            purchaseRed.SetActive(false);
            equipRed.SetActive(true);
        }
    }
    public void PurchaseBlue()
    {
        if (coins >= 10)
        {
            coins = coins - 10;
            coinsUI.text = coins.ToString();
            purchaseBlue.SetActive(false);
            equipBlue.SetActive(true);
        }
    }
    public void PurchaseTeal()
    {
        if (coins >= 5)
        {
            coins = coins - 5;
            coinsUI.text = coins.ToString();
            purchaseTeal.SetActive(false);
            equipTeal.SetActive(true);
        }
    }
    public void PurchaseGreen()
    {
        if (coins >= 15)
        {
            coins = coins - 15;
            coinsUI.text = coins.ToString();
            purchaseGreen.SetActive(false);
            equipGreen.SetActive(true);
        }
    }
    public void PurchasePurple()
    {
        if (coins >= 15)
        {
            coins = coins - 15;
            coinsUI.text = coins.ToString();
            purchasePurple.SetActive(false);
            equipPurple.SetActive(true);
        }
    }
    public void EquipRed()
    {
        playersprite = redCorona;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = playersprite;
    }
    public void EquipBlue()
    {
        playersprite = blueCorona;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = playersprite;
    }
    public void EquipGreen()
    {
        playersprite = greenCorona;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = playersprite;
    }
    public void EquipTeal()
    {
        playersprite = tealCorona;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = playersprite;
    }
    public void EquipPurple()
    {
        playersprite = purpleCorona;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = playersprite;
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
