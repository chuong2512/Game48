using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; 
    public int currentSkin;
    public SkinItem[] skinItems;

    void Start()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;
        
        currentSkin = playerData.currentSkin;
        
        for (int i = 0; i < skinItems.Length; i++)
        {
            if (playerData.listSkins[i])
            {
                skinItems[i].Unlock();
                skinItems[i].UnChoose();
            }
        }
        
        skinItems[currentSkin].Choose();
    }
    
    public void ChooseSkin(int index)
    {
        if (currentSkin == index)
        {
            return;
        }
        else if (playerData.listSkins[index] == false)
        {
            if (!playerData.CheckCanUnlock())
            {
                return;
            }
            UnlockSkin(index);
        }
        
        skinItems[currentSkin].UnChoose();
        skinItems[index].Choose();
        currentSkin = index;
        playerData.currentSkin = currentSkin;
        //todo add Playerdata
    }

    public void UnlockSkin(int index)
    {
        if (!playerData.listSkins[index])
        {
            playerData.SubDiamond(Constant.priceUnlockSkin);
        }
        
        skinItems[index].Unlock();
        playerData.Unlock(index);
    }

}
