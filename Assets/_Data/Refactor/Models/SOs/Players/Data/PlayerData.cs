using System;
using UnityEngine;

namespace _Data.Refactor.Models.SOs.Players.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private string charName;
        [SerializeField] private int pickUpRange;
        [SerializeField] private float expMultiplier;

        public string CharName => charName;
        public float PickUpRange => pickUpRange;
        public float ExpMultiplier => expMultiplier;

        public PlayerData(PlayerData playerData)
        {
            charName = playerData.charName;
            pickUpRange = playerData.pickUpRange;
            expMultiplier = playerData.expMultiplier;
        }
    }
}