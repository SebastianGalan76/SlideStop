using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int stage, level;

    [SerializeField] private MovementSystem movementSystem;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private CameraController cameraController;

    [Header("User Interface")]
    [SerializeField] private UIGame gameUI;
    [SerializeField] private UILevelComplete levelCompleteUI;
    [SerializeField] private UILevelFailed levelFailedUI;

    private void Start() {
        /*stage = PlayerPrefs.GetInt("Stage");
        level = PlayerPrefs.GetInt("Level");*/

        StartLevel(stage, level);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            StartNextLevel();
        }
    }

    public void FinishLevel() {
        movementSystem.enabled = false;
        UserData.FinishLevel(stage, level);

        levelCompleteUI.ShowPanel(level);
    }

    public void LostLevel() {
        movementSystem.enabled = false;
        levelFailedUI.ShowPanel();
    }

    public void PauseLevel() {
        movementSystem.enabled = false;

        Time.timeScale = 0;
    }

    public void ResumeLevel() {
        movementSystem.enabled = true;

        Time.timeScale = 1;
    }

    public void RestartLevel() {
        StartLevel(stage, level);
    }

    public void StartNextLevel() {
        level++;
        if(level > 100) {
            stage++;
            level = 1;
        }

        StartLevel(stage, level);
    }

    private void StartLevel(int stage, int level) {
        platformManager.LoadLevel(stage, level);
        cameraController.LoadCamera(stage, level);

        movementSystem.enabled = true;
        gameUI.ChangeLevel(level);

        Time.timeScale = 1;

        PlayerPrefs.SetInt("LastPlayedStage", stage);
        PlayerPrefs.SetInt("LastPlayedLevel", level);
        PlayerPrefs.Save();
    }
}
