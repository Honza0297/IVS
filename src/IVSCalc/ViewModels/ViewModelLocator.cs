/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: ViewModelLocator.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Helper for locating viewmodels
 *
 *******************************************************************/

/**
* @file ViewModelLocator.cs
*
* @brief Helper for locating viewmodels
* @author Peter Dragun (xdragu01)
*/

using IVSCalc.Services;

namespace IVSCalc.ViewModels
{
    /**
     * @class ViewModelLocator
     *
     * @brief Helper for locating viewmodels
     */

    class ViewModelLocator
    {
        private readonly IMediator mediator;
        public MainViewModel MainViewModel => new MainViewModel(mediator);

        public ViewModelLocator()
        {
            mediator = new Mediator();
        }
    }
}
