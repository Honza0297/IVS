/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: IMediator.cs
 * Date: 7.4.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Interface for mediator
 *
 *******************************************************************/

/**
* @file IMediator.cs
*
* @brief Interface for mediator
* @author Peter Dragun (xdragu01)
*/


using System;
using IVSCalc.Messages;

namespace IVSCalc.Services
{
    interface IMediator
    {
        void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;
        void Send<TMessage>(TMessage message)
            where TMessage : IMessage;
        void UnRegister<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;

    }
}
