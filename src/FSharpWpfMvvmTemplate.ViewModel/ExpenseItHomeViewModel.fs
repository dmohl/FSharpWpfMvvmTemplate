namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Xml
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel
open System.Collections.ObjectModel
open FSharpWpfMvvmTemplate.Model

type ExpenseItHomeViewModel() =   
    inherit ViewModelBase() 
    let BuildExpenses() = 
        let collection = new ObservableCollection<Person>()
        let mike = {Name="Mike" 
                    Department="Legal" 
                    ExpenseLineItems = 
                        [{ExpenseType="Lunch" 
                          ExpenseAmount="50"};
                        {ExpenseType="Transportation" 
                         ExpenseAmount="50"}]}
        collection.Add(mike)
        let lisa = {Name="Lisa"
                    Department="Marketing" 
                    ExpenseLineItems = 
                        [{ExpenseType="Document printing" 
                          ExpenseAmount="50"};
                        {ExpenseType="Gift" 
                         ExpenseAmount="125"}]}
        collection.Add(lisa)
        let john = {Name="John" 
                    Department="Engineering"
                    ExpenseLineItems = 
                        [{ExpenseType="Magazine subscription" 
                          ExpenseAmount="50"};
                        {ExpenseType="New machine" 
                         ExpenseAmount="600"};
                        {ExpenseType="Software" 
                         ExpenseAmount="500"}]}
        collection.Add(john)
        let mary = {Name="Mary"
                    Department="Finance"
                    ExpenseLineItems = 
                        [{ExpenseType="Dinner" 
                          ExpenseAmount="100"}]}
        collection.Add(mary)
        collection
    member x.Expenses : ObservableCollection<Person> = 
        BuildExpenses()
    member x.ViewCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ShowMessage)) 

    member public x.ShowMessage = do MessageBox.Show("test") |> ignore

