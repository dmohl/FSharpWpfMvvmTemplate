namespace FSharpWpfMvvmTemplate

open System
open System.Diagnostics
open System.Windows.Input

type RelayCommand(_execute, _canExecute) = 
    new (execute) = RelayCommand(execute, (fun x -> true))
    interface ICommand with
        member x.CanExecute parameter =
            _canExecute parameter
        member this.add_CanExecuteChanged(e) = 
            CommandManager.RequerySuggested.AddHandler(e)
        member this.remove_CanExecuteChanged(e) = 
            CommandManager.RequerySuggested.RemoveHandler(e)
        member x.Execute parameter = 
            _execute parameter   
