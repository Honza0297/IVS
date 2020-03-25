/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: ViewModelLocator.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Helper for locating viewmodels
 *
 *******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVSCalc.ViewModels
{
    /*
     * @class ViewModelLocator
     *
     * @brief Helper for locating viewmodels
     */

    class ViewModelLocator
    {
        public MainViewModel MainViewModel => new MainViewModel();

        public ViewModelLocator()
        {

        }
    }
}
