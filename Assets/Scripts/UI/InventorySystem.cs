using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    [Header("GameObjects")]
    public GameObject inventoryUI;

    [Header("UI Elements")]
    public Text inventoryText;
    public GameObject holyIMG;
    public GameObject bazookaIMG;
    public GameObject grenadeIMG;


    //Private Items
    bool _inventoryOpen;

    void Start()
    {
        inventoryUI.SetActive(false);
        _inventoryOpen = false;
        bazookaIMG.SetActive(false);
        holyIMG.SetActive(false);
        grenadeIMG.SetActive(false);
    }
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _inventoryOpen = !_inventoryOpen;

                
            if (_inventoryOpen)
            {
                inventoryUI.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                ReturnGame();
            }
        }
    }

    public void EquipHolyHandGrenade()
    {
        bazookaIMG.SetActive(false);
        holyIMG.SetActive(true);
        grenadeIMG.SetActive(false);
        ReturnGame();
    }

    public void EquipGrenade()
    {
        bazookaIMG.SetActive(false);
        holyIMG.SetActive(false);
        grenadeIMG.SetActive(true);
        ReturnGame();
    }

    public void EquipBazooka()
    {
        bazookaIMG.SetActive(true);
        holyIMG.SetActive(false);
        grenadeIMG.SetActive(false);
        ReturnGame();
    }

    public void ReturnGame()
    {
        Time.timeScale = 1f;
        inventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
