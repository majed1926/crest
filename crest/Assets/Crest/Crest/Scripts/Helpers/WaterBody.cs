﻿// Crest Ocean System

// This file is subject to the MIT License as seen in the root of this folder structure (LICENSE)

using UnityEngine;

namespace Crest
{
    public class WaterBody : MonoBehaviour
    {
        public Bounds AABB { get; private set; }

        private void OnEnable()
        {
            if (OceanRenderer.Instance == null) return;

            CalculateBounds();

            OceanRenderer.Instance.RegisterWaterBody(this);
        }

        private void OnDisable()
        {
            if (OceanRenderer.Instance == null) return;

            OceanRenderer.Instance.UnregisterWaterBody(this);
        }

        private void CalculateBounds()
        {
            var bounds = new Bounds();
            bounds.center = transform.position;
            bounds.Encapsulate(transform.TransformPoint(Vector3.right / 2f + Vector3.forward / 2f));
            bounds.Encapsulate(transform.TransformPoint(Vector3.right / 2f - Vector3.forward / 2f));
            bounds.Encapsulate(transform.TransformPoint(-Vector3.right / 2f + Vector3.forward / 2f));
            bounds.Encapsulate(transform.TransformPoint(-Vector3.right / 2f - Vector3.forward / 2f));

            AABB = bounds;
        }
    }
}
