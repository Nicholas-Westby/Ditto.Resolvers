﻿using System;

namespace Our.Umbraco.Ditto.Resolvers.Archetype.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ArchetypeContentAttribute : Attribute
    {
        public ArchetypeContentAttribute(string alias = null) 
        {
            Alias = alias;
        }

        public string Alias { get; private set; }
    }
}
