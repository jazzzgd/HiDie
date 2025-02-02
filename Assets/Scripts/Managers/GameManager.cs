using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject shopMenu;
    public GameObject pauseMenu;
    public int money;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI timeText;

    private float startTime;
    private float score;

    //  Проверка существования экземпляра класса.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //  Присваивание текущего количества денег.
    private void Start()
    {
        startTime = Time.time;
        money = SaveManager.instance.activeSave.currentMoney;
    }

    //  Реализация магазина и меню паузы.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Shop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
        
        UpdateMoneyText();
        
        score = Time.time - startTime;
        timeText.text = "Time: " + score.ToString("F");
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);  //pauseMenu.SetActiveRecursively(true);
    }
    public void Shop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);  //shopMenu.SetActiveRecursively(true);
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    //  Обновление текущего количества денег игрока.
    public void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString();
        }
    }
}
