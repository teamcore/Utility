﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Aprimo.Utility.Framework.Events
{
    public class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;


        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            foreach (var handler in EngineContext.Current.Resolve<IEnumerable<IHandles<T>>>())
            {
                handler.Handle(args);
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }

            actions.Add(callback);
        }
    }
}