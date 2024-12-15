using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditor.U2D.Animation;
using System.Threading;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State;

    private AudioSystem audioSystem;
    [SerializeField] private int Money;
    [SerializeField] private GameObject MoneyText;

    #region Instancing
    void Awake()
    {

        if (Instance != null)
        {
            Debug.Log("Other instance found ! Deleting...");
            Destroy(gameObject);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(gameObject);

        Debug.Log("Awakening finished");
    }

    void Start()
    {
        audioSystem = gameObject.GetComponent<AudioSystem>();
        MoneyText = GameObject.Find("Total Money");
    }
    #endregion

    #region Audio Setup
    void PlayAudio()
    {
        audioSystem.ReturnAudio();
    }
    #endregion

    #region Useful Functions
    public void QuitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }

    async Task UseDelay(int TimeToWait)
    {
        await Task.Delay(TimeSpan.FromSeconds(TimeToWait));
    }
    #endregion

    #region Game State
    /// <summary>
    /// Permet d'exécuter de la logique dépendamment des états du jeu ( Victoire, Perte, ou autres si implémentées dans l'enum "GameState" en bas du script )
    /// </summary>
    /// <param name="newState"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }
    }
    #endregion

    #region Scene Management

    public void LoadVariables()
    {
        MoneyText = GameObject.Find("Total Money");
        MoneyText.GetComponent<TextMeshProUGUI>().SetText("Argent : " + Money);
        Debug.Log("Called");
    }
    public void ChangeMoney(int CollectedMoney)
    {
        Money += CollectedMoney;
        Debug.Log(Money);
        MoneyText.GetComponent<TextMeshProUGUI>().SetText("Argent : " + Money);
    }

    public void MenuSceneChange(string OpenedScene)
    {
        switch (OpenedScene) 
        {
            case "Main Menu":
                Debug.Log("Main Menu Scene Opened");
                MoneyText = GameObject.Find("Total Money");
                LoadVariables();
                break;

            case "Debt":
                Debug.Log("Debt Scene Opened");
                MoneyText = GameObject.Find("Total Money");
                LoadVariables();
                break;

            case "Market":
                Debug.Log("Market Scene Opened");
                MoneyText = GameObject.Find("Total Money");
                LoadVariables();
                break;

            default:
                Debug.Log("ERROR : Scene " + OpenedScene + " not found !\n" );
                QuitGame();
                break;
        
        }
    }
    #endregion
}

public enum GameState
{
    Victory,
    Lose
}