public interface ICanCollide
{
    void GotDamaged(float damage = 0);
    float RadiusSize { get; }
    EntityType Afiliation { get; }
}
