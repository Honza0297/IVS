/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: UnitTests.cs
 * Date: 11.3.2020
 * Authors: Daniel Bubeníček (xbuben05@stud.fit.vutbr.cz), Jan Beran (xberan43@stud.fit.vutbr.cz)
 *      
 * Description: Unit tests for MathLib
 *
 *******************************************************************/
/**
 * @file UnitTests.cs
 *
 * @brief Unit tests for MathLib
 * @author Daniel Bubeníček (xbuben05)
 */


using System;
using System.Collections.Generic;
using MathLibrary;
using stddev;
using Xunit;

namespace MathLibTests
{
    /**
     * @class MathLibTests
     *
     * @brief Tests for MathLib
     */
    public class StandardDeviationTests
    {
       
        /**
         * @brief Tests the Add() method of MathLib
         */
        [Fact]
        public void StandardDeviationTest()
        {
            var numbers = new List<int> {5, 3};
            var result = StandardDeviation.CalculateStandardDeviation(numbers);
            Assert.Equal(MathLib.Root(new Operand(2), new Operand(2)), result);
        }

       
    }
}
