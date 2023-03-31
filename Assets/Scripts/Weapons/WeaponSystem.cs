using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    public TextMeshProUGUI ammoInterface;
    public Image weaponTypeUI;
    public Weapon[] weapons;
    public Weapon usedWeapon;
    public Animator animator;
    public bool pistolAnim;
    public bool rifleAnim;
    public bool shotgunAnim;

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
            animator.SetBool("PistolAnim", true);
            pistolAnim = true;
            animator.SetBool("RifleAnim", false);
            rifleAnim = false;
            animator.SetBool("ShotgunAnim", false);
            shotgunAnim = false;
        }
        
        if (Input.GetKeyDown((KeyCode.Alpha2)))
        {
            EquipWeapon(2);
            animator.SetBool("RifleAnim", true);
            rifleAnim = true;
            animator.SetBool("PistolAnim", false);
            rifleAnim = false;
            animator.SetBool("ShotgunAnim", false);
            shotgunAnim = false;
        }
        
        if (Input.GetKeyDown((KeyCode.Alpha3)))
        {
            EquipWeapon(3);
            animator.SetBool("ShotgunAnim", true);
            shotgunAnim = true;
            animator.SetBool("RifleAnim", false);
            rifleAnim = false;
            animator.SetBool("PistolAnim", false);
            shotgunAnim = false;
        }
    }

    public void UpdateWeaponUI()
    {
        ammoInterface.text = usedWeapon.ammo.ToString();
        weaponTypeUI.sprite = usedWeapon.weaponIcon;
    }
}
