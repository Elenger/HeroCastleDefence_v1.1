using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAimCharacter : MonoBehaviour
{
    public void CharacterAim(CharacterAutoAim characterAutoAim)
    {
        characterAutoAim.AimCharacterToTarget(transform);
    }
}
