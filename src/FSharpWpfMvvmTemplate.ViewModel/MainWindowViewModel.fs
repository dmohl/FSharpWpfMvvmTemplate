namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel

type MainWindowViewModel =
    [<DefaultValue(false)>] val mutable _views : ObservableCollection<ViewModelBase>   
    new() as x = {_views = new ObservableCollection<ViewModelBase>()} then x.Initialize()
    member x.Initialize() =
        let defaultView = new ExpenseItHomeViewModel()
        x._views.Add(defaultView)              
        x._views.Add(new ExpenseReportViewModel()) 
        x.SetActiveView defaultView
    member x.SelectedView = 
        let collectionView = CollectionViewSource.GetDefaultView x.Views
        collectionView.CurrentItem :?> ViewModelBase
    member x.Views = x._views
    member x.SetActiveView view =
        let collectionView = CollectionViewSource.GetDefaultView x.Views
        if collectionView <> null then collectionView.MoveCurrentTo view |> ignore


