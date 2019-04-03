//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    public class AugmentedImageVisualizer : MonoBehaviour
    {
        public AugmentedImage image;
        public AugmentedImageVisualizer augmentedImageVisualizer;
        public GameObject level;

        bool hasSpawned = false;
        Anchor anchor;

        public void Update()
        {
            if (image == null || image.TrackingState != TrackingState.Tracking && !hasSpawned)
                return;
                
            if(!hasSpawned){
                AddVisualizer(image);
                hasSpawned = true;
            }
        }

        private void AddVisualizer(AugmentedImage image)
        {
            anchor = Session.CreateAnchor(image.CenterPose);
            GameObject.Instantiate(level, anchor.transform.position, anchor.transform.rotation, anchor.transform);


            //var anchor = image.CreateAnchor(image.CenterPose);
            //var visualizer = Instantiate(augmentedImageVisualizer, anchor.transform);
            //visualizer.image = image;
        }
    }
}