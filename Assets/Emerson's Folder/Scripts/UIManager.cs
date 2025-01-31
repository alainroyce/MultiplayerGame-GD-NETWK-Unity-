using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // singleton instance
    public static UIManager instance;
    // panel UI object
    public GameObject startMenu;
    // panel inGame object
    public GameObject inGamePanel;
    // panel playersInfo
    public GameObject playersInfoPanel;
    // panel playerInfo prefab
    public GameObject playerInfoPanelPrefab;
    // input field UI object
    public InputField usernameField;
    // Timer UI object
    public Text timerText;
    // playerInfoPanel list
    [HideInInspector] public List<GameObject> playerInfoList = new List<GameObject>();
    // singleton process    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogError($"Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        // play menuSound bgm
        AudioManager.Instance.Play(SoundCode.MAIN_MENU);
    }

    // will be called when the player clicks the 'connect' button
    public void ConnectToServer()
    {
        if (string.IsNullOrEmpty(usernameField.text))
        {
            Debug.LogError($"NO TEXT!");
            return;
        }
        startMenu.SetActive(false);
        usernameField.interactable = false;
        inGamePanel.SetActive(true);
        // transition bgm to battle bgm
        AudioManager.Instance.Stop(SoundCode.MAIN_MENU);
        AudioManager.Instance.Play(SoundCode.INGAME_SOUND);
        // the client will now connect to the server
        Client.instance.ConnectToServer();
    }

}
