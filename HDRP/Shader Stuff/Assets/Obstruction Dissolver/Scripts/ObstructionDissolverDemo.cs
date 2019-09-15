using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class ObstructionDissolverDemo : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform = null;
        [SerializeField] private Material[] materials = null;

        private static readonly int PlayerWorldPosition = Shader.PropertyToID("PlayerWorldPosition");

        private void Update()
        {
            foreach (Material material in materials)
            {
                material.SetVector(PlayerWorldPosition, targetTransform.position);
            }
        }
    }
}
