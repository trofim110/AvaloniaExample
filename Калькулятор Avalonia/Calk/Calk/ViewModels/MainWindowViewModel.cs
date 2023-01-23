using System;
using System.Reactive;
using Calk.Models;
using ReactiveUI;

namespace Calk.ViewModels
{ 
    public class MainWindowViewModel : ViewModelBase
    {
        private double _secondValuee;
        private double _firstValue;
        private Operation _operation=Operation.Adds;
        
        public double ShowValue
        {
            get => _secondValuee;
            set => this.RaiseAndSetIfChanged(ref _secondValuee, value);
        }
        public ReactiveCommand<int, Unit> Add { get; }
        public ReactiveCommand<Operation,Unit> ExecuteParam { get; }
        public ReactiveCommand<Unit,Unit> Remove { get; }
        
        public MainWindowViewModel()
        {
            Add = ReactiveCommand.Create<int>(AddNumber);
            ExecuteParam = ReactiveCommand.Create<Operation>(Operations);
            Remove = ReactiveCommand.Create(Remov);
        }
        
        public void AddNumber(int value)
        {
            ShowValue = ShowValue * 10 + value;
        }
        public void Operations(Operation operation)
        {
            switch (_operation)
            {
                case Operation.Adds:
                    _firstValue += _secondValuee;
                    ShowValue = 0;
                    break;
                case Operation.Minus:
                    _firstValue -= _secondValuee;
                    ShowValue = 0;
                    break;
                case Operation.Umn:
                    _firstValue *= _secondValuee;
                    ShowValue = 0;
                    break;
                case Operation.Del:
                    _firstValue /= _secondValuee;
                    ShowValue = 0;
                    break;
            }
            if (operation==Operation.res)
            {
                ShowValue = _firstValue;
                _operation = Operation.Adds;
                _firstValue = 0;
            }
            else
            {
                _operation = operation;
            }
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        public void Remov()
        {
            ShowValue= (int)ShowValue / 10;
        }
    }
}
