namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Xml
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel

type ExpenseItHomeViewModel() =   
    inherit ViewModelBase() 
    member x.ExpenseData = 
        let doc = new XmlDocument()
        doc.LoadXml(
            "<Expenses xmlns=\"\">
                <Person Name=\"Mike\" Department=\"Legal\">
                    <Expense ExpenseType=\"Lunch\" ExpenseAmount=\"50\" />
                    <Expense ExpenseType=\"Transportation\" ExpenseAmount=\"50\" />
                </Person>
                <Person Name=\"Lisa\" Department=\"Marketing\">
                    <Expense ExpenseType=\"Document printing\"
                        ExpenseAmount=\"50\"/>
                    <Expense ExpenseType=\"Gift\" ExpenseAmount=\"125\" />
                </Person>
                <Person Name=\"John\" Department=\"Engineering\">
                    <Expense ExpenseType=\"Magazine subscription\" 
                        ExpenseAmount=\"50\"/>
                    <Expense ExpenseType=\"New machine\" ExpenseAmount=\"600\" />
                    <Expense ExpenseType=\"Software\" ExpenseAmount=\"500\" />
                </Person>
                <Person Name=\"Mary\" Department=\"Finance\">
                    <Expense ExpenseType=\"Dinner\" ExpenseAmount=\"100\" />
                </Person>
            </Expenses>")
        let xmlProvider = new XmlDataProvider()
        xmlProvider.Document <- doc
        xmlProvider
    member x.ViewCommand = 
        new RelayCommand ((fun canExecute -> true), (fun action -> x.ShowMessage)) 

    member public x.ShowMessage = do MessageBox.Show("test") |> ignore

