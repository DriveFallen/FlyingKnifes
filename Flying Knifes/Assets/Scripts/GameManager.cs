using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int fruitsCount;
    public static int knifeCount;

    [Header("Интерфейс")]
    [SerializeField] private GameObject GameOverFrame;
    [SerializeField] private GameObject WinFrame;
    [SerializeField] private Text LevelNumberTXT;
    [SerializeField] private Text KnifeCountTXT;
    [Space]
    [Header("Настройки ножей")]
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float pushPower = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int startKnifeCount = 3;

    private float lastFireTime;
    private GameObject newKnife;

    private void Start()
    {
        Time.timeScale = 1;
        fruitsCount = GameObject.FindGameObjectsWithTag("Fruit").Length;
        knifeCount = startKnifeCount;
        LevelNumberTXT.text = $"Level: {SceneManager.GetActiveScene().buildIndex}";
        lastFireTime = 0;
    }

    private void Update()
    {
        KnifeCountTXT.text = $"Ножей осталось: {knifeCount}";

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
}
