using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public Image original;

    public GameObject Canvas_First;
    public GameObject Canvas_Second;
    public GameObject Canvas_Third;
    public GameObject Canvas_Fourth;
    public GameObject Canvas_Fifth;

    // Canvas 변경 
    public void ChangeCanvas(int i)
    {
        if(i == 0) // Go to Second Canvas
        {
            Canvas_First.SetActive(false);
            Canvas_Second.SetActive(true);
            Canvas_Third.SetActive(false);
            Canvas_Fourth.SetActive(false);
            Canvas_Fifth.SetActive(false);
        }
        else if (i == 1) // Go to First Canvas
        {
            Canvas_First.SetActive(true);
            Canvas_Second.SetActive(false);
            Canvas_Third.SetActive(false);
            Canvas_Fourth.SetActive(false);
            Canvas_Fifth.SetActive(false);
        }
        else if (i == 2) // Go to Third Canvas
        {
            Canvas_First.SetActive(false);
            Canvas_Second.SetActive(false);
            Canvas_Third.SetActive(true);
            Canvas_Fourth.SetActive(false);
            Canvas_Fifth.SetActive(false);
        }
        else if (i == 3) // Go to Fourth Canvas
        {
            Canvas_First.SetActive(false);
            Canvas_Second.SetActive(false);
            Canvas_Third.SetActive(false);
            Canvas_Fourth.SetActive(true);
            Canvas_Fifth.SetActive(false);
        }
        else //Go to Fifth Canvas
        {
            Canvas_First.SetActive(false);
            Canvas_Second.SetActive(false);
            Canvas_Third.SetActive(false);
            Canvas_Fourth.SetActive(false);
            Canvas_Fifth.SetActive(true);
        }
    }

    public void MovetoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    // 게임 종료 메소드
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
