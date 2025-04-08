using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ironbreaker.Toolkit
{
    [AddComponentMenu("Ironbreaker Toolkit/Initialization Test")]
    public class InitializationTest : MonoBehaviour
    {
        internal const string PackageVersion = "0.1.0";

        void Start()
        {
            Debug.Log("Ironbreaker Toolkit initialized. Version: " + PackageVersion);
        }
    }
}
