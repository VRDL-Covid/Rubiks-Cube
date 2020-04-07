using UnityEngine;
using Newtonsoft.Json;
using Scripts.Json;

public class Cubes : MonoBehaviour
{
    public CubeStructure cubedef;

    public enum CubeState
    {
        UNITIALIALISED,
        INITIALISED,
        RUNNING,
        RUN_FAILED,
        RUN_OK,
        PAUSED,
        RESUMED
    }

    public CubeState cubeStatus;

    public string cubeDefJson;
    // Start is called before the first frame update
    void Start()
    {
        // load json into structure...
        string path = string.Format("json/{0}", cubeDefJson);
        TextAsset json = Resources.Load<TextAsset>(path);
        cubedef = JsonConvert.DeserializeObject<CubeStructure>(json.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
