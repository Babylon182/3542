using ObjectsPool;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PoolInstaller", menuName = "Installers/PoolInstaller")]
public class PoolInstaller : ScriptableObjectInstaller<PoolInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IPool>().To<GodPoolWithZenject>().AsSingle();
    }
}