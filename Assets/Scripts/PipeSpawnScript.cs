using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public double spawnRate = 2.6;
    private float _timer;
    public float heightOffset = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }
    
    void SpawnPipe()
    {
        var position = transform.position;
        var lowestPoint = position.y - heightOffset;
        var highestPoint = position.y + heightOffset;
        
        Instantiate(pipe, new Vector3(position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        spawnRate -= 0.02;
    }
}