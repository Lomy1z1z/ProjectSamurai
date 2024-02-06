using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SD_Core;
using SD_GameLoad;

namespace SD_GameLoad
{
    public class PlayerData
    {
        public int CharacterLevel = 1;
    }

    public class CharacterData : ISDSaveData
    {
        public PlayerData Character { get; set; }

        public CharacterData()
        {
            Character = new PlayerData();
        }
    }

}