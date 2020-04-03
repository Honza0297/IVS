/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: MainViewModel.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Main viewmodel
 *
 *******************************************************************/

using System;
using System.Windows;
using System.Windows.Input;
using IVSCalc.Commands;
using MathLibrary;

namespace IVSCalc.ViewModels
{
    /*
     * @class MainViewModel
     *
     * @brief Default ViewModel. All UI components are biding to properties of this ViewModel.
     */

    class MainViewModel : ViewModelBase
    {
        private string _input;

        private string _calculation;

        private string _op;

        private Visibility _errorVisibility;

        private string _errorText;

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
        public ICommand NumberPressCommand { get; set; }
        public ICommand ClearPressCommand { get; set; }
        public ICommand RemovePressCommand { get; set; }
        public ICommand OperatorPressCommand { get; set; }
        public ICommand SolvePressCommand { get; set; }

        /*
         * @brief Constructor for MainViewModel class
         */
        public MainViewModel()
        {
            ErrorVisibility = Visibility.Hidden;
            NumberPressCommand = new RelayCommand<string>((number) => NumberPressed(number));
            ClearPressCommand = new RelayCommand(ClearPressed);
            RemovePressCommand = new RelayCommand(RemovePressed);
            SolvePressCommand = new RelayCommand(SolvePressed);
            OperatorPressCommand = new RelayCommand<string>((op) => OperatorPressed(op));
        }

        /*
         * @brief Command invoked by pressing operator. Store operator. 
         * Error on second operator in one line
         *
         * @param op operator
         */
        private void OperatorPressed(string op)
        {
            if (!String.IsNullOrEmpty(_op)) // Second operator in line
            {
                ErrorText = "Only one operator in line is supported";
                ErrorVisibility = Visibility.Visible;
                return;
            }
            Input += op;
            _op = op;
        }

        /*
         * @brief Command invoked by pressing solve.
         * Handle solving math problem.
         */
        private void SolvePressed()
        {
            bool error = false;
            if ((_op == null) || (_op.Length == 0))
            {
                Calculation = _input;
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
                    catch (MathLibException e)
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
                    catch (MathLibException e)
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
                    try
                    {
                        op1 = new Operand(parsed[0]);
                        op2 = new Operand(parsed[1]);
                    }
                    catch (MathLibException e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                        return;
                    }
                    switch (_op[0])
                    {
                        case '+':
                            result = MathLib.Add(op1, op2);
                            break;
                        case '-':
                            result = MathLib.Subtract(op1, op2);
                            break;
                        case '*':
                            result = MathLib.Multiply(op1, op2);
                            break;
                        case '/':
                            try
                            {
                                result = MathLib.Divide(op1, op2);
                            }
                            catch (MathLibException e)
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
                            catch (MathLibException e)
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
                            catch (MathLibException e)
                            {
                                ErrorText = e.Message;
                                ErrorVisibility = Visibility.Visible;
                                error = true;
                            }
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
                    catch (MathLibException e)
                    {
                        ErrorText = e.Message;
                        ErrorVisibility = Visibility.Visible;
                        error = true;
                    }
                }
                else if (parsed[0] == "" && _input.EndsWith(_op))
                {
                    result = MathLib.Random();
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
                Calculation = _input;
                Input = result.ToString();
                _op = "";
            }
        }

        /*
         * @brief Command invoked by pressing backspace button.
         * Removing last character from input.
         */
        private void RemovePressed()
        {
            if (_input.Length > 0)
            {
                if (_input.EndsWith(_op))
                {
                    Input = _input.Remove(_input.Length - _op.Length);
                    _op = "";
                }
                else
                {
                    Input = _input.Remove(_input.Length - 1);
                }
            }
            if (_errorVisibility == Visibility.Visible)
            {
                ErrorVisibility = Visibility.Hidden;
            }
        }

        /*
         * @brief Command invoked by pressing clear button.
         * Claers both lines in UI.
         */
        private void ClearPressed()
        {
            Input = "";
            Calculation = "";
            _op = "";
            if (_errorVisibility == Visibility.Visible)
            {
                ErrorVisibility = Visibility.Hidden;
            }
        }

        /*
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
