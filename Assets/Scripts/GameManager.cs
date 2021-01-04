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

    private Transform ballTransform;

    public bool bulletSlowing;

    

    private void Awake()
    {
        levelNo = 1;
        LoadLevel(levelNo);

        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
        ballStartPosition = ballTransform.position;

        audioSource = GetComponent<AudioSource>();



    }
    void Start()
    {
        instance = this;

        totalCoinScore = PlayerPrefs.GetInt("totalScore", (int)totalCoinScore);
        textCoinScore.text = totalCoinScore.ToString();

        Debug.Log(totalCoinScore);
    }

    // Update is called once per frame
   

    private void FixedUpdate()
    {
        UpdateBulletList();
        UpdateBallList();

        findAndDestroyBigExplosionEffect();
        findAndDestroyEffect();

      
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

    public void GameOverPanel()
    {

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
        levelNo = 1;
        LoadLevel(levelNo);

        bulletSlowing = false;
        Destroy(instandietedExtraBall);
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
            instantiatedCoin = Instantiate(Coin, transform.position, Quaternion.identity) as GameObject;
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

}
