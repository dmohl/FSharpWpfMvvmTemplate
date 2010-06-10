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

type MainWindowCommandViewModel(_customerRepository) =
    [<DefaultValue(false)>] 
    val mutable _workspaces : ObservableCollection<WorkspaceViewModel>
    member x.CreateCommands () = 
        let commandViewModels = new List<CommandViewModel>()
        commandViewModels.Add(
            new CommandViewModel(
                Strings.MainWindowViewModel_Command_ViewAllCustomers,
                new RelayCommand(fun param -> 
                    MainWindowCommandViewModelMod.ShowAllCustomers())))
        commandViewModels.Add(
            new CommandViewModel(
                Strings.MainWindowViewModel_Command_CreateNewCustomer,
                new RelayCommand(fun param -> 
                    MainWindowCommandViewModelMod.CreateNewCustomer())))
    member x.Workspaces 
        with get() = match x._workspaces with
                     | null -> 
                        x._workspaces <- new ObservableCollection<WorkspaceViewModel>()
                        x._workspaces.CollectionChanged.AddHandler x.OnWorkspacesChanged
                        x._workspaces
                     | _ -> x._workspaces
    member x.CreateNewCustomer () = 
        let newCustomer = Customer.CreateNewCustomer()
        let workspace = 
            new CustomerViewModel(newCustomer, _customerRepository)
            |> x.Workspaces.Add
        x.SetActiveWorkspace workspace    
    member x.ShowAllCustomers () =
        let workspace = x.Workspaces 
                        |> Seq.tryFind (fun vm -> 
                            vm.GetType() = AllCustomersViewModel) 
                            :?> AllCustomersViewModel
        match workspace with
        | null -> let newWorkspace = 
                      new AllCustomersViewModel(_customerRepository)
                      |> x.Workspaces.Add
                  newWorkspace
        | _ -> workspace
        |> x.SetActiveWorkspace
    member x.SetActiveWorkspace workspace =
        let collectionView = 
            CollectionViewSource.GetDefaultView(x.Workspaces)
        match collectionView with 
        | null -> true
        | _ -> collectionView.MoveCurrentTo workspace
        |> ignore
    member x.OnWorkspacesChanged (sender:obj) (e:NotifyCollectionChangedEventArgs) =
        match e with
        | _ when e.NewItems <> null && e.NewItems.Count <> 0 ->
            for workspace in e.NewItems do 
                workspace.RequestClose.AddHandler x.OnWorkspaceRequestClose
        | _ when e.OldItems <> null && e.OldItems.Count <> 0 ->
            for workspace in e.OldItems do 
                workspace.RequestClose.RemoveHandler x.OnWorkspaceRequestClose
    member x.OnWorkspaceRequestClose (sender:obj) (e : EventArgs) =
        let workspace = sender :?> WorkspaceViewModel
        do workspace.Dispose()
        x.Workspaces.Remove workspace
