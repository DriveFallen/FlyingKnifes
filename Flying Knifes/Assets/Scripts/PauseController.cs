using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseFrame;
    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                _isPaused = false;
                Time.timeScale = 1.0f;
                pauseFrame.SetActive(false);
            }
            else
            {
                _isPaused = true;
                Time.timeScale = 0.0f;
                pauseFrame.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1.0f;
        pauseFrame.SetActive(false);
    }
}
