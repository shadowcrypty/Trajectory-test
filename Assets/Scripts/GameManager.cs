using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public GameObject activeBall,Ballpref;

    public static bool Goal;

    private void OnEnable()
    {
        instance = GetComponent<GameManager>();
    }
    void Start()
    {
        
    }
   
   
    public void onFailed()
    {
        Destroy(activeBall);

        activeBall = Instantiate(Ballpref);
        activeBall.name = "Ball";
        BallMovment._index = 0;
    }
    public void onGoal()
    {
        //next scene
        SceneManager.LoadScene(1);
        BallMovment._index = 0;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
