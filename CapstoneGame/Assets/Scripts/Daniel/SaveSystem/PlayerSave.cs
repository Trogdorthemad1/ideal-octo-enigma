﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    CharacterHealth player;
    private void Start()
    {
        player = this.gameObject.GetComponent<CharacterHealth>();
    }
    void Update()
    {
        //Call the Save System's Save Player function when you press 1. Pass it the current Player script component.
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }

        //Call the Save System's Load Player function
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            //Load player returns type PlayerData
            PlayerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                player.health = data.playerHealth;
                transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
            }
        }
    }
    public void Save()
    {
        SaveSystem.SavePlayer(player);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            Save();
        }
    }
}
