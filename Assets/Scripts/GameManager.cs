using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject shopMenu;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Shop();
        }
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
}
