using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SD_Core;

namespace SD_GameLoad
{
    public class PlayerDataControl
    {
        public void LevelUp()
        {
            SDGameLogic.Instance.PlayerDataLoad.CharacterData.Character.CharacterLevel++;
            SDGameLogic.Instance.PlayerDataLoad.CharacterData.SaveData();
        }
    }
}