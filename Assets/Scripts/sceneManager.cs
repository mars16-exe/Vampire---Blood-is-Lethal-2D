using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    //private AudioSource soundMaker;

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    //public void ClickyNoise()
    //{
    //    soundMaker.PlayOneShot(soundMaker.clip);
    //}
}
