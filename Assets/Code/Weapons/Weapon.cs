using UnityEngine;


[CreateAssetMenu( fileName = "New weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string name;
    public int damage;
    public float range;
    public float attackSpeed;
}
