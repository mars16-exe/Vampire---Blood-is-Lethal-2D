using UnityEngine;
using UnityEngine.SceneManagement;

public class startManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
