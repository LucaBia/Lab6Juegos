using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPause = false;
    public Pelora ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if (isPause) Continue();
            else Pause();

            //isPause = (isPause) ? Continue() : Pause();
            //if (isPause)
            //    isPause = Continue();
            //else
            //    isPause = Pause();
    }

    public void Pause()
    {
        transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        isPause = true;
    }

    public void Continue()
    {
        transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        isPause = false;
    }

    public void HacerAlgo()
    {
        transform.Find("HacerAlgo").Find("Text").GetComponent<Text>().text = "Hice Algo";
    }

    public void Return(string _newScene)
    {
        SceneManager.LoadScene(_newScene);
    }

}
