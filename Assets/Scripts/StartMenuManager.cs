using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{

    public Button startButton;
    public Button fakeQuitButton;
    public Button returnButton;
    public Button realQuitButton;
    public GameObject overlay;
    public GameObject fadeOutBox;
    public float fadeOutTimer;
    public float fadeOutTimerMax;
    public bool makeOpaque;
    public Color transparentBlack = new Color(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        overlay.SetActive(false);
        fadeOutBox.GetComponent<Image>().color = Color.black;
        makeOpaque = false;
        fadeOutTimerMax = 5;
        fadeOutTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOutTimer <= fadeOutTimerMax)
        {
            fadeOutTimer += Time.deltaTime;

            if (makeOpaque)
            {
                fadeOutBox.GetComponent<Image>().color = Color.Lerp(transparentBlack, Color.black, fadeOutTimer / fadeOutTimerMax);
                overlay.SetActive(true);
            }

            else
            {
                fadeOutBox.GetComponent<Image>().color = Color.Lerp(Color.black, transparentBlack, fadeOutTimer / fadeOutTimerMax);
            }
        }

        else if (!makeOpaque)
        {
            overlay.SetActive(false);
        }

    }

    public void startButtonPressed()
    {
        StartCoroutine(StartGame());
        
    }

    public IEnumerator StartGame()
    {

        SceneManager.LoadScene("Game_Scene");
        yield break;
    }

    public void fakeQuitButtonPressed()
    {
        overlay.SetActive(true);
    }

    public void returnButtonPressed()
    {
        overlay.SetActive(false);
    }

    public void realQuitButtonPressed()
    {
        print("this is where I would quit IF I WAS BUILT!!");
        Application.Quit();
    }
}
