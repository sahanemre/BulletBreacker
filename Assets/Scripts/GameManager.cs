using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Vector3 ballStartPosition;

    private List<GameObjectsType> bulletList;
    private List<GameObjectsType2> ballList;

    public AudioClip coinSound;
    public AudioClip explosionSound;
    
    AudioSource audioSource;


    GameObject firework;
    GameObject currentLevelObj;
    GameObject bigExplosion;

    private int levelNo;

    private int ballNo;
    public TextMeshProUGUI textBallNo;
    private int bulletNo;
    public TextMeshProUGUI textBulletNo;
    private int coinScore,totalCoinScore;
    public TextMeshProUGUI textCoinScore;
    public TextMeshPro textSaloonLevel;

    public GameObject extraBall;
    private GameObject instandietedExtraBall;
    public GameObject Coin;
    private GameObject instantiatedCoin;
    public GameObject GameOverPanelGO;
    public GameObject StartPanelGO;
    public GameObject explosionObj;
    private GameObject instantiatedExp;
    public GameObject saloonName, saloonNo;

    private Transform ballTransform;

    public bool bulletSlowing;

    public float bulletRandomSpeed1/* , bulletRandomSpeed2, bulletRandomSpeed3, bulletRandomSpeed4, bulletRandomSpeed5;*/;
    public int column;
    private float RandomTransform1,RandomTransform2;


    
    private void Awake()
    {
        Time.timeScale = 0;
        

        levelNo = 1;
        LoadLevel(levelNo);

        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
        ballStartPosition = ballTransform.position;

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(audioSource);
        

    }
    void Start()
    {
        instance = this;

        totalCoinScore = PlayerPrefs.GetInt("totalScore", (int)totalCoinScore);
        textCoinScore.text = totalCoinScore.ToString();

        RandomTransform1 = Random.Range(-2, 2);
        RandomTransform2 = Random.Range(-2, 2);

        //Debug.Log(totalCoinScore);

        //bulletRandomSpeed1 = Random.Range(speedLevelMin, speedLevelMax);
        //bulletRandomSpeed2 = Random.Range(speedLevelMin, speedLevelMax);
        //bulletRandomSpeed3 = Random.Range(speedLevelMin, speedLevelMax);
        //bulletRandomSpeed4 = Random.Range(speedLevelMin, speedLevelMax);
        //bulletRandomSpeed5 = Random.Range(speedLevelMin, speedLevelMax);
        Debug.Log(bulletRandomSpeed1);
        
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        UpdateBulletList();
        UpdateBallList();

        findAndDestroyBigExplosionEffect();
        findAndDestroyEffect();

      
    }

    public void randomSpeed(float speedLevelMin, float speedLevelMax)
    {
        Random.Range(speedLevelMin, speedLevelMax);    
    }

   

    public void updateCoinScore(int updateCoinAmount)
    {
        //coinScore = int.Parse(textCoinScore.text);
        //coinScore += updateCoinAmount;
        totalCoinScore += updateCoinAmount;
        textCoinScore.text = totalCoinScore.ToString();

       

        //if (totalCoinScore <= coinScore)
        //{
        //    totalCoinScore = coinScore;
        //}

        PlayerPrefs.SetInt("totalScore", (int)totalCoinScore);

    }

    public void findAndDestroyEffect()
    {
        firework = GameObject.FindGameObjectWithTag("Firework");
        Destroy(firework,1f);
    }

    public void findAndDestroyBigExplosionEffect()
    {
        bigExplosion = GameObject.FindGameObjectWithTag("BigExplosion");
        Destroy(bigExplosion, 1f);
    }


    public void UpdateBulletList()
    {
      
            bulletList = new List<GameObjectsType>(GameObject.FindObjectsOfType<GameObjectsType>());
            //bulletNo = bulletList.Count;
            textBulletNo.text = bulletList.Count.ToString();
       
        
    }

    public void UpdateBallList()
    {
      
        
            ballList = new List<GameObjectsType2>(GameObject.FindObjectsOfType<GameObjectsType2>());
            //ballNo = ballList.Count;
            textBallNo.text = ballList.Count.ToString();
        
      
    }

    public void DestroyBullet(GameObjectsType bullet)
    {
        bulletList.Remove(bullet);
        Destroy(bullet.gameObject);


        if (bulletList.Count == 0)
        {
            GoNextLevel();
        }
    }

    public void LoadLevel(int levelIndex)
    {
        
        if (currentLevelObj != null)
        {
            Destroy(currentLevelObj);
        }
        currentLevelObj = Instantiate(Resources.Load("Level " + levelIndex )) as GameObject;
        CoinOccurPossibility();

        textSaloonLevel.text = levelNo.ToString();
        
       // Debug.Log(bulletList.Count);
    }

    public void GoNextLevel()
    {
        levelNo++;
        LoadLevel(levelNo);
        InstantiateBall();

        bulletSlowing = false;
        Destroy(instandietedExtraBall);

    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        GameOverPanelGO.SetActive(false);

        levelNo = 1;
        LoadLevel(levelNo);

        bulletSlowing = false;
        Destroy(instandietedExtraBall);
    }


    public void GameOverPanel()
    {
        //DestroyCurrentLevel();
        Destroy(currentLevelObj);
        GameOverPanelGO.SetActive(true);
    }
    void isActive(bool isTrue)
    {
        saloonName.SetActive(isTrue);
        saloonNo.SetActive(isTrue);
    }

    public void startGame()
    {
        StartPanelGO.SetActive(false);
        Time.timeScale = 1;
        isActive(true);
    }
    public void InstantiateBall()
    {
        //if (levelNo == 2)
        //{
        //    Instantiate(extraBall, ballStartPosition, Quaternion.identity);
        //}
    }

    //if button using bullet speed decrease
    public void SlowBullet() //Skill Button
    {
        if (totalCoinScore >= 25)
        {
            bulletSlowing = true;
            updateCoinScore(-25);
        }
        
    }

    public void ExtraBallButton() //Skill Button
    {
        if (totalCoinScore >= 25)
        {
            instandietedExtraBall = Instantiate(extraBall, ballStartPosition, Quaternion.identity) as GameObject;
            updateCoinScore(-25);
        }
        
    }

    public void CoinOccurPossibility()  
    {
        Destroy(instantiatedCoin);
        int possibilty = Random.Range(0, 100);
        if (possibilty >= 40 && possibilty <= 60)
        {
            instantiatedCoin = Instantiate(Coin, new Vector2(RandomTransform1,RandomTransform2), Quaternion.identity) as GameObject;
        }


    }

    public void ExplosionOccurPossibility()
    {
        Destroy(instantiatedExp);
        int possibilty = Random.Range(0, 100);
        if (possibilty >= 19 && possibilty <= 39)
        {
            instantiatedExp = Instantiate(explosionObj, new Vector2(RandomTransform2, RandomTransform1), Quaternion.identity) as GameObject;
        }


    }
    //SoundManager
    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void triggerCoinSound()
    {
        PlaySFX(coinSound);
    }

    public void triggerExplosionSound()
    {
        PlaySFX(explosionSound);
    }

    public void DestroyCurrentLevel()
    {
        Destroy(currentLevelObj);
    }

}
