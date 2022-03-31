using UnityEngine;

public static class GameObjectWithOwenerID {
    public static int _ownerGameObjectId;
 
 
    public static int GetOwnerGameObjectId(this GameObject go)
    {
        return _ownerGameObjectId;
    }
}   