﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace JsonMap.Simulation
{
    public static class Workers
    {
        /** Time between each line processing, Simulation time step isn't influenced */
        public static float ProcessingTimeStep { get; set; } = 2f;
        /** Time between each physics recalculation of forces apply  to rigid body, Processing time step isn't influenced */
        public static float SimulationTimeStep { get; set; } = 1f / 60f;

        /**
         * Method that runs in simulation Thread.
         * Runs multiagents system to calculate physical behaviors
         * based on interactions extract from episode's script.
         */
        public static void SimulationWorker()
        {
            float elapsedTimeProcessing = 0f;
            float elapsedTimeSimulation = 0f;
            Data.Action currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
            SimulationManager.CurrentActionIndex++;

            Console.WriteLine("Simulation thread start");

            TimeManager.Instance.Update();

            while(SimulationManager.SimulationShouldRun)
            {
                /** Check if simulation is in pause state */
                if(SimulationManager.SimulationShouldPause)
                {
                    Console.WriteLine("Simulation pause");
                    SimulationManager.PauseEvent.WaitOne();
                    Console.WriteLine("Simulation unpause");
                }

                /** Process simulation for next line */
                if(elapsedTimeProcessing >= ProcessingTimeStep)
                {
                    elapsedTimeProcessing = 0f;

                    /** Set next action as current action */
                    currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
                    SimulationManager.CurrentActionIndex++;

                    /** Update relations */
                    ProcessRelations();
                }

                /** Process physic simulation for current line */
                if(elapsedTimeSimulation >= SimulationTimeStep)
                {
                    SimulationManager.ComSyncEvent.WaitOne();

                    if(SimulationManager.SimulationShouldRun)
                    {
                        /** Do physics calculations */
                        SimulationManager.environment.UpdateAgents();

                        SimulationManager.SimSyncEvent.Set();
                        SimulationManager.ComSyncEvent.Reset();
                        elapsedTimeSimulation = 0f;
                    }
                }

                /** Update elapsed times */
                float elapsedTime = TimeManager.Instance.DeltaTime;
                elapsedTimeProcessing += elapsedTime;
                elapsedTimeSimulation += elapsedTime;
                TimeManager.Instance.Update();
            }

            SimulationManager.SimSyncEvent.Set();

            Console.WriteLine("Simulation thread stop");
        }

        /**
         * Method that runs in communication Thread.
         * Send calculated data to render application through Socket.
         */
        public static void CommunicationWorker()
        {
            Console.WriteLine("Communication thread start");
            float totalElapsedTime = 0;

            while (SimulationManager.SimulationShouldRun)
            {
                if(totalElapsedTime >= SimulationTimeStep)
                {
                    SimulationManager.SimSyncEvent.WaitOne();

                    if(SimulationManager.SimulationShouldRun)
                    {
                        /** Send stuff through socket */
                        Console.WriteLine("Communication send data...");

                        NetworkStream stream = SimulationManager.ComSocket.GetStream();
                        byte[] toSend = System.Text.Encoding.ASCII.GetBytes(
                            Messages.CreateCharacterAgentMessage(SimulationManager.environment.GetCharacterAgentsData())
                        );
                        stream.Write(toSend, 0, toSend.Length);

                        SimulationManager.ComSyncEvent.Set();
                        SimulationManager.SimSyncEvent.Reset();
                        totalElapsedTime = 0;
                    }
                }

                /** Manage time */
                totalElapsedTime += TimeManager.Instance.DeltaTime;
            }
            
            Console.WriteLine("Communication thread stop");
        }

        /**
         * =================================================================================
         *      PROCESS FUNCTIONS
         * =================================================================================
         */

        /**
         * Process Relations based on current action.
         */
        public static void ProcessRelations()
        {
            // Get current action
            Data.Action currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
            Environment env = SimulationManager.environment;

            // Foreach active agent
            for(int i = 0; i < currentAction.CharactersId.Count; ++i)
            {
                // Get id of the current agent
                int currentAgentId = env.Agents.Find(delegate (Agent.CharacterAgent a) {
                    return a.CharacterData.Id == currentAction.CharactersId[i];
                }).CharacterData.Id;

                // Process active agents
                for(int acti = i + 1; acti < currentAction.CharactersId.Count - 1; ++ acti)
                {
                    // Get id for the processed agent
                    int processedAgentId = env.Agents.Find(delegate (Agent.CharacterAgent a) {
                        return a.CharacterData.Id == currentAction.CharactersId[acti];
                    }).CharacterData.Id;

                    // Get or create the relation
                    Relation relation = env.GetOrCreateRelation(env.Agents[currentAgentId], env.Agents[processedAgentId]);

                    // Apply action influence on it
                    relation.ApplyAction(currentAction);
                }

                // Process passive agents
                for(int pasi = 0; pasi < currentAction.TargetsId.Count; ++pasi)
                {
                    // Get id for the processed agent
                    int processedAgentId = env.Agents.Find(delegate (Agent.CharacterAgent a) {
                        return a.CharacterData.Id == currentAction.CharactersId[pasi];
                    }).CharacterData.Id;

                    // Get or create the relation
                    Relation relation = env.GetOrCreateRelation(env.Agents[currentAgentId], env.Agents[processedAgentId]);

                    // Apply action on influence on it
                    relation.ApplyAction(currentAction);
                }
            }
        }
    }
}
