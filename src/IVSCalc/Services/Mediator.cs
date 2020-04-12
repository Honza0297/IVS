/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: Mediator.cs
 * Date: 7.4.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Helper for sending messages between ViewModels
 *
 *******************************************************************/

/**
* @file Mediator.cs
*
* @brief Helper for sending messages between ViewModels
* @author Peter Dragun (xdragu01)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using IVSCalc.Messages;

namespace IVSCalc.Services
{
    /**
     * @class Mediator
     *
     * @brief Implementing methods for sending messages
     */

    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, List<Delegate>> registeredActions = new Dictionary<Type, List<Delegate>>();

        /**
         * @brief Register (accept) message
         * 
         * @param action message to be registered
         */

        public void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);
            if (!registeredActions.TryGetValue(key, out _))
            {
                registeredActions[key] = new List<Delegate>();
            }
            registeredActions[key].Add(action);
        }

        /**
         * @brief Unregister message
         * 
         * @param action message to be unregistered
         */

        public void UnRegister<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            var key = typeof(TMessage);

            if (registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                var actionsList = actions.ToList();
                actionsList.Remove(action);
                registeredActions[key] = new List<Delegate>(actionsList);
            }
        }

        /**
         * @brief Send message
         * 
         * @param action message to send
         */

        public void Send<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            if (registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                foreach (var action in actions.Select(action => action as Action<TMessage>).Where(action => action != null))
                {
                    action(message);
                }
            }
        }
    }
}
