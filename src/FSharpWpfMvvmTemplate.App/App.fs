module FSharpWpfMvvmTemplate

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FSharpWpfMvvmTemplate.ViewModel

// Create the View and bind it to the View Model
//Application.LoadComponent(new System.Uri("/FSharpWpfMvvmTemplate.View;component/ExpenseItHome.xaml", UriKind.Relative)) |> ignore
let mainWindow = Application.LoadComponent(
                    new System.Uri("/FSharpWpfMvvmTemplate.App;component/mainwindow.xaml", UriKind.Relative)) :?> Window
mainWindow.DataContext <- new MainWindowModel() :> obj

// Application Entry point
[<STAThread>]
[<EntryPoint>]
let main(_) = (new Application()).Run(mainWindow)