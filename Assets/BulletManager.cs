using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //public List<GameObject> BulletList = new List<GameObject>();
    public GameObject bulletPrefabs;

    private List<int> randomBulletList;

    public int bulletNoInLine/*, bulletsNoInLevel2, bulletsNoInLevel3, bulletsNoInLevel4, bulletsNoInLevel5, bulletsNoInLevel6*/;
    private int listIndex, n;
    private int xIndex/*, xIndex2, xIndex3, xIndex4, xIndex5, xIndex6*/;
    private float xPosition, yPosition;
    public int bulletColumn;
    //public EnemyController enemyController;

    public float speed1LevelMin, speed1LevelMax/*, speed2LevelMin, speed2LevelMax, speed3LevelMin, speed3LevelMax, speed4LevelMin, speed4LevelMax,speed5LevelMin,speed5LevelMax*/;
    public float speed;

    public void bulletCreater(float yPos)
    {
        //randomBulletList = new List<int>();

      

        for (int i = 0; i < bulletNoInLine; i++)
        {
            
            for (n = 0; n < 7; n++)
            {
                randomBulletList.Add(n);
            }

            xIndex = Random.Range(0, randomBulletList.Count - 1);
            listIndex = randomBulletList[xIndex];



            switch (listIndex)
            {
                case 0:
                    GameObject InstBullet1 = Instantiate(bulletPrefabs, new Vector2(xPosition, yPos), Quaternion.identity);
                    InstBullet1.transform.parent = this.transform;
                    break;
                case 1:
                    GameObject InstBullet2 = Instantiate(bulletPrefabs, new Vector2(xPosition * 2, yPos), Quaternion.identity);
                    InstBullet2.transform.parent = this.transform;
                    break;
                case 2:
                    GameObject InstBullet3 = Instantiate(bulletPrefabs, new Vector2(xPosition * 3, yPos), Quaternion.identity);
                    InstBullet3.transform.parent = this.transform;
                    break;
                case 3:
                    GameObject InstBullet4 = Instantiate(bulletPrefabs, new Vector2(-xPosition, yPos), Quaternion.identity);
                    InstBullet4.transform.parent = this.transform;
                    break;
                case 4:
                    GameObject InstBullet5 = Instantiate(bulletPrefabs, new Vector2(-xPosition * 2, yPos), Quaternion.identity);
                    InstBullet5.transform.parent = this.transform;
                    break;
                case 5:
                    GameObject InstBullet6 = Instantiate(bulletPrefabs, new Vector2(-xPosition * 3, yPos), Quaternion.identity);
                    InstBullet6.transform.parent = this.transform;
                    break;
                case 6:
                    GameObject InstBullet7 = Instantiate(bulletPrefabs, new Vector2(0, yPos), Quaternion.identity);
                    InstBullet7.transform.parent = this.transform;
                    break;
            }

            randomBulletList.RemoveAt(xIndex);
            randomBulletList.Remove(listIndex);
        }

    }


    private void Awake()
    {

        






    }

    private void Start()
    {
        
        
        GameManager.instance.bulletRandomSpeed1 = Random.Range(speed1LevelMin, speed1LevelMax);
        //GameManager.instance.bulletRandomSpeed2 = Random.Range(speed2LevelMin, speed2LevelMax);
        //GameManager.instance.bulletRandomSpeed3 = Random.Range(speed3LevelMin, speed3LevelMax);
        //GameManager.instance.bulletRandomSpeed4 = Random.Range(speed4LevelMin, speed4LevelMax);
        //GameManager.instance.bulletRandomSpeed5 = Random.Range(speed5LevelMin, speed5LevelMax);

        xPosition = 0.72f;
        yPosition = 4;


        for (int i = 0; i < bulletColumn; i++)
        {
            randomBulletList = new List<int>();
            GameManager.instance.column = bulletColumn;
            switch (bulletColumn)  // 1) whichLevel , 2) bulletsNoInLevel , 3) randomIndex , 4) xPos, 5) yPos
            {
                case 1:


                    bulletCreater(yPosition);
                    break;

                case 2:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 3:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 4:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 5:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 6:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 7:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 8:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 9:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 10:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;
                case 11:

                    yPosition++;
                    bulletCreater(yPosition);
                    break;

            }


        }

        
    }
}

