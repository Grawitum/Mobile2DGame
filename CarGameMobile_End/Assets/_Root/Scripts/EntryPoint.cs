using Profile;
using UnityEngine;
using Game.Transport;

internal class EntryPoint : MonoBehaviour
{
    private const GameState InitialState = GameState.Start;

    [SerializeField] private TransportConfig _transportConfig;
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;
    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_transportConfig,InitialState);
        _mainController = new MainController(_placeForUi,profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
