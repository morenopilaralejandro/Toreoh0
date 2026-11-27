public class SelectorMoveActionClickPerform : ISelectorActionClick<Move>
{
    public CharacterEntityBattle Entity;

    public SelectorMoveActionClickPerform(CharacterEntityBattle entity) 
    {
        Entity = entity;
    }

    public void Execute(Move obj, IMenuClosable menu)
    {
        if (Entity.Character.CharacterComponentMove.IsAffordable(obj))
        {
            Entity.CharacterComponentModel.RotateInstant(Entity.CharacterComponentTarget.GetDirectionToTarget());
            Entity.CharacterComponentStateLock.StartStateLock(obj.MoveComponentFrame.FrameRecovery);
            Entity.Character.CharacterComponentStatsMp.ModifyMpWithClamp(-obj.MoveComponentAttributes.Cost);
            menu.RequestClose();
            UIEvents.RaiseMenuBattleCommandCloseRequested();
            UIEvents.RaiseCharacterMpDecreased(Entity);
            BattleManager.Instance.Battle.BattleComponentCutsceneBattle.PlayCutsceneMove(obj);
            BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(Entity, obj);
        } 
        else 
        {
            CustomLog.Error($"[SelectorMoveActionClickPerform] cant afford");
            // TODO play sfx
        }
    }
}
