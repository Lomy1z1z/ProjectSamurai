using System;
using SD_Core;

namespace SD_GameLoad
{
    /// <summary>
    /// Manages game logic, including ability data, boss data, player data and the store.
    /// </summary>
    public class SDGameLogic : ISDBaseManager
    {
        public static SDGameLogic Instance;
        public PlayerDataLoad PlayerDataLoad;
        public PlayerDataControl PlayerDataControl;

        public SDGameLogic()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;
        }

        /// <summary>
        /// Initializes the game logic manager.
        /// </summary>
        /// <param name="onComplete">A callback function to be invoked when initialization is complete.</param>
        public void LoadManager(Action onComplete)
        {
            PlayerDataLoad = new PlayerDataLoad();
            PlayerDataControl = new PlayerDataControl();

            SDDebug.Log("GameLogic Data Initialized");
            onComplete.Invoke();
        }
    }
}