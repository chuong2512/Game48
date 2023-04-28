using UnityEngine;

public class BGSelector : MonoBehaviour
{
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; 
    public int currentBG;
    public SkinItem[] skinItems;
    
    void Start()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;
        
      
        
        skinItems[currentBG].Choose();
    }
    
    public void ChooseSkin(int index)
    {
        if (currentBG == index)
        {
            return;
        }
        
        
        skinItems[currentBG].UnChoose();
        skinItems[index].Choose();
        currentBG = index;
        playerData.ChooseBG(currentBG);
        
        //todo add Playerdata
    }


    public void UnlockBG(int index)
    {

    }

}
