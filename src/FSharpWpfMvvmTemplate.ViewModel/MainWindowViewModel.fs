namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel

type MainWindowViewModel =
    [<DefaultValue(false)>] val mutable _views : ObservableCollection<string>   
    new() as x = {_views = new ObservableCollection<string>()} then x.Initialize()
    member x.Initialize() =
        let defaultView = "ExpenseItHome.xaml"
        x._views.Add(defaultView)              
        x._views.Add("ExpenseReport.xaml") 
        x.SetActiveView defaultView
    member x.SelectedView = 
        let collectionView = CollectionViewSource.GetDefaultView x.Views
        collectionView.CurrentItem :?> string
    member x.Views = x._views
    member x.SetActiveView view =
        let collectionView = CollectionViewSource.GetDefaultView x.Views
        if collectionView <> null then collectionView.MoveCurrentTo view |> ignore


