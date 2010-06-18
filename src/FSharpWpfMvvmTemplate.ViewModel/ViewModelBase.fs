namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Windows
open System.Windows.Input
open System.ComponentModel

type ViewModelBase() =
    let requestCloseEvent = new DelegateEvent<EventHandler>()
    let mutable _closeCommand : ICommand = null
    [<CLIEvent>]
    member x.RequestClose = requestCloseEvent.Publish
    member x.OnRequestClose () = requestCloseEvent.Trigger([| x; System.EventArgs.Empty |])
    member x.CloseModalCommand 
        with get() = 
            if _closeCommand = null then
                _closeCommand <- new RelayCommand ((fun canExecute -> true), (fun action -> x.OnRequestClose())) 
            _closeCommand
        
