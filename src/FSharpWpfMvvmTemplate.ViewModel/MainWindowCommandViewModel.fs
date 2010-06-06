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

//namespace DemoApp.ViewModel
//{
//    public class MainWindowCommandViewModel
//    {
//        ObservableCollection<WorkspaceViewModel> _workspaces;
//        readonly CustomerRepository _customerRepository;
//
//        public MainWindowCommandViewModel(CustomerRepository customerRepository)
//        {
//            _customerRepository = customerRepository;
//        }
//
//        public List<CommandViewModel> CreateCommands()
//        {
//            return new List<CommandViewModel>
//            {
//                new CommandViewModel(
//                    Strings.MainWindowViewModel_Command_ViewAllCustomers,
//                    new RelayCommand(param => this.ShowAllCustomers())),
//
//                new CommandViewModel(
//                    Strings.MainWindowViewModel_Command_CreateNewCustomer,
//                    new RelayCommand(param => this.CreateNewCustomer()))
//            };
//        }
//
//        #region Private Helpers
//
//        void CreateNewCustomer()
//        {
//            Customer newCustomer = Customer.CreateNewCustomer();
//            CustomerViewModel workspace = new CustomerViewModel(newCustomer, _customerRepository);
//            this.Workspaces.Add(workspace);
//            this.SetActiveWorkspace(workspace);
//        }
//
//        void ShowAllCustomers()
//        {
//            AllCustomersViewModel workspace =
//                this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
//                as AllCustomersViewModel;
//
//            if (workspace == null)
//            {
//                workspace = new AllCustomersViewModel(_customerRepository);
//                this.Workspaces.Add(workspace);
//            }
//
//            this.SetActiveWorkspace(workspace);
//        }
//
//        void SetActiveWorkspace(WorkspaceViewModel workspace)
//        {
//            Debug.Assert(this.Workspaces.Contains(workspace));
//
//            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
//            if (collectionView != null)
//                collectionView.MoveCurrentTo(workspace);
//        }
//
//        #endregion // Private Helpers
//
//        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
//        {
//            if (e.NewItems != null && e.NewItems.Count != 0)
//                foreach (WorkspaceViewModel workspace in e.NewItems)
//                    workspace.RequestClose += this.OnWorkspaceRequestClose;
//
//            if (e.OldItems != null && e.OldItems.Count != 0)
//                foreach (WorkspaceViewModel workspace in e.OldItems)
//                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
//        }
//
//        void OnWorkspaceRequestClose(object sender, EventArgs e)
//        {
//            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
//            workspace.Dispose();
//            this.Workspaces.Remove(workspace);
//        }
//
//        /// <summary>
//        /// Returns the collection of available workspaces to display.
//        /// A 'workspace' is a ViewModel that can request to be closed.
//        /// </summary>
//        public ObservableCollection<WorkspaceViewModel> Workspaces
//        {
//            get
//            {
//                if (_workspaces == null)
//                {
//                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
//                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
//                }
//                return _workspaces;
//            }
//        }
//
//    }
//}

