using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    [SerializeField] private PlayerController _playerPrefab = null;
    [SerializeField] private MazeRenderer _mazeRenderer = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerController player = Instantiate(_playerPrefab, new Vector2(-0.5f, 0.0f), Quaternion.identity) as PlayerController;
        player.Initialize(_mazeRenderer.Maze, _mazeRenderer.CellSize);
    }

}
