namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Windows.Input
open FSharpWpfMvvmTemplate

type WorkspaceViewModel() =
    let event = new DelegateEvent<System.EventHandler>()
    [<DefaultValue(true)>] val mutable _closeCommand : ICommand
    inherit ViewModelBase
        member x.OnRequestClose () = event.Publish
        member x.CloseCommand 
            with get() = 
                x._closeCommand <- 
                    match x._closeCommand with
                    | null -> 
                        new RelayCommand(fun param -> x.OnRequestClose().AddHandler(event.Publish)) :> ICommand
                    | _ -> x._closeCommand          
