using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour {
    
    

    public static int Points;
   public Text pointstext;
   

    public  void Start()
    {
        Time.timeScale=0f;
        Points = 0;
    }

    public static void AddPoints(int amount)
    {
        Points = Points + amount;
        
    }
    private void Update()
    {
      pointstext.text = Points.ToString();
      if(Input.GetKey(KeyCode.A))
      Time.timeScale=1f;
       
    }
}