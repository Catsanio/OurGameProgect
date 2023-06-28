using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevlManager : MonoBehaviour

{
    public static int level = 1;
    [SerializeField] private Transform levelButtons;
    [SerializeField] private Animator playButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Level") > level)
            level = PlayerPrefs.GetInt("Level");
        for (int i = 0; i < levelButtons.childCount; i++)
            levelButtons.GetChild(i).GetComponent<Button>().interactable = level > i;
    }

    public void Play(int index)
    {
        level = index;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Play_1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayAnimation()
    {
        playButton.SetTrigger("PlayButton");
    }
}

