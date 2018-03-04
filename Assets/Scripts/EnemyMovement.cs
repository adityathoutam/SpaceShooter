using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject EnemyPrefab;
    public GameObject[] EnemiesPosition;
    GameObject[] Enemies;
    GameObject[] bulletinstances;




    public float speed = 5.0f;

    private void Awake()
    {
        Enemies = new GameObject[5];
        bulletinstances = new GameObject[5];
        InstaniateEnemies();
        InstantiateBullets();
    }

    void Update()
    {
        MoveEnemies();
        MoveBullets();
        EnemiesAndBulletsPooling();
        CheckHitByBullet();
        PointsManager.AddPoints((int)Time.realtimeSinceStartup*1/100);
        
    }
    void InstaniateEnemies()
    {
        for(int i =0;i<EnemiesPosition.Length;i++)
        {
            Enemies[i] = Instantiate(EnemyPrefab, EnemiesPosition[i].transform.position, Quaternion.identity); 
        }
    }
    void EnemiesAndBulletsPooling()
    {
       
        for (int i= 0;i<EnemiesPosition.Length;i++)
        {
            if (Enemies[i].transform.position.y <= -7.5f)
            {
                
                Enemies[i].transform.position = EnemiesPosition[i].transform.position;
                
                Enemies[i].GetComponent<Renderer>().enabled = true;
                bulletinstances[i].GetComponent<Renderer>().enabled = true;

            }
           
        }
      

    }
    void InstantiateBullets()
    {
        for (int i = 0; i < EnemiesPosition.Length; i++)
        {
            bulletinstances[i] = Instantiate(Bullet, EnemiesPosition[i].transform.position, Quaternion.identity);
            bulletinstances[i].transform.parent = Enemies[i].transform;
        }
    }
    void MoveEnemies()
    {
        
        for (int i = 0; i < EnemiesPosition.Length; i++)
        {
            Vector3 leftPos = new Vector3(Enemies[i].transform.position.x - 0.5f, Enemies[i].transform.position.y);
            Vector3 RIghtPOs = new Vector3(Enemies[i].transform.position.x + 0.5f, Enemies[i].transform.position.y);

            Enemies[i].transform.position = Vector3.Lerp(leftPos, RIghtPOs, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
            Enemies[i].transform.position = new Vector3(Enemies[i].transform.position.x, Enemies[i].transform.position.y - 0.1f, Enemies[i].transform.position.z);

        }
    }
    void MoveBullets()
    {
        for (int i = 0; i < EnemiesPosition.Length; i++)
        {


            if (bulletinstances[i].transform.position.y < -9f)
            {
                bulletinstances[i].transform.position = Enemies[i].transform.position;
            }

            bulletinstances[i].transform.position = new Vector3(bulletinstances[i].transform.position.x, bulletinstances[i].transform.position.y - 1f, bulletinstances[i].transform.position.z);
        }
    }
    void CheckHitByBullet()
    {
        for (int i = 0; i < EnemiesPosition.Length; i++)
        {
            if (Enemies[i].GetComponent<Renderer>().enabled == false)
            {
                bulletinstances[i].GetComponent<Renderer>().enabled = false;
                
            }

        }
    }
}