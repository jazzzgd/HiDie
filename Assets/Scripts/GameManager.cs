using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject shopMenu;
    public int money;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        money = SaveManager.instance.activeSave.currentMoney;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Shop();
        }
        
        UpdateMoneyText();
    }

    public void Shop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
    }

    public void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }
}
