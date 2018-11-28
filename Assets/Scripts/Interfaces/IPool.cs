using UnityEngine;

public interface IPool
{
    GameObject Instantiate(GameObject poolObjectType, Vector3 initialPosition, Quaternion intialRotation);
    GameObject Instantiate(GameObject poolObjectType);
    void Destroy(GameObject poolObjectType);
}
