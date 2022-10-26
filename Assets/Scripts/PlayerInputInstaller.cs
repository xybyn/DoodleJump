using UnityEngine;
using Zenject;

public class PlayerInputInstaller : MonoInstaller
{
    [SerializeField] private TouchInput _input = null;
    [SerializeField] private PlayerInputController _playerInputController = null;
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<TouchInput>().FromComponentInNewPrefab(_input).AsSingle();
        Container.Bind<PlayerInputController>().FromInstance(_playerInputController).AsSingle();
    }
}