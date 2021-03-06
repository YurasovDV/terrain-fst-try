﻿using System;
using Common.Geometry;
using OcTreeLibrary;

namespace SimpleShooter.Core
{
    class OctreeGameObject : IOctreeItem
    {

        public OctreeGameObject()
        {

        }

        public BoundingVolume BoundingBox { get; set; }

        public BoundingVolume TreeSegment { get; set; }

        public bool ReInsertImmediately { get; set; }

        public event EventHandler<ReinsertingEventArgs> NeedsRemoval;
        public event EventHandler<ReinsertingEventArgs> NeedsInsert;


        public void RaiseRemove()
        {
            if (NeedsRemoval != null)
            {
                NeedsRemoval(this, new ReinsertingEventArgs());
            }
        }

        public void RaiseInsert()
        {
            NeedsInsert?.Invoke(this, new ReinsertingEventArgs());
        }
    }
}
