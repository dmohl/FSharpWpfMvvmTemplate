namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.Generic
open System.Collections.ObjectModel
open System.Collections.Specialized
open System.ComponentModel
open System.Diagnostics
open System.Windows.Data
open FSharpWpfMvvmTemplate.DataAccess
open FSharpWpfMvvmTemplate.Model
open FSharpWpfMvvmTemplate.Properties

type MainWindowViewmodel =
    [<DefaultValue(false)>] val mutable _commands : ReadOnlyCollection<CommandViewModel>
    val _customerRepository : CustomerRepository
    val _mainWindowCommandViewModel : MainWindowCommandViewModel
    inherit WorkspaceViewModel
        new (customerDataFile) = {
            _customerRepository = new CustomerRepository(customerDataFile);
            _mainWindowCommandViewModel = new MainWindowCommandViewModel(_customerRepository)
            } //then base.DisplayName <- Strings.MainWindowViewModel_DisplayName
        member x.Commands 
            with get() =
                match x._commands with 
                | null -> 
                    let commands = x._mainWindowCommandViewModel.CreateCommands()
                    x._commands <- new ReadOnlyCollection<CommandViewModel>(commands)
                    x._commands
                | _ -> x._commands
        member x.Workspaces
            with get()  : ObservableCollection<WorkspaceViewModel> =
                x._mainWindowCommandViewModel.Workspaces
