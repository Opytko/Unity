using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public Move move;
    public float LevelRestartDelay = 2f;

    public void EndGame()
    {
        move.enabled = false;

        Invoke("RestartLevel", LevelRestartDelay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    


}
