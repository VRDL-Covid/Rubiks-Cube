using UnityEngine;
using Newtonsoft.Json;
using Scripts.Json;

public class Cubes : MonoBehaviour
{

    public string cubeDefJson;
    // Start is called before the first frame update
    void Start()
    {
        // load json into structure...
        string path = string.Format("json/{0}", cubeDefJson);
        TextAsset json = Resources.Load<TextAsset>(path);
        CubeStructure cubedef = JsonConvert.DeserializeObject<CubeStructure>(json.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
