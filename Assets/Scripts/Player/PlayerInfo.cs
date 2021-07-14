using UnityEngine;

public class PlayerInfo : Info
{
    [SerializeField] private Sprite _playerFlag;

    private string _playerName = "Player";

    private void Start()
    {
        Flag.sprite = _playerFlag;
        Name.text = _playerName;
    }
}
