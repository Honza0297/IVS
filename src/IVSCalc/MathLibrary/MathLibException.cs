/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: MathLibException.cs
 * Date: 11.3.2020
 * Author: Daniel Bubeníček (xbuben05@stud.fit.vutbr.cz)
 *
 * Description: Own type of an exception for MathLib
 *
 *******************************************************************/
/**
 * @file MathLibException.cs
 *
 * @brief Own type of an exception for MathLib
 * @author Daniel Bubeníček (xbuben05)
 */

using System;

namespace MathLibrary
{
    /**
     * @class MathLibException
     *
     * @brief Own type of an exception for MathLib
     */
    public class MathLibException : Exception
    {
        /**
         * @brief Constructor for MathLibException
         *
         * @return new MathLibException
         */
        public MathLibException()
        {
        }

        /**
         * @brief Constructor for MathLibException
         *
         * @param message Specific description of reasons, why the exception was thrown
         * @return new MathLibException
         */
        public MathLibException(string message) : base(message)
        {
            
        }
    }
}
