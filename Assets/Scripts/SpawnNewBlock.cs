// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;

    private GameHandler _gameHandler;
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        _gameHandler = FindObjectOfType<GameHandler>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }


    public void SpawnBlock()
    {
        var obj = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
        var cc = obj.GetComponent<ColorChanger>();
        if (cc == null) return;

        cc.ChangeColor(null);
        _gameHandler.UpdatePlayerBlocksAndActivate();
        _scoreManager.BlockSpawned();
    }
}