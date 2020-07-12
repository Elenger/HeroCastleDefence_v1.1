using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgradeCharacterController : MonoBehaviour
{
    public CharacterStatsInfo characterStatsInfo;

    #region Attack
    public void UpgradeAttackDamage()
    {
        characterStatsInfo.ChangeAttackDamage(1);
    }
    
    public void UpgradeSkillDamage()
    {
        characterStatsInfo.ChangeSkillDamage(1);
    }
    
    #endregion

    #region Deffence_and_Health

    public void UpgradeHealthPoints()
    {
        characterStatsInfo.ChangeHealthPoint(10);
    }

    public void UpgradeDefencePoint()
    {
        characterStatsInfo.ChangeDefencePoint(1);
    }
    #endregion

    #region Speed

    public void UpgradeMoveSpeed()
    {
        characterStatsInfo.ChangeMoveSpeed(1);
    }
    
    public void UpgradeAttackSpeed()
    {
        characterStatsInfo.ChangeAttackSpeed(1);
    }
    
    public void UpgradeSkillCooldownSpeed()
    {
        characterStatsInfo.ChangeSkillCooldownSpeed(1);
    }

    public void UpgradeCastSpeed()
    {
        characterStatsInfo.ChangeCastSpeed(1);
    }
    #endregion
}
