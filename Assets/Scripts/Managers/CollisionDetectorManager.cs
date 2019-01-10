using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionDetectorManager : MonoBehaviour
{
	private DamageableEntity hero;
	private HashSet<Bullet> allBullets = new HashSet<Bullet>();
	private HashSet<DamageableEntity> allDamageableEntities = new HashSet<DamageableEntity>();
	private HashSet<Tuple<ICanCollide, float>> entitiesThatCollide = new HashSet<Tuple<ICanCollide, float>>();
    private IEnumerable<ICanCollide> bulletsThatCollide;

	private void Awake()
	{
		hero = FindObjectOfType<Hero>().GetComponent<DamageableEntity>();
	}

	private void Start()
	{
		bulletsThatCollide = allBullets.Where(bullet =>
		{
			return allDamageableEntities.Any(entity =>
			{
				var totalRadius = entity.RadiusSize * entity.RadiusSize + bullet.RadiusSize * bullet.RadiusSize;
				var deltaVector = bullet.transform.position - entity.transform.position;

				var isColliding = entity.Afiliation != bullet.Afiliation && deltaVector.sqrMagnitude < totalRadius;

				if (isColliding)
				{
					Tuple<ICanCollide, float> tuple = new Tuple<ICanCollide, float>(entity, bullet.Damage);
					entitiesThatCollide.Add(tuple);
				}

				return isColliding;
			});
		});
	}

	private void Update()
	{
		CheckCollisions();
	}

	public void AddBullet(Bullet bullet)
	{
		allBullets.Add(bullet);
	}
	
	public void AddDamageableEntity(DamageableEntity damageableEntity)
	{
		allDamageableEntities.Add(damageableEntity);
	}
	
	public void RemoveBullet(Bullet bullet)
	{
		allBullets.Remove(bullet);
	}
	
	public void RemoveDamageableEntity(DamageableEntity damageableEntity)
	{
		allDamageableEntities.Remove(damageableEntity);
	}

	private void CheckCollisions()
	{
		foreach (var bullet in bulletsThatCollide.ToList())
		{
			bullet.GotDamaged();
		}
		
		foreach (var entities in entitiesThatCollide)
		{
			entities.Item1.GotDamaged(entities.Item2);
		}

		var heroIsColliding = allDamageableEntities.Any(enemy =>
		{
			var totalRadius = enemy.RadiusSize * enemy.RadiusSize + hero.RadiusSize * hero.RadiusSize;
			var deltaVector = enemy.transform.position - hero.transform.position;

			return deltaVector.sqrMagnitude < totalRadius;
		});

		if (heroIsColliding)
		{
			hero.GotDamaged();
		}

		entitiesThatCollide.Clear();
    }
}
