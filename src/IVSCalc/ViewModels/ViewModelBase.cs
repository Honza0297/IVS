/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: ViewModelBase.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Base class for viewmodels with event OnPropertyChanded
 *
 *******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading.Tasks;

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
