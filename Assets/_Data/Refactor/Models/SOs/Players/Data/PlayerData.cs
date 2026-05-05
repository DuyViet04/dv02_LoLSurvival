using System;
using Base.Systems.Stat;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Players.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private string charName;
        [SerializeField] private Stat pickUpRange;
        [SerializeField] private Stat expMultiplier;

        public string CharName => charName;
        public Stat PickUpRange => pickUpRange;
        public Stat ExpMultiplier => expMultiplier;

        public PlayerData(PlayerData playerData)
        {
            charName = playerData.charName;
            pickUpRange = new Stat(playerData.pickUpRange);
            expMultiplier = new Stat(playerData.expMultiplier);
        }
    }
}