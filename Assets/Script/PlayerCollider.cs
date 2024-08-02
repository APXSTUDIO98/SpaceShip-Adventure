using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            GameManager.GameOver = true;
            AudioManager.instance.Play("over");
        }
        if(collision.tag=="coin")
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin")+1);
          
            AudioManager.instance.Play("coin");
            Destroy(collision.gameObject);
        }
    }
}
