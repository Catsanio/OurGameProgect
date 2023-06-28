using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag is "Player")
                Invoke("GoToMenu", 1f);
        }

        private void GoToMenu()
        {
        LevlManager.level++;
            if (PlayerPrefs.GetInt("Level") < LevlManager.level)
            {
                PlayerPrefs.SetInt("Level", LevlManager.level);
            }
            SceneManager.LoadScene(2);
        }
    
}
