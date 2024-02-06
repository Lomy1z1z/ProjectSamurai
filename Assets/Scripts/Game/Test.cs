using SD_Core;
using SD_GameLoad;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] TMP_Text levelTextTest;
    private void Start()
    {
        if (SDGameLogic.Instance == null) Debug.LogError("SDGameLogic.Instance is null");
        if (SDGameLogic.Instance.PlayerDataLoad == null) Debug.LogError("PlayerDataLoad is null");
        if (SDGameLogic.Instance.PlayerDataLoad.CharacterData == null) Debug.LogError("CharacterData is null");
        if (SDGameLogic.Instance.PlayerDataLoad.CharacterData.Character == null) Debug.LogError("Character is null");
        levelTextTest.text = $"Lv.{SDGameLogic.Instance.PlayerDataLoad.CharacterData.Character.CharacterLevel}";
    }

    public void IncreaseLevel()
    {
        SDGameLogic.Instance.PlayerDataControl.LevelUp();
        SDDebug.Log(SDGameLogic.Instance.PlayerDataLoad.CharacterData.Character.CharacterLevel);
        levelTextTest.text = $"Lv.{SDGameLogic.Instance.PlayerDataLoad.CharacterData.Character.CharacterLevel}";
    }
}
