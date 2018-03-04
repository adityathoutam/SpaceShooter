using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class BulletManager : MonoBehaviour {

    public GameObject Bullet;
    public GameObject[] Lasers;
    GameObject bulletinstances;

    private void Start()
    {
        InstantiateBullets(Lasers[0]);      
    }


    // Update is called once per frame
    void Update () {
        
        MoveBullets(Lasers[0]);
      
    }
    void InstantiateBullets(GameObject Laser)
    {
        bulletinstances = Instantiate(Bullet, Laser.transform.position, Quaternion.identity);
    }
    void MoveBullets(GameObject Laser)
    {
        if (bulletinstances.transform.position.y > 10f)
        {
            bulletinstances.transform.position = Laser.transform.position;
        }

        bulletinstances.transform.position = new Vector3(bulletinstances.transform.position.x, bulletinstances.transform.position.y + 1f, bulletinstances.transform.position.z);
    }

}
