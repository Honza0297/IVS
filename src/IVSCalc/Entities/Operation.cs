/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: Operation.cs
 * Date: 14.3.2020
 * Author: Jan Beran (xberan43@stud.fit.vutbr.cz)
 *
 * Description: enum type to determine operation
 *
 *******************************************************************/

namespace IVSCalc.Entities
{
    public enum Operation
    {
        Add = 0,
        Sub = 1,
        Mul = 2,
        Div = 3,

        Root = 4,
        Fact = 5,
        Ran = 6
    }
}