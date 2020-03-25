/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: MainViewModel.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Main viewmodel
 *
 *******************************************************************/

using IVSCalc.Command;
using IVSCalc.MathLib;
using System;
using System.Windows.Input;

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
                return; // TODO handle error
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
            if ((_op == null) || (_op.Length == 0))
            {
                Calculation = _input;
                return;
            }
            Operand result = null;
            if (_op.Length == 1)
            {
                string[] parsed = _input.Split(_op[0]);
                if (parsed.Length == 0 && _op == "rand")
                {
                    result = MathLib.MathLib.Random();
                }
                else if (parsed.Length == 2)
                {
                    if (parsed[1] == "" && _op == "!")
                    {
                        Operand op = new Operand(parsed[0]);
                        //TODO hadle error in operand creation
                        result = MathLib.MathLib.Factorial(op);
                    }
                    else if (parsed[0] == "" && _op == "√")
                    {
                        Operand op = new Operand(parsed[1]); // operand is after operator
                        //TODO hadle error in operand creation
                        result = MathLib.MathLib.Root(op, new Operand(2));
                    }
                    else
                    {
                        Operand op1 = new Operand(parsed[0]);
                        Operand op2 = new Operand(parsed[1]);
                        //TODO hadle error in operand creation
                        switch (_op[0])
                        {
                            case '+':
                                result = MathLib.MathLib.Add(op1, op2);
                                break;
                            case '-':
                                result = MathLib.MathLib.Subtract(op1, op2);
                                break;
                            case '*':
                                result = MathLib.MathLib.Multiply(op1, op2);
                                break;
                            case '/':
                                try
                                {
                                    result = MathLib.MathLib.Divide(op1, op2);
                                }
                                catch (DivideByZeroException e)
                                {
                                    //TODO hadle error
                                }
                                break;
                            case '^':
                                result = MathLib.MathLib.Power(op1, op2);
                                //TODO hadle error?
                                break;
                            case '√':
                                result = MathLib.MathLib.Root(op2, op1); // first operand is degree
                                //TODO hadle error?
                                break;
                            default:
                                // TODO hadle error
                                throw new NotImplementedException();
                        }
                    }
                }
                else
                {
                    // TODO hadle error
                    throw new NotImplementedException();
                }
            }
            else if (_op.Length > 1)
            {
                string[] parsed = _input.Split(_op[0]);
                if (parsed[0] != "" && parsed[1] == "2" && _op == "^2")
                {
                    Operand op = new Operand(parsed[0]);
                    //TODO hadle error in operand creation
                    result = MathLib.MathLib.Power(op, new Operand(2));
                    //TODO hadle error?
                }
                else
                {
                    // TODO hadle error
                    throw new NotImplementedException();
                }
            }
            Calculation = _input;
            if (result == null)
            {
                Input = ""; // TODO use some box to display error
            }
            else
            {
                Input = result.ToString();
            }
            _op = "";
        }

        /*
         * @brief Command invoked by pressing backspace button.
         * Removing last character from input.
         */
        private void RemovePressed()
        {
            if (_input.Length > 0)
            {
                if (_op.Length == 1 && _input[_input.Length - 1] == _op[0])
                {
                    _op = "";
                    // TODO remove operator from _op if _op.Length > 1
                }
                Input = _input.Remove(_input.Length - 1);
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
        }

        /*
         * @brief Command invoked by pressing number.
         * Add number to input.
         */
        public void NumberPressed(string number)
        {
            Input += number;
        }

    }
}
