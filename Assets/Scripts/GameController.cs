using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //CONTROLS THE LEVEL SETUP AND RESPAWNS ENEMIES
    //This is the only persistent Gameobject that wont be destroyed at all.
    public static GameController game;
    public GameObject levelbg1;
    public GameObject levelbg2;
    public GameObject wholedragon;
    public GameObject lion;
    private LionScript l;
    public GameObject gameoverui;
    public int stage;
    private PlayerScript p;
    public BarrierSpawning bs;
    public Text stageui;
    private EnemyScript e;
    private GameObject dragon;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public GameObject life6;
    public GameObject life7;
    public GameObject life8;
    public GameObject life9;
    public Text score;
    public Text hiscore;
    private int currentscore;
    private int maxhealth;
    private int currenthealth;
    private int currentscoreextralife;
    private int extralifescore;
    private GameObject player;
    public int enemytotal;
    private float liontimer;
    private float timeforlion;
    //private GameObject player;
    // Start is called before the first frame update

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        p = player.GetComponent<PlayerScript>();
        dragon = GameObject.FindWithTag("Enemy");
        e = dragon.GetComponent<EnemyScript>(); 
        GameObject liontag = GameObject.FindWithTag("Lion");
        l = liontag.GetComponent<LionScript>();
        stage = 1;
        levelbg2.SetActive(false);
        levelbg1.SetActive(true);
        gameoverui.SetActive(false);
        currentscore = 0;
        currentscoreextralife = 0;
        //This is the score you need for an extra life.
        extralifescore = 20000;
        maxhealth = 9;
        currenthealth = 3;
        stageui.text = "STAGE: " + stage.ToString(); 
        score.text = "SCORE: " + currentscore.ToString();
        //Set HiScore here
        PlayerPrefs.SetInt("Hiscore",10000);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
        enemytotal = 10;
        liontimer = 0.0f;
        timeforlion = 20.0f;

        //Lifecount at start of game
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        life4.SetActive(false);
        life5.SetActive(false);
        life6.SetActive(false);
        life7.SetActive(false);
        life8.SetActive(false);
        life9.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stage % 2 == 0) {
            levelbg2.SetActive(true);
            levelbg1.SetActive(false);
        } else {
            levelbg2.SetActive(false);
            levelbg1.SetActive(true);
        }
        stageui.text = "STAGE: " + stage.ToString();

        if (currenthealth <= 0) {
            player.SetActive(false);
            wholedragon.SetActive(false);
            gameoverui.SetActive(true);
        }

         //Go to next level
        if (enemytotal < 1) {
            ChangeLevel(1);
            enemytotal = 10;
        }

        liontimer += Time.deltaTime;
        if (liontimer >= timeforlion) {
            CreateLion();
            liontimer = 0.0f;
        }

    }


    public void ChangeLevel(int level) {
        stage += level;
        ChangeScore(1000);
        bs.amount = 10;
        bs.Generate();
        CreateDragon();
    }


    void CreateDragon() {
        Instantiate(wholedragon,new Vector2(-2.75f,11.5f),Quaternion.identity);
        
    }

    void CreateLion() {
        Instantiate(lion, new Vector2(-10.0f,-14.0f), Quaternion.identity);
    }


    public void ChangeScore(int scorechange) {
        currentscore += scorechange;
        currentscoreextralife += scorechange;

        //    SCORECHART
        // 100 Per Body Part
        // 10 Per Barrier
        // 1000 Per Stage Completed
        if (currentscore >= PlayerPrefs.GetInt("Hiscore",0)) {
            ChangeHiScore();
        }
        score.text = "SCORE: " + currentscore.ToString();

        if (currentscoreextralife >= extralifescore) {
            if (currenthealth < maxhealth) {
                ChangeHealth(1);
            }
            currentscoreextralife = 0;
        }
        
        
    }


    void ChangeHiScore() {
        PlayerPrefs.SetInt("Hiscore",currentscore);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
    }

    public void RestartLevel() {
       
    }

    public void ChangeHealth(int amount) {
        currenthealth += amount;
        
        if (currenthealth == 1) {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 2) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 3) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 4) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 5) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 6) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 7) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 8) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(true);
            life9.SetActive(false);
        }
        else if (currenthealth == 9) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(true);
            life9.SetActive(true);
        }
    }
}
