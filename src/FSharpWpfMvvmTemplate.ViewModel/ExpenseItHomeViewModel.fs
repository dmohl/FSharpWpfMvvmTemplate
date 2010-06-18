namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Windows
open System.Windows.Input
open System.ComponentModel

type ExpenseItHomeViewModel() =   
    inherit ViewModelBase()       
    member x.ViewCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ShowMessage)) 

    member public x.ShowMessage = do MessageBox.Show("test") |> ignore

