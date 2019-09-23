using CalongeCore.Events;

namespace Events
{
    public class HeroDamaged : IGameEvent
    {
        public int currentLife;

        public void Reset()
        {
            currentLife = 0;
        }
    }
}