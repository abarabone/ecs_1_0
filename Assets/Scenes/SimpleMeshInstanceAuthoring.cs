using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SimpleMeshInstanceAuthoring : MonoBehaviour
{

    public SimpleMeshModelAuthoring Model;



    public class Baker : Baker<SimpleMeshInstanceAuthoring>
    {
        public override void Bake(SimpleMeshInstanceAuthoring authoring)
        {



        }
    }
}
