using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTMP : MonoBehaviour
{
   public TextMeshProUGUI TextMeshProUgui;

   void Start()
   {
      TextMeshProUgui = GetComponent<TextMeshProUGUI>();
      TextMeshProUgui.SetText($"Level {GameDataManager.Instance.playerData.level}");
   }
}
