using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject player;
    public BallMoviment script;

    private void Start()
    {
        script = player.GetComponent<BallMoviment>();
    }

    private void Update()
    {
        if(!script.Vida())
        {
            SceneManager.LoadScene("morte");
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}


