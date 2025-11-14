using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //singleton (ask what that means)
    public static GameManager instance;
    public Transform[] spawnpoints;

    public List<PlayerController> players; //list of active players that joined the game

    public GamePhase phase = GamePhase.starting; //State machine variable to orchestrate the game loop

    public Timer timer;

    public PlayerController victor; //player who has won;
    public void Awake()
    {
        if (instance != null) //singleton initialization
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        //timer.enabled=false;//disable timer until all player joins
    }
    public void OnPlayerJoined(PlayerInput input) //Message that listens to PlayerInputManager, running when a player joins
    {
        Transform nextSpawnPosition = spawnpoints[players.Count];
    }
    public void KillAll() //Used by timer to end the game if no one jumps in time
    { }
   /* public bool CanPlayerJump() //only one player can jump per round
    { }*/
    public void OnPlayerJumped(PlayerController player) //when player jumps, run this and end the round
    { }
   /* public IEnumerator EndRound() //used to end the game regardless of outcome and resets
    { }*/
    public enum GamePhase
    {
        starting,
        started,
        ending
    }
}
