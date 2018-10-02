using UnityEngine;

namespace Bullets
{
    public class BulletNormal : Bullet
    {
        public override void Movement()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        public override void Damage()
        {

        }
    }
}