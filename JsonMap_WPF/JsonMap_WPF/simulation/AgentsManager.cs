﻿using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class AgentsManager
    {
        public Dictionary<string, CharacterAgent> Agents { get; private set; }
        public int Count => Agents.Count;

        public AgentsManager()
        {
            Agents = new Dictionary<string, CharacterAgent>();
        }

        public bool Setup(Episode pepisode)
        {
            // Create an agent for each characters for given episode
            foreach(Character character in pepisode.Characters)
            {
                CharacterAgent ca = new CharacterAgent(character);
                Agents.Add(character.Name, ca);
            }

            return true;
        }
    }
}
