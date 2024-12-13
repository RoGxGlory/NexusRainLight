using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState State;

    private int Money;

    private AudioSystem audioSystem;

    [SerializeField] private GameObject MoneyText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<GameManager>();
            DontDestroyOnLoad(gameObject);
            Debug.Log("Instance not found" + Instance);
        }
        else
        {
            Debug.Log("Instance already found" + Instance);
        }
        audioSystem = gameObject.GetComponent<AudioSystem>();
    }

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
    public void UpdateMoney(int CollectedMoney)
    {
        Money += CollectedMoney;
        Debug.Log(Money);
        MoneyText.GetComponent<TextMeshProUGUI>().SetText("Argent : " + Money);
    }
    void PlayAudio()
    {
        audioSystem.ReturnAudio();
    }
}

public enum GameState
{
    Victory,
    Lose
}