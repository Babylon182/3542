using UnityEngine;

namespace Bullets
{
    public class BulletNormal : Bullet
    {
        protected override void Movement()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}