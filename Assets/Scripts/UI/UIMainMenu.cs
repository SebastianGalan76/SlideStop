using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelListPanel;
    [SerializeField] private TMP_Text starAmountTotal;

    [SerializeField] private TMP_Text[] stageStarAmount;

    private void Awake() {
        starAmountTotal.SetText(UserData.GetTotalStarAmount().ToString());
    }

    public void PlayGame() {
        int stage = PlayerPrefs.GetInt("LastPlayedStage", 1);
        int level = PlayerPrefs.GetInt("LastPlayedLevel", 1);

        PlayerPrefs.SetInt("Stage", stage);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }

    public void ShowLevelList() {
        levelListPanel.SetActive(true);

        stageStarAmount[0].SetText(UserData.GetStarAmountForStage(1).ToString());
    }

    public void HideLevelList() {
        levelListPanel.SetActive(false);
    }
}
