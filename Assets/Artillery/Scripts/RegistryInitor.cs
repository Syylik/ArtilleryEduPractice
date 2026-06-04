using UnityEngine;

public class RegistryInitor : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] objects;

    private void Awake()
    {
        foreach(var obj in objects)
        {
            Registry<MonoBehaviour>.TryAdd(obj);
        }

        // foreach(var obj in Registry<MonoBehaviour>.All())
        // Debug.Log(obj.name + " " + obj.GetType());
    }
}
