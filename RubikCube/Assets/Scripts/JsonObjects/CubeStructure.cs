using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Scripts.Json
{

    [System.Serializable]
    public class CubeStructure
    {
        public CubeDefinition cubedef;

        [System.Serializable]
        public class CubeDefinition
        {
            public Slice[] slices;
            public Cube[] cubes;

            public class Slice
            {
                public string Name;
                public Position[] positions;

                [System.Serializable]
                public class Position
                {
                    public int Index;
                    public bool Occupied;
                    public string CubeAtPosition;
                }
            }

            [System.Serializable]
            public class Cube
            {
                public string Name;
            }
        }
    }
}