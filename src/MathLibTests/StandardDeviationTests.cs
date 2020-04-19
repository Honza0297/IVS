/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: StandardDeviationTests.cs
 * Date: 11.3.2020
 * Authors: Daniel Bubeníček (xbuben05@stud.fit.vutbr.cz)
 *      
 * Description: Tests for stddev app
 *
 *******************************************************************/
/**
 * @file StandardDeviationTests.cs
 *
 * @brief Tests for stddev app
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
     * @class StandardDeviationTests
     *
     * @brief Tests for stddev app
     */
    public class StandardDeviationTests
    {
        /**
         * @brief Tests CalculateStandardDeviation method 
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
