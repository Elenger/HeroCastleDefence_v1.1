using Photon.Pun;
using UnityEngine;

public class CharacterSelect : MonoBehaviourPunCallbacks
{
    public void ChangeSelectedCharacter(GameObject character)
    {
        SelectedCharacter.Prefab = character;
    }
}
