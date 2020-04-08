using UnityEngine;
using Newtonsoft.Json;
using Scripts.Json;

public class Cubes : MonoBehaviour
{
    public CubeStructure cubeStruct;

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
        cubeStruct = JsonConvert.DeserializeObject<CubeStructure>(json.text);

        // time to load the cube....
        /*
         * foreach slice in in cubedef
         * foreach empty in slice.empty
            get the empty
            get the cube 
            set the parent of the cube to the empty...
        */
        foreach(CubeStructure.CubeDefinition.Slice slice in cubeStruct.cubedef.slices)
        {
            foreach (CubeStructure.CubeDefinition.Slice.Position position in slice.positions)
            {
                string emptyName = position.Name;
                string cubeName = position.CubeAtPosition;
                GameObject emptyParent = GameObject.Find(emptyName);
                GameObject cube2Parent = GameObject.Find(cubeName);

                if (null != emptyParent && null != cube2Parent)
                {
                    cube2Parent.transform.SetParent(emptyParent.transform,true);
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
