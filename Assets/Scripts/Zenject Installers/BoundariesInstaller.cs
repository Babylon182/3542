using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BoundariesInstaller", menuName = "Installers/BoundariesInstaller")]
public class BoundariesInstaller : ScriptableObjectInstaller<BoundariesInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Boundaries>().AsSingle();
    }
}