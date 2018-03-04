﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckEnemy : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        else if(collision.gameObject.tag == "Finish")
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            PointsManager.AddPoints(amount: 500);
        }
        
    }
}
