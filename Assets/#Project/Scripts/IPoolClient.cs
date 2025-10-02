using UnityEngine;

public interface IPoolClient
{
    void WakeUp(Vector3 position, Quaternion rotation);
    void Sleep();
}
