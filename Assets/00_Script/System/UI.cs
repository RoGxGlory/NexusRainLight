using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class UI : MonoBehaviour
{
    public Image firstCase, secondCase, thirdCase, fourthCase;
    public GameObject Inv;
    bool bIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(Sprite collected, string type)
    { 
        if(type == "Weapon")
        firstCase.sprite = collected;
        else
        {
            Inv.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = collected.GetComponent<SpriteRenderer>().sprite;
        }

    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if(bIsOpen == false)
        {
            Inv.SetActive(true);
            bIsOpen = true;
        }
        else
        {
            Inv.SetActive(false);
            bIsOpen = false;
        }
    }
}
