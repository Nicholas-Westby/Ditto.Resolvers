﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ditto.Resolvers.Sample.Models.Archetypes.Abstract
{
    public interface IMulti
    {
        string Alias { get; set; }

        bool Disabled { get; set; }
    }
}