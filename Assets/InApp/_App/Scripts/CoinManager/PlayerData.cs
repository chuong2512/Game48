using System;
using UnityEngine;

public class Constant
{
    public static string DataKey_PlayerData = "player_data";
    public static int countSkin = 9;
    public static int countBG = 5;
    public static int priceUnlockSkin = 20;
}

public class PlayerData : BaseData
{
    public int intDiamond;
    public int highPoint;
    public int point;
    public int level;
    public int currentSkin;
    public bool[] listSkins;

    public Action<int> onChangeDiamond;
    public Action<int> onChangePoint;

    public void NextLevel()
    {
        level++;
        Save();
    }
    
    public override void Init()
    {
        prefString = Constant.DataKey_PlayerData;
        if (PlayerPrefs.GetString(prefString).Equals(""))
        {
            ResetData();
        }

        base.Init();
    }


    public override void ResetData()
    {
        intDiamond = 0;
        currentSkin = 0;
        highPoint = 0;
        level = 1;
        listSkins = new bool[Constant.countSkin];

        for (int i = 0; i < 1; i++)
        {
            listSkins[i] = true;
        }

        Save();
    }

    public void CheckPoint(int point)
    {
        if (point > highPoint)
        {
            highPoint = point;
            Save();
        }
    }

    public bool CheckLock(int id)
    {
        return this.listSkins[id];
    }

    public void Unlock(int id)
    {
        if (!listSkins[id])
        {
            listSkins[id] = true;
        }

        Save();
    }

    public void UnlockBG(int id)
    {
        Save();
    }

    public void AddDiamond(int a)
    {
        intDiamond += a;

        onChangeDiamond?.Invoke(intDiamond);

        Save();
    }
    
    public void AddPoint(int a)
    {
        point += a;

        onChangePoint?.Invoke(point);

        Save();
    }

    public bool CheckCanUnlock()
    {
        return intDiamond >= Constant.priceUnlockSkin;
    }

    public bool CheckCanUnlockBG()
    {
        return true;
    }

    public void SubDiamond(int a)
    {
        intDiamond -= a;

        if (intDiamond < 0)
        {
            intDiamond = 0;
        }

        onChangeDiamond?.Invoke(intDiamond);

        Save();
    }

    public void ChooseBG(int i)
    {
        Save();
    }
}