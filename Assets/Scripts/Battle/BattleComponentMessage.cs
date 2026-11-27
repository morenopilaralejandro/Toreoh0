using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleComponentMessage
{
    private Battle battle;
    private BattleConfig config;
    private SceneLoaderManager sceneLoaderManager;
    private Coroutine coroutine;
    private float timeElapsed = 0f;

    public BattleComponentMessage(Battle battle, BattleConfig config)
    {
        this.battle = battle;
        this.config = config;
        sceneLoaderManager = SceneLoaderManager.Instance;
    }

    public void PlayMessage(BattleMessage battleMessage)
    {
        StopCoroutine();
        battle.BattleComponentPause.PauseBattle();
        UIEvents.RaiseBattleMessageStarted(battleMessage);
        sceneLoaderManager.StartCoroutineHelper(ExecuteCoroutine(config.DictBattleMessageMapping[battleMessage].Duration));
    }

    private void StopCoroutine()
    {
        if (coroutine == null) return;
        sceneLoaderManager.StopCoroutineHelper(coroutine);
        coroutine = null;
        UIEvents.RaiseBattleMessageEnded();
    }

    private IEnumerator ExecuteCoroutine(float duration)
    {
        timeElapsed = 0;
        while (timeElapsed < duration) 
        {
            // if (BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle) yield return null;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        UIEvents.RaiseBattleMessageEnded();
        battle.BattleComponentPause.ResumeBattle();
    }
}
