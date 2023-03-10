using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(InputField))]

public class PlayerName : MonoBehaviour
{
    #region Private Constants

    const string playerNamePrefKey = "PlayerName";

    #endregion

    #region MonoBehaviour CallBacks

    void Start()
    {
        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }
        PhotonNetwork.NickName = defaultName;
    }

    #endregion

    #region Public Methods
    public void SetInputFieldName(string value)
    {

        PhotonNetwork.NickName = value;
        //PhotonNetwork.LocalPlayer.NickName = value;

        //Salva o nome do Player para futuras sesões.
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

    #endregion
}
