/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: ViewModelBase.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Base class for viewmodels with event OnPropertyChanded
 *
 *******************************************************************/

/**
* @file ViewModelBase.cs
*
* @brief Base class for viewmodels with event OnPropertyChanded
* @author Peter Dragun (xdragu01)
*/

using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace IVSCalc.ViewModels
{
    /*
     * @class ViewModel
     *
     * @brief Base class for viewmodels with event OnPropertyChanded
     */
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
