using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BattleComponentCharacter
{
    private Battle battle;

    private Transform parentCharacter;
    private List<AddressableBinding<GameObject>> listBinding = new ();

    public BattleComponentCharacter(Battle battle, Transform parentCharacter)
    {
        this.battle = battle;
        this.parentCharacter = parentCharacter;
    }

    public async Task LoadAsync() 
    {
        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
        {
            team.TeamComponentCharacter.InitializeForBattle();
            for (int j = 0; j < team.TeamComponentCharacter.ListCharacterPointRuntime.Count; j++)
            {
                Character character = team.TeamComponentCharacter.ListCharacterPointRuntime[j];
                var mapping = battle.BattleComponentConfig.BattleConfig.DictListCoordCharacterSpawn[team.TeamComponentSide.BattleSide];
                var coord = new FormationCoord(mapping.FormationCoordData);

                AddressableBinding<GameObject> binding = new();
                string address = AddressableBuilder.GetCharacterPrefabAddress(character.CharacterComponentAttributes.CharacterId);
                var prefab = await binding.LoadAssetAsync(address);
                listBinding.Add(binding);

                var go = BattleManager.Instance.InstantiateGameObject(
                    prefab,
                    coord.PositionComponent.FormationCoordPosition,
                    Quaternion.identity,
                    parentCharacter) as GameObject;
                var entity = go.GetComponent<CharacterEntityBattle>();
                entity.InitializeForBattle(character);
                entity.name = entity.Character.CharacterComponentAttributes.CharacterId;
                entity.Character.CharacterComponentSide.SetBattleSide(team.TeamComponentSide.BattleSide);
                entity.Character.CharacterComponentSide.SetEntityIndex(j);
                team.TeamComponentCharacter.ListCharacterPointEntity.Add(entity);
                entity.CharacterComponentModel.RotateInstant(new Vector3(mapping.RotationX, mapping.RotationY, mapping.RotationZ));
                entity.CharacterIndicatorBattleSide.SetBattleSide(team.TeamComponentSide.BattleSide);
                // await entity.LoadAsync();
            }
        }

        // same for assist characters (start deactivated)

        battle.BattleComponentTeam.EnableControlledCharacter();
        Dispose();
    }

    public void Dispose() 
    {
        foreach (var binding in listBinding)
            binding.CancelAndRelease();
        listBinding.Clear();
    }
}
