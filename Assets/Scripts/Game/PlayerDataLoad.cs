using SD_Core;

namespace SD_GameLoad
{
    public class PlayerDataLoad
    {
        public CharacterData CharacterData;

        public PlayerDataLoad()
        {
            SDManager.Instance.SaveManager.Load(delegate (CharacterData data)
            {
                if (data == null)
                {
                    CharacterData = new CharacterData();
                }
                else
                {
                    CharacterData = data;
                }
            });
        }
    }
}