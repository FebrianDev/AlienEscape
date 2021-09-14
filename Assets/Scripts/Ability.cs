using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject panelPause = null, panelGameOver = null, pause = null, blurEffect;

    [SerializeField]private Text textScore = null, textBestScore = null, textYourScore = null, textYourBestScore = null;
    [SerializeField] private GameObject [] itemShow = null;
    int bestScore;

    void Start()
    {
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        blurEffect.SetActive(false);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        textScore.enabled = true;
        textBestScore.enabled = true;

        foreach (var i in itemShow)
        {
            i.SetActive(false);
        }

        pause.SetActive(true);
    }
    
    void Update()
    {
        textScore.text = "Score\n" + DataPlayer.score;
        textBestScore.text = "Best Score : " + bestScore;

        if (DataPlayer.invisible)
        {
            print("Invisible");
            itemShow[0].SetActive(true);
            itemShow[1].SetActive(false);
        }else if (DataPlayer.shield)
        {
            print("Shield");
            itemShow[0].SetActive(false);
            itemShow[1].SetActive(true);
        }
        else
        {
            itemShow[0].SetActive(false);
            itemShow[1].SetActive(false);
        }

        if (DataPlayer.isGameOver)
        {
            if(DataPlayer.score > bestScore)
            {
                textYourBestScore.text = "Your Best Score : " + DataPlayer.score;
                PlayerPrefs.SetInt("BestScore", DataPlayer.score);
            }
            else
            {
                textYourBestScore.text = "Your Best Score : " + bestScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }

            textYourScore.text = "Your Score : " + DataPlayer.score;
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
            blurEffect.SetActive(true);

            textScore.enabled = false;
            textBestScore.enabled = false;
            pause.SetActive(false);

            foreach (var i in itemShow)
            {
                i.SetActive(false);
            }
        }

        if (DataPlayer.health <= 0)
        {
            DataPlayer.isGameOver = true;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        panelPause.SetActive(true);
        blurEffect.SetActive(true);
    }

    public void Resume()
    {
        blurEffect.SetActive(false);
        Time.timeScale = 1f;
        panelPause.SetActive(false);
    }

    public void Restart()
    {
        DataPlayer.isGameOver = false;
        panelGameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        DataPlayer.isGameOver = false;
        panelGameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
