namespace FSharpWpfMvvmTemplate.Model

type Person =
    { Name : string
      Department : string
      ExpenseLineItems : seq<Expense>}

