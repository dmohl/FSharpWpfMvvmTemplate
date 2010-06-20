namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel

type MainWindowViewModel =
    [<DefaultValue(false)>] val _views : ObservableCollection<ViewModelBase>
    [<DefaultValue(false)>] val mutable _collectionView : ICollectionView
    new() as x = {_views = new ObservableCollection<ViewModelBase>();
                  _collectionView = null} then x.Initialize()
    member x.Initialize() =
        let masterView = new ExpenseItHomeViewModel()
        masterView.ExpenseReportViewChanged.AddHandler(
            new EventHandler(
                fun s e -> (MessageBox.Show("here")
                            x._collectionView.MoveCurrentToNext() |> ignore)))
        x._views.Add(masterView)              
        x._views.Add(new ExpenseReportViewModel()) 
        x._collectionView <- CollectionViewSource.GetDefaultView(x._views)
    member x.SelectedView = x._collectionView.CurrentItem :?> ViewModelBase
    member x.Views = x._views
    member x.SetActiveView view =
        if x._collectionView <> null then x._collectionView.MoveCurrentTo view |> ignore

