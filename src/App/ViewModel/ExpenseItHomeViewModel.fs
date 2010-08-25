namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Xml
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel
open System.Collections.ObjectModel
open FSharpWpfMvvmTemplate.Model
open FSharpWpfMvvmTemplate.Repository

type ExpenseItHomeViewModel(expenseReportRepository : ExpenseReportRepository) =   
    inherit ViewModelBase()
    let mutable selectedExpenseReport = 
        {Name=""; Department=""; ExpenseLineItems = []}
    new () = ExpenseItHomeViewModel(ExpenseReportRepository())
    member x.ExpenseReports = 
        new ObservableCollection<ExpenseReport>(
            expenseReportRepository.GetAll())
    member x.ApproveExpenseReportCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ApproveExpenseReport)) 
    member x.SelectedExpenseReport 
        with get () = selectedExpenseReport
        and set value = 
            selectedExpenseReport <- value
            x.OnPropertyChanged "SelectedExpenseReport"
    member x.ApproveExpenseReport = 
        // Note: This is for example purposes only.  It is not a good practice to 
        //       use MessageBox.Show in the ViewModel. 
        MessageBox.Show(sprintf "Expense report approved for %s" x.SelectedExpenseReport.Name) |> ignore
