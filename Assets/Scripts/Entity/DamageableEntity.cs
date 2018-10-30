using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    [SerializeField] private FloatReference life;

    public float GotHit
    {
        set
        {
            life.Value -= value;
            if (life.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}