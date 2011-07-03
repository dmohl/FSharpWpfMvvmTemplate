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

type ApprovalStatus =
    | Approved
    | Rejected

type ExpenseItHomeViewModel(expenseReportRepository : ExpenseReportRepository) =   
    inherit ViewModelBase()
    let mutable lastApprovalDisplayMessage = ""
    let mutable selectedExpenseReport = 
        {Name=""; Department=""; ExpenseLineItems = []}
    new () = ExpenseItHomeViewModel(ExpenseReportRepository())
    member x.ExpenseReports = 
        new ObservableCollection<ExpenseReport>(
            expenseReportRepository.GetAll())
    member x.HandleApprovalAction approvalStatus name =
        match approvalStatus with
        | ApprovalStatus.Approved -> 
            x.LastApprovalDisplayMessage <- sprintf "Expense report approved for %s" name
        | ApprovalStatus.Rejected ->
            x.LastApprovalDisplayMessage <- sprintf "Expense report rejected for %s" name
    member x.ApproveExpenseReportCommand = 
        new RelayCommand ((fun canExecute -> true), 
            (fun action -> x.HandleApprovalAction ApprovalStatus.Approved x.SelectedExpenseReport.Name)) 
    member x.RejectExpenseReportCommand = 
        new RelayCommand ((fun canExecute -> true), 
            (fun action -> x.HandleApprovalAction ApprovalStatus.Rejected x.SelectedExpenseReport.Name)) 
    member x.SelectedExpenseReport 
        with get () = selectedExpenseReport
        and set value = 
            selectedExpenseReport <- value
            x.OnPropertyChanged "SelectedExpenseReport"
    member x.LastApprovalDisplayMessage 
        with get() = lastApprovalDisplayMessage
        and set value = 
            lastApprovalDisplayMessage <- value 
            x.OnPropertyChanged "LastApprovalDisplayMessage"
