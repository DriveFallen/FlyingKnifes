using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Интерфейс")]
    [SerializeField] private GameObject PauseFrame;
    [SerializeField] private GameObject GameOverFrame;
    [SerializeField] private GameObject WinFrame;
    [SerializeField] private Text KnifeCountTXT;
    [Space]
    [Header("Настройки ножей")]
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float pushPower = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int startKnifeCount = 3;

    public static int fruitsCount;
    public static int knifeCount;

    private float lastFireTime;
    private GameObject newKnife;
    private bool isPused = false;

    private void Start()
    {
        fruitsCount = GameObject.FindGameObjectsWithTag("Fruit").Length;
        knifeCount = startKnifeCount;

        lastFireTime = 0;
    }

    private void Update()
    {
        KnifeCountTXT.text = $"Ножей осталось: {knifeCount}";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (fruitsCount == 0)
        {
            WinFrame.SetActive(true);
        }
        else if (knifeCount <= 0)
        {
            GameOverFrame.SetActive(true);
        }       
    }
    
    public void Shoot()
    {
        if (knifeCount > 0 && Time.time > lastFireTime + fireRate)
        {
            newKnife = Instantiate(knifePrefab);
            newKnife.transform.position = new Vector2(0f, -4f);
            newKnife.GetComponent<Rigidbody2D>().velocity = Vector2.up * pushPower;

            newKnife = null;

            lastFireTime = Time.time;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPused = true;
        PauseFrame.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPused = false;
        PauseFrame.SetActive(false);
    }

    public void NextLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
