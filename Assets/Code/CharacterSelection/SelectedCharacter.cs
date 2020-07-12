using UnityEngine;

public static class SelectedCharacter
{
    private static GameObject prefabSelectedCharacter;

    public static GameObject Prefab
    {
        get
        {
            return prefabSelectedCharacter;
        }
        set
        {
            prefabSelectedCharacter = value;
        }
    }
}
