using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem fire;
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI score;
    public TextMeshProUGUI Hscore;
    int noCoins;
    int noScore;
    int HnoScore;
    public static bool GameOver;
    public GameObject OverPanel;
    public GameObject PausePanel;
    public GameObject StartPanel;

    public GameObject Player;
    bool pause;

    float temp;
    public Button PauseBut;
    private void Awake()
    {
        fire.gameObject.SetActive(true);
        Application.targetFrameRate = 60;
        GameOver = false;
        StartPanel.SetActive(true);
        PausePanel.SetActive(false);
        OverPanel.SetActive(false);
        Time.timeScale = 0;
        noScore = 0;
        pause = true;
        PauseBut.interactable = false;
    }
    // Start is called before the first frame update
    public void Start()
    {
        fire.gameObject.SetActive(true);
        AudioManager.instance.Play("level");
        Player.GetComponent<SwipeFinger>().enabled = false;
        temp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        noCoins = PlayerPrefs.GetInt("coin");
        Coin.text = noCoins.ToString();
        HnoScore = PlayerPrefs.GetInt("highscore");
        Hscore.text = HnoScore.ToString();
        if (pause == false)
        {
            noScore = noScore + 1;
            Time.timeScale = Time.timeScale+0.001f;
        }
        score.text = noScore.ToString();
        if(GameOver==true)
        {
            Death();
        }
    }
    public void Death()
    {
        //Time.timeScale = 0;
        OverPanel.SetActive(true);

        Player.GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        Player.GetComponent<SwipeFinger>().enabled = false;
        fire.gameObject.SetActive(false);
       AudioManager.instance.Stop("level");
        pause = true;
        if(noScore>HnoScore)
        {
            PlayerPrefs.SetInt("highscore", noScore);
        }
        PauseBut.interactable = false;
    }
    public void Play()
    {
        Time.timeScale = 1;
        OverPanel.SetActive(false);
        StartPanel.SetActive(false);
        PausePanel.SetActive(false);
        fire.gameObject.SetActive(true);
        AudioManager.instance.Play("click");
        pause = false;
        PauseBut.interactable = true;
        Player.GetComponent<SwipeFinger>().enabled = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.Play("click");
    }
    public void Pause()
    {
        PauseBut.interactable = false;
        PausePanel.SetActive(true);
        AudioManager.instance.Play("click");
        temp = Time.timeScale;
        Time.timeScale = 0;
        Debug.Log(temp);
        pause = true;
        Player.GetComponent<SwipeFinger>().enabled = false;
    }
    public void Resume()
    {
        pause = false;
        PausePanel.SetActive(false);
        AudioManager.instance.Play("click");
        Time.timeScale = temp;
        PauseBut.interactable = true;
        Player.GetComponent<SwipeFinger>().enabled = true;
    }

        
}
