using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    public TextMeshProUGUI ammoInterface;
    public Image weaponTypeUI;
    public Weapon[] weapons;
    public Weapon usedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        usedWeapon = weapons[0];
        UpdateWeaponUI();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapon();
    }

    public void EquipWeapon(int weaponToEquip)
    {
        usedWeapon = weapons[weaponToEquip - 1];
        UpdateWeaponUI();
    }

    public void SwitchWeapon()
    {
        if (Input.GetKeyDown((KeyCode.Alpha1)))
        {
            EquipWeapon(1);
        }
        
        if (Input.GetKeyDown((KeyCode.Alpha2)))
        {
            EquipWeapon(2);
        }
        
        if (Input.GetKeyDown((KeyCode.Alpha3)))
        {
            EquipWeapon(3);
        }
    }

    public void UpdateWeaponUI()
    {
        ammoInterface.text = usedWeapon.ammo.ToString();
        weaponTypeUI.sprite = usedWeapon.weaponIcon;
    }
}
