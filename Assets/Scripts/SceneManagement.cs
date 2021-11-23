using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour    
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Tutorial()
    {
          SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
