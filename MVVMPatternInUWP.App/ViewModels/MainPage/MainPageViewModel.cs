using MVVMPatternInUWP.App.Command;
using MVVMPatternInUWP.App.Dialogs;
using MVVMPatternInUWP.Core.Operations.Calculating;
using System;
using System.Windows.Input;

namespace MVVMPatternInUWP.App.ViewModels.MainPage
{
    public class MainPageViewModel : MainPageViewModelBase
    {
        private readonly Calculator _calculator;

        private int _firstValue;
        private int _secondValue;

        private double _result;

        private bool _isAddOperation;
        private bool _isSumOperation;
        private bool _isMulOperation;
        private bool _isDivOperation;
        private bool _isAnyRadioBtnCheck;

        public MainPageViewModel()
        {
            _firstValue = _secondValue = 0;
            _result = 0.0;
            _isAddOperation = _isSumOperation = _isMulOperation = _isDivOperation = _isAnyRadioBtnCheck = false;

            _calculator = new Calculator();
        }

        #region NUMBERS Getters/ Setters

        public int FirstValue
        {
            get => _firstValue;
            set
            {
                _firstValue = value;
                OnPropertyChanged("FirstValue");
            }
        }

        public int SecondValue
        {
            get => _secondValue;
            set
            {
                _secondValue = value;
                OnPropertyChanged("SecondValue");
            }
        }

        public double Result
        {
            get => -_result * - 1;
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        #endregion

        #region RADIO BTNS Getter/ Setters

        public bool IsAnyRadioBtnCheck
        {
            get => _isAnyRadioBtnCheck;
            set
            {
                _isAnyRadioBtnCheck = value;
                OnPropertyChanged("IsAnyRadioBtnCheck");
            }
        }

        public bool IsAddOperation
        {
            get => _isAddOperation;
            set
            {
                _isAddOperation = value;
                IsAnyRadioBtnCheck = true;
                OnPropertyChanged("IsAddOperation");
            }
        }

        public bool IsSumOperation
        {
            get => _isSumOperation;
            set
            {
                _isSumOperation = value;
                IsAnyRadioBtnCheck = true;
                OnPropertyChanged("IsSumOperation");
            }
        }

        public bool IsMulOperation
        {
            get => _isMulOperation;
            set
            {
                _isMulOperation = value;
                IsAnyRadioBtnCheck = true;
                OnPropertyChanged("IsMulOperation");
            }
        }

        public bool IsDivOperation
        {
            get => _isDivOperation;
            set
            {
                _isDivOperation = value;
                IsAnyRadioBtnCheck = true;
                OnPropertyChanged("IsDivOperation");
            }
        }

        #endregion

        #region COMMANDS

        public ICommand CalculateBtnClick =>
            new DelegateCommand(CalculateResult);

        #endregion

        #region PRIVATE COMMAND Helper Methods

        private async void CalculateResult()
        {
            if (_isAddOperation)
            {
                Result = _calculator.Add(_firstValue, _secondValue);
            }
            else if (_isSumOperation)
            {
                Result = _calculator.Sum(_firstValue, _secondValue);
            }
            else if (_isMulOperation)
            {
                Result = _calculator.Mul(_firstValue, _secondValue);
            }
            else if (_isDivOperation)
            {
                try
                {
                    Result = _calculator.Div(_firstValue, _secondValue);
                }
                catch (DivideByZeroException ex)
                {
                    await new NotificationDialog(ex.Message, "ERROR").ShowDialog().ShowAsync();
                }
            }
        }

        #endregion
    }
}
