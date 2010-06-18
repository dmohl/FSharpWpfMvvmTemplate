namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Windows
open System.Windows.Input
open System.ComponentModel

type ExpenseReportViewModel() =   
    inherit ViewModelBase()              
    member public x.ShowMessage = do MessageBox.Show("test") |> ignore

