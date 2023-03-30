using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    private int daPoints = 0;
    private SaveManager saveManager;

    void Start() {
        saveManager = FindObjectOfType<SaveManager>();
        daPoints = saveManager.LoadGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            daPoints++;
            print("MORE SCORE!");
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            saveManager.SaveGame(daPoints);
            print("SAVED SCORE!");
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            daPoints = saveManager.LoadGame();
            print($"DA SCORE IS: {daPoints}");
        }
    }
}