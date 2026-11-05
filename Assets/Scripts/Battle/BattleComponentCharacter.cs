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
        this.parentCharacter = parentCharacter;
    }

    public async Task LoadAsync() 
    {
        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
        {
            foreach (var characterData in team.TeamComponentCharacter.ListCharacterPointData)
            {
                var mapping = battle.BattleComponentConfig.BattleConfig.DictListCoordCharacterSpawn[team.TeamComponentSide.BattleSide];
                var coord = new FormationCoord(mapping.FormationCoordData);
                coord.RotationComponent.SetRotationEuler(0f, mapping.RotationY, 0f);

                AddressableBinding<GameObject> binding = new();
                string address = AddressableBuilder.GetCharacterPrefabAddress(characterData.CharacterId);
                var prefab = await binding.LoadAssetAsync(address);
                listBinding.Add(binding);

                var go = BattleManager.Instance.InstantiateGameObject(
                    prefab,
                    coord.PositionComponent.FormationCoordPosition,
                    coord.RotationComponent.FormationCoordRotation,
                    parentCharacter) as GameObject;
                var entity = go.GetComponent<CharacterEntityBattle>();
                team.TeamComponentCharacter.ListCharacterPointEntity.Add(entity);
                //entity.InitializeForBattle(character);
                // await entity.LoadAsync();

                //TODO test if it is better to use character instead of characterData
            }
        }

        // same for assist characters (start deactivated)
    }

    public void Dispose() 
    {
        foreach (var binding in listBinding)
            binding.CancelAndRelease();
        listBinding.Clear();
    }
}
