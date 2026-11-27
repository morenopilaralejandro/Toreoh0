using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleComponentCutsceneBattle
{
    private Battle battle;
    private SceneLoaderManager sceneLoaderManager;
    private Coroutine coroutineUI;
    private Coroutine coroutineGameplay;
    private float timeElapsed = 0f;
    private float duration = 1.5f;

    public BattleComponentCutsceneBattle(Battle battle)
    {
        this.battle = battle;
        sceneLoaderManager = SceneLoaderManager.Instance;
    }

    public void PlayCutsceneMove(Move move)
    {
        StopCoroutineUI();
        UIEvents.RaiseCutsceneBattleStarted(move.MoveComponentLocalization.Name, null);
        sceneLoaderManager.StartCoroutineHelper(ExecuteCoroutineUI(duration));
    }

    private void StopCoroutineUI()
    {
        if (coroutineUI == null) return;
        sceneLoaderManager.StopCoroutineHelper(coroutineUI);
        coroutineUI = null;
        UIEvents.RaiseCutsceneBattleEnded();
    }

    private void StopCoroutineGameplay()
    {
        if (coroutineGameplay == null) return;
        sceneLoaderManager.StopCoroutineHelper(coroutineGameplay);
        coroutineGameplay = null;
        UIEvents.RaiseCutsceneBattleEnded();
        // resume play
    }

    private IEnumerator ExecuteCoroutineUI(float duration)
    {
        timeElapsed = 0;
        while (timeElapsed < duration) 
        {
            if (BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle) yield return null;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        UIEvents.RaiseCutsceneBattleEnded();
    }

    private IEnumerator ExecuteCoroutineGameplay(float duration)
    {
        timeElapsed = 0;
        while (timeElapsed < duration) 
        {
            if (BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle) yield return null;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        UIEvents.RaiseCutsceneBattleEnded();
        // resume play
    }

    /*
        special move dont pause
        special wing pause (use coroutine and resume battle when effect is finished)
        particle system IsAlive
    */
}
