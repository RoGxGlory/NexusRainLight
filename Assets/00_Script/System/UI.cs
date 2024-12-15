using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;


public class UI : MonoBehaviour
{
    public Image firstCase, secondCase, thirdCase, fourthCase;
    public GameObject Inv;
    public GameManager manager;

    bool bIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        OnLevelLoaded();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Inventory
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
    #endregion

    #region Scene Management

    private void OnLevelLoaded()
    {
        manager.LoadVariables();
    }

    public void OpenMenuLevel()
    {
        string SceneToLoad = "Main Menu";
        SceneManager.LoadScene(SceneToLoad);
        manager.MenuSceneChange(SceneToLoad);
    }
    public void OpenMarketLevel()
    {
        string SceneToLoad = "Market";
        SceneManager.LoadScene(SceneToLoad);
        manager.MenuSceneChange(SceneToLoad);
    }
    public void OpenDebtLevel()
    {
        string SceneToLoad = "Debt";
        SceneManager.LoadScene(SceneToLoad);
        manager.MenuSceneChange(SceneToLoad);
    }
    public void OpenGameLevel()
    {
        string SceneToLoad = "CharacterTestMap";
        SceneManager.LoadScene(SceneToLoad);
        manager.MenuSceneChange(SceneToLoad);
    }
    #endregion
}
