using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharaterStats))]
public class Enemy : Interactable
{

    PlayerManager playerManager;
    CharaterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharaterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        // todo.. Àû °ø°Ý
        CharaterCombat playerCombat = playerManager.player.GetComponent<CharaterCombat>();

        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

   
}
