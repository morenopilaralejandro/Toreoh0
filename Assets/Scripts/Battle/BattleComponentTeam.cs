using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleComponentTeam
{
    //use this to instatiate characters etc
    //asign characters to team


    private Battle battle;

    public Dictionary<BattleSide, Team> DictTeam;


    public BattleComponentTeam(Battle battle)
    {
        this.battle = battle;

        

    }


    

    /*
        for each team
        if id initialize by data
        if save data intialize by save data
    */


    public void Clear() 
    {

    }
}
