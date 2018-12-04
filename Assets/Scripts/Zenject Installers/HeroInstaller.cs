using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "HeroInstaller", menuName = "Installers/HeroInstaller")]
public class HeroInstaller : ScriptableObjectInstaller<HeroInstaller>
{
    public Hero hero;
    
    public override void InstallBindings()
    {
        Container.Bind<Hero>().FromComponentInNewPrefab(hero).AsSingle();
    }
}