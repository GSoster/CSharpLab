﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void addLocation(Location locationToAdd)
        {
            _locations.Add(locationToAdd);
        }

        public Location LocationAt(int XCoordinate, int YCoordinate)
        {
            //return _locations.FirstOrDefault<Location>(l => l.XCoordinate == XCoordinate && l.YCoordinate == YCoordinate);
            foreach(Location l in _locations)
            {
                if (l.XCoordinate == XCoordinate && l.YCoordinate == YCoordinate)
                    return l;
            }
            return null;
        }
    }
}
