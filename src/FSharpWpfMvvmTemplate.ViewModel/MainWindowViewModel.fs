namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Input
open System.ComponentModel

type MainWindowViewModel() =
//    let collectionView : ICollectionView =  
//        let views = new ObservableCollection<ViewModelBase>()
//        views.Add(new ExpenseItHomeViewModel())              
//        views.Add(new ExpenseReportViewModel())  
//                    
//    member ObservableCollection<ViewModelBase> Views = x.views
//    member x.SelectedView = collectionView.CurrentItem :> ViewModelBase
    member public x.ShowMessage = do MessageBox.Show("test") |> ignore

