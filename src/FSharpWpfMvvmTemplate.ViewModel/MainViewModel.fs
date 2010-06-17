namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Windows
open System.Windows.Input
open System.ComponentModel

type MainViewModel() =          
    // private variables
    let mutable _title = "Bound Data to Textbox"    

    // public properties
    member x.Title 
        with get() = _title 
        and set(value) = _title <- value

    // public commands
    member x.MyCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ShowMessage)) 

    // public methods
    member public x.ShowMessage = do MessageBox.Show(x.Title) |> ignore

