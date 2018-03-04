using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckPlayer : MonoBehaviour {

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            PointsManager.AddPoints(amount: -250);
        
    }
}
