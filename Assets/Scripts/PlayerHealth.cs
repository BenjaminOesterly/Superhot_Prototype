using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHittable
{
    public void OnHit()
    {
        Debug.Log("Player was hit by a bullet!");
    }
}