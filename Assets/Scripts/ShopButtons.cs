using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButtons : MonoBehaviour
{
    public WeaponSystem weaponSystem;
    public int itemCost;
    public int amountToAdd;
    public int positionWeapon;
    public TextMeshProUGUI itemPriceText;

    private void Update()
    {
        itemPriceText.text = itemCost.ToString();
    }

    public void Buy()
    {
        if (GameManager.Instance.money >= itemCost)
        {
            GameManager.Instance.money -= itemCost;
            SaveManager.instance.activeSave.currentMoney = GameManager.Instance.money;
            weaponSystem.weapons[positionWeapon].ammo += amountToAdd;
            GameManager.Instance.UpdateMoneyText(); 
            AudioManager.instance.PlaySFX(6);
        }
    }
}
