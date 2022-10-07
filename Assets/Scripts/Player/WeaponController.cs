using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{   

    [Header("Models")]
    public GameObject bazookaModel;
    public GameObject holyGrenadeModel;
    public GameObject grenadeModel;


    public void Start()
    {
        bazookaModel.SetActive(false);
        holyGrenadeModel.SetActive(false);
        grenadeModel.SetActive(false);
    }

    public void BazookaEquipped()
    {
        if (gameObject.GetComponent<PlayerController>().enabled == true)
        {
            bazookaModel.SetActive(true);
            holyGrenadeModel.SetActive(false);
            grenadeModel.SetActive(false);
        }
    }

    public void HolyEquipped()
    {
        if (gameObject.GetComponent<PlayerController>().enabled == true)
        {
            bazookaModel.SetActive(false);
            holyGrenadeModel.SetActive(true);
            grenadeModel.SetActive(false);
        }
    }

    public void GrenadeEquipped()
    {
        if (gameObject.GetComponent<PlayerController>().enabled == true)
        {
            bazookaModel.SetActive(false);
            holyGrenadeModel.SetActive(false);
            grenadeModel.SetActive(true);
        }
    }
}
