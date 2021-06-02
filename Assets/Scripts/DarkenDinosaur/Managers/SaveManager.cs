using System.IO;
using DarkenDinosaur.Data;
using UnityEngine;
using UnityEngine.Events;

namespace DarkenDinosaur.Managers
{
    public class SaveManager : MonoBehaviour
    {
        [Header("Game data")] 
        [Tooltip("Game data structure.")]
        [SerializeField] private GameData gameData;

        [Header("Settings")] 
        [Tooltip("Save file name.")]
        [SerializeField] private string saveFileName;
        
        [Tooltip("Save directory name.")]
        [SerializeField] private string saveDirectoryName;
        
        [Tooltip("Path to save directory.")]
        [SerializeField] private string saveDirectoryPath;
        
        [Tooltip("Path to save file.")]
        [SerializeField] private string saveFilePath;

        [SerializeField] private UnityEvent<GameData> dataLoaded;
        [SerializeField] private UnityEvent<GameData> dataSaved;
        
        /// <summary>
        /// Restart level event handler.
        /// </summary>
        public void OnRestartLevel()
        {
            string json = JsonUtility.ToJson(this.gameData);
            File.WriteAllText(this.saveFilePath, json);
            Debug.Log("{<color=blue><b>Save Manager Log</b></color>} => [SaveManager] - (<color=yellow>OnApplicationQuit</color>) -> Data saved to file.");
            this.dataSaved?.Invoke(this.gameData);
        }
        
        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            this.saveDirectoryPath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName);
            this.saveFilePath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName, this.saveFileName);
#endif

#if UNITY_STANDALONE || UNITY_EDITOR
            this.saveDirectoryPath = Path.Combine(Application.dataPath, this.saveDirectoryName);
            this.saveFilePath = Path.Combine(Application.dataPath, this.saveDirectoryName, this.saveFileName);
#endif

            if (Directory.Exists(this.saveDirectoryPath) == false)
            {
                Debug.Log("{<color=blue><b>Save Manager Log</b></color>} => [SaveManager] - (<color=yellow>Awake</color>) -> Save directory created.");
                Directory.CreateDirectory(this.saveDirectoryPath);
            }

            if (File.Exists(this.saveFilePath))
            {
                string json = File.ReadAllText(this.saveFilePath);
                GameData gameDataFromJson = JsonUtility.FromJson<GameData>(json);
                this.gameData = gameDataFromJson;
                Debug.Log("{<color=blue><b>Save Manager Log</b></color>} => [SaveManager] - (<color=yellow>Awake</color>) -> Data loaded from file.");
                this.dataLoaded?.Invoke(this.gameData);
            }
        }

        /// <summary>
        /// High score changed event handler.
        /// </summary>
        /// <param name="highScore">High score count (int)</param>
        public void OnHighScoreChanged(int highScore) => this.gameData.highScoreCount = highScore;
    }
}