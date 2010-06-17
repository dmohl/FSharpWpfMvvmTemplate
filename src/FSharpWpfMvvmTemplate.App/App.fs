module FSharpWpfMvvmTemplate

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FSharpWpfMvvmTemplate.ViewModel

// Create the View and bind it to the View Model
let mainView = 
    Application.LoadComponent(new System.Uri("/FSharpWpfMvvmTemplate.View;component/MainView.xaml", System.UriKind.Relative)) :?> Window
mainView.DataContext <- new MainViewModel() :> obj

// Application Entry point
[<STAThread>]
[<EntryPoint>]
let main(_) = (new Application()).Run(mainView)