using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;


    [Inject] private DiContainer diCont;
    [Inject] private PlayerModel model;
    [Inject] private GameController gameController;

    public int BoatLevel => player.BoatLevel;
    public int WeaponLevel => player.WeaponLevel;
    public Transform PlayerTransform => player.transform;

    private void Start()
    {
        InitializePlayer(model.playerBoat);
        player.OnDestroyed += gameController.SetGameOver;
    }
    private void FixedUpdate()
    {
        if (!gameController.GameloopActive) return;
        player.Movement.MovementLoop();
    }
    public void InitializePlayer(Boat boat)
    {
        UpgradePlayerBoat(boat);
    }

    public void ConnectHealthView(HealthView view)
    {
        player.OnHealthChange += view.ChangeText;
        view.ChangeText(player.Health);
    }
    public void UpgradePlayerBoat(Boat boat)
    {
        var oldBoat = player.CurrentBoat;
        var newBoat = diCont.InstantiatePrefabForComponent<Boat>(boat);


        newBoat.transform.parent = player.transform;
        newBoat.transform.SetPositionAndRotation(oldBoat.transform.position, oldBoat.transform.rotation);

        player.CurrentBoat = newBoat;


        oldBoat.gameObject.SetActive(false);

        UpgradePlayerWeapon(model.playerWeapons); // update to new boat weapon positions

        model.playerBoat = boat; //saves for cross-scene data persistancy
        model.health = player.CurrentBoat.Health;

        player.Health = model.health;


        Destroy(oldBoat);
    }

    public void UpgradePlayerWeapon(WeaponsList weapons)
    {
        var tempList = new List<Weapon>();

        for (int i = 0; i < player.CurrentBoat.WeaponsHolder.Count; i++)
        {
            if (i >= weapons.list.Count) return;
            var newWeapon = diCont.InstantiatePrefabForComponent<Weapon>(weapons.list[i]);
            tempList.Add(newWeapon);

            newWeapon.transform.parent = player.CurrentBoat.WeaponsHolder[i];
            newWeapon.transform.SetPositionAndRotation(newWeapon.transform.parent.position, newWeapon.transform.parent.rotation);           
        }
        for (int i = 0; i < player.CurrentWeapons.list.Count; i++)
        {
            player.CurrentWeapons.list[i].gameObject.SetActive(false);
        }

        player.CurrentWeapons.level = weapons.level;
        player.CurrentWeapons.list = tempList;
        model.playerWeapons = weapons; //saves for cross-scene data persistancy
    }

    public void SetBossBattleMode()
    {

        player.RBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        player.transform.DORotateQuaternion(Quaternion.identity, 1f);
        player.Movement.FreezeTurn();
    }
}
