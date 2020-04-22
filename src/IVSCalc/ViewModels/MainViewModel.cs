/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: MainViewModel.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Main viewmodel - "backend" of aplication
 *
 *******************************************************************/

/**
* @file MainViewModel.cs
*
* @brief Main viewmodel - "backend" of aplication
* @author Peter Dragun (xdragu01)
*/

using System;
using System.Windows;
using System.Windows.Input;
using IVSCalc.Commands;
using MathLibrary;
using IVSCalc.Services;
using IVSCalc.Messages;
using System.Collections.Generic;
using System.Linq;

namespace IVSCalc.ViewModels
{
    /**
     * @class MainViewModel
     *
     * @brief Default ViewModel. All UI components are biding to properties of this ViewModel.
     */

    class MainViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;

        private string _input;

        private string _calculation;

        private string _op;

        private List<char> _unary;

        private Visibility _errorVisibility;

        private Visibility _basicViewVisibility;
        
        private Visibility _scientificViewVisibility;

        private string _errorText;

        private string _numeralSystem;

        private string _goniometricUnits;

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        public string Calculation
        {
            get => _calculation; set
            {
                _calculation = value;
                OnPropertyChanged();
            }
        }
        public Visibility ErrorVisibility
        {
            get => _errorVisibility; set
            {
                _errorVisibility = value;
                OnPropertyChanged();
            }
        }
        public string ErrorText
        {
            get => _errorText; set
            {
                _errorText = value;
                OnPropertyChanged();
            }
        }
        public Visibility BasicViewVisibility
        {
            get => _basicViewVisibility; set
            {
                _basicViewVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ScientificViewVisibility
        {
            get => _scientificViewVisibility; set
            {
                _scientificViewVisibility = value;
                OnPropertyChanged();
            }
        }
        public string NumeralSystem
        {
            get => _numeralSystem; set
            {
                _numeralSystem = value;
                OnPropertyChanged();
            }
        }
        public string GoniometricUnits
        {
            get => _goniometricUnits; set
            {
                _goniometricUnits = value;
                OnPropertyChanged();
            }
        }
        public ICommand NumberPressCommand { get; set; }
        public ICommand ClearPressCommand { get; set; }
        public ICommand RemovePressCommand { get; set; }
        public ICommand OperatorPressCommand { get; set; }
        public ICommand SolvePressCommand { get; set; }
        public ICommand ChangeViewCommand { get; set; }
        public ICommand ChangeNumeralSystemCommand { get; set; }
        public ICommand ChangeGoniometricUnitsCommand { get; set; }

        /**
         * @brief Constructor for MainViewModel class
         * 
         * @param mediator madiator for sending messages in ViewModels
         */
        public MainViewModel(IMediator mediator)
        {
            NumeralSystem = "dec";
            GoniometricUnits = "deg";
            _unary = new List<char>();
            _mediator = mediator;
            _mediator.Register<ChangeViewMessage>(ChangeViewMessageHandler);
            ErrorVisibility = Visibility.Hidden;
            ScientificViewVisibility = Visibility.Hidden;
            BasicViewVisibility = Visibility.Visible;
            NumberPressCommand = new RelayCommand<string>((number) => NumberPressed(number));
            ClearPressCommand = new RelayCommand(ClearPressed);
            RemovePressCommand = new RelayCommand(RemovePressed);
            SolvePressCommand = new RelayCommand(SolvePressed);
            OperatorPressCommand = new RelayCommand<string>((op) => OperatorPressed(op));
            ChangeViewCommand = new RelayCommand<string>((view) => ChangeView(view));
            ChangeNumeralSystemCommand = new RelayCommand<string>((currentNumeralSystem) => ChangeNumeralSystem(currentNumeralSystem));
            ChangeGoniometricUnitsCommand = new RelayCommand<string>((currentGoniometricUnits) => ChangeGoniometricUnits(currentGoniometricUnits));
        }

        /**
         * @brief Change current goniometric units
         * 
         * @param currentGoniometricUnits string specifying goniometric units
         */
        private void ChangeGoniometricUnits(string currentGoniometricUnits)
        {
            if (currentGoniometricUnits == "deg")
            {
                GoniometricUnits = "rad";
            }
            else if (currentGoniometricUnits == "rad")
            {
                GoniometricUnits = "grad";
            }
            else if (currentGoniometricUnits == "grad")
            {
                GoniometricUnits = "deg";
            }
        }

        /**
         * @brief Change current numeral system
         * 
         * @param currentNumeralSystem string specifying numeral system
         */
        private void ChangeNumeralSystem(string currentNumeralSystem)
        {
            if (currentNumeralSystem == "bin")
            {
                NumeralSystem = "dec";
            }else if (currentNumeralSystem == "dec")
            {
                NumeralSystem = "hex";
            }
            else if (currentNumeralSystem == "hex")
            {
                NumeralSystem = "bin";
            }
        }

        /**
         * @brief Handler for message from scientific view.
         * Changin View from scientific mode to basic
         * 
         * @param obj message
         */
        private void ChangeViewMessageHandler(ChangeViewMessage obj)
        {
            ScientificViewVisibility = Visibility.Hidden;
            BasicViewVisibility = Visibility.Visible;
        }

        /**
         * @brief Changin View from basic mode to scinetific
         * 
         * @param view name of current view
         */
        private void ChangeView(string view)
        {
            if(view == "Scientific")
            {
                BasicViewVisibility = Visibility.Hidden;
                ScientificViewVisibility = Visibility.Visible;
            }
            else
            {
                _mediator.Send(new ChangeViewMessage());
            }
        }

        /**
         * @brief Command invoked by pressing operator. Store operator. 
         * Error on second operator in one line
         *
         * @param op operator
         */
        private void OperatorPressed(string op)
        {
            if (op == "rand")
            {
                Operand result;
                try
                {
                    result = MathLib.Random();
                    Input += result.ToString();
                }
                catch (Exception e)
                {
                    ErrorText = e.Message;
                    ErrorVisibility = Visibility.Visible;
                }
                return;
            }
            if (!String.IsNullOrEmpty(_op)) // Second operator in line
            {
                if((op == "-" || op == "+") && _input.EndsWith(_op) && _unary.Count < 2)
                {
                    if (_unary.Count == 0)
                    {
                        _unary.Add('\0');
                    }
                    _unary.Add(op[0]);
                }
                else
                {
                    ErrorText = "Only one operator in line is supported";
                    ErrorVisibility = Visibility.Visible;
                    return;
                }
            }
            else
            {
                if (((op == "-" || op == "+") && String.IsNullOrEmpty(_input)))
                {
                    _unary.Add(op[0]);
                }
                else
                {
                    _op = op;
                }
            }
            Input += op;
        }

        /**
         * @brief Command invoked by pressing solve.
         * Handle solving math problem.
         */
        private void SolvePressed()
        {
            bool error = false;
            if (String.IsNullOrEmpty(_op))
            {
                Calculation = _input + "=";
                return;
            }
            Operand result = null;
            if (_op.Length == 1)
            {
                string[] parsed = _input.Split(_op[0]);
                if (parsed[1] == "" && _op == "!")
                {
                    try
                    {
                        Operand op = new Operand(parsed[0]);
                        result = MathLib.Factorial(op);
                    }
                    catch (Exception e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                    }
                }
                else if (parsed[0] == "" && _op == "√")
                {
                    try
                    {
                        Operand op = new Operand(parsed[1]); // operand is after operator
                        result = MathLib.Root(op, new Operand(2));
                    }
                    catch (Exception e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                        return;
                    }
                }
                else
                {
                    Operand op1;
                    Operand op2;
                    if (_unary?.Count > 0)
                    {
                        if(_op[0] == _unary[0])
                        {
                            if(_unary.Count > 1 && _op[0] == _unary[1])
                            {
                                parsed[0] = _unary[0] + parsed[1];
                                parsed[1] = _unary[1] + parsed[3];
                            }
                            else
                            {
                                parsed[0] = _unary[0] + parsed[1];
                                parsed[1] = parsed[2];
                            }
                        }else if(_unary.Count > 1 && _op[0] == _unary[1])
                        {
                            parsed[1] = _unary[1] + parsed[2];
                        }
                    }
                    try
                    {
                        op1 = new Operand(parsed[0]);
                        op2 = new Operand(parsed[1]);
                    }
                    catch (Exception e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                        return;
                    }
                    switch (_op[0])
                    {
                        case '+':
                            try
                            {
                                result = MathLib.Add(op1, op2);
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                            break;
                        case '-':
                            try
                            {
                                result = MathLib.Subtract(op1, op2);
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                        break;
                        case '*':
                            try
                            {
                                result = MathLib.Multiply(op1, op2);
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                            break;
                        case '/':
                            try
                            {
                                result = MathLib.Divide(op1, op2);
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                            break;
                        case '^':
                            try
                            {
                                result = MathLib.Power(op1, op2);
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                            break;
                        case '√':
                            try
                            {
                                result = MathLib.Root(op2, op1); // first operand is degree
                            }
                            catch (Exception e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
                            break;
                        default:
                            ErrorText = "Unexpected number in this operation";
                            ErrorVisibility = Visibility.Visible;
                            error = true;
                            break;
                    }
                }
            }
            else if (_op.Length > 1)
            {
                string[] parsed = _input.Split(_op[0]);
                if (parsed[0] != "" && _input.EndsWith(_op))
                {
                    try
                    {
                        Operand op = new Operand(parsed[0]);
                        result = MathLib.Power(op, new Operand(2));
                    }
                    catch (Exception e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                    }
                }
                else
                {
                    ErrorText = "Unexpected number in this operation";
                    ErrorVisibility = Visibility.Visible;
                    error = true;
                }
            }
            if (!error)
            {
                _unary.Clear();
                Calculation = _input + "=";
                if (result.DoubleOperand < 0)
                {
                    _unary.Add('-');
                }
                Input = result.ToString();
                _op = "";
            }
        }

        /**
         * @brief Command invoked by pressing backspace button.
         * Removing last character from input.
         */
        private void RemovePressed()
        {
            if (_input != null && _input.Length > 0)
            {
                if (!String.IsNullOrEmpty(_op) && _input.EndsWith(_op))
                {
                    if(_unary.Count == 2 && _op[0] == _unary[1])
                    {
                        Input = _input.Remove(_input.Length - 1);
                        _unary.RemoveAt(1);
                    }
                    else
                    {
                        Input = _input.Remove(_input.Length - _op.Length);
                        _op = "";
                    }
                }
                else
                {
                    if(_unary.Count > 0)
                    {
                        if(_unary.Count == 2 && _input.Last() == _unary[1])
                        {
                            _unary.RemoveAt(1);
                        }
                        else if(_input.Last() == _unary[0])
                        {
                            _unary.Clear();
                        }
                    }
                    Input = _input.Remove(_input.Length - 1);
                }
            }
            if (_errorVisibility == Visibility.Visible)
            {
                ErrorVisibility = Visibility.Hidden;
            }
        }

        /**
         * @brief Command invoked by pressing clear button.
         * Claers both lines in UI.
         */
        private void ClearPressed()
        {
            Input = "";
            Calculation = "";
            _op = "";
            _unary.Clear();
            if (_errorVisibility == Visibility.Visible)
            {
                ErrorVisibility = Visibility.Hidden;
            }
        }

        /**
         * @brief Command invoked by pressing number.
         * Add number to input.
         */
        public void NumberPressed(string number)
        {
            Input += number;
            if(_errorVisibility == Visibility.Visible)
            {
                ErrorVisibility = Visibility.Hidden;
            }
        }

    }
}
