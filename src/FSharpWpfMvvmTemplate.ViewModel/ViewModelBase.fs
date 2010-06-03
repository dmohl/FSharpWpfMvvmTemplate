namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.ComponentModel
open System.Diagnostics

[<AbstractClass>] 
type ViewModelBase() =
    let mutable _displayName = ""
    abstract member OnDispose : unit -> unit
    default x.OnDispose() = "" |> ignore
    member x.DisplayName 
        with get() = _displayName 
        and set(value) = _displayName <- value;
    
    //interface INotifyPropertyChanged with
    interface IDisposable with
        member x.Dispose () =
            x.OnDispose()


//        #region INotifyPropertyChanged Members
//
//        /// <summary>
//        /// Raised when a property on this object has a new value.
//        /// </summary>
//        public event PropertyChangedEventHandler PropertyChanged;
//
//        /// <summary>
//        /// Raises this object's PropertyChanged event.
//        /// </summary>
//        /// <param name="propertyName">The property that has a new value.</param>
//        protected virtual void OnPropertyChanged(string propertyName)
//        {
//            this.VerifyPropertyName(propertyName);
//
//            PropertyChangedEventHandler handler = this.PropertyChanged;
//            if (handler != null)
//            {
//                var e = new PropertyChangedEventArgs(propertyName);
//                handler(this, e);
//            }
//        }
//
//        #endregion // INotifyPropertyChanged Members
//
//        #region IDisposable Members
//
//        /// <summary>
//        /// Invoked when this object is being removed from the application
//        /// and will be subject to garbage collection.
//        /// </summary>
//        public void Dispose()
//        {
//            this.OnDispose();
//        }
//
//        /// <summary>
//        /// Child classes can override this method to perform 
//        /// clean-up logic, such as removing event handlers.
//        /// </summary>
//        protected virtual void OnDispose()
//        {
//        }
//
//#if DEBUG
//        /// <summary>
//        /// Useful for ensuring that ViewModel objects are properly garbage collected.
//        /// </summary>
//        ~ViewModelBase()
//        {
//            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
//            System.Diagnostics.Debug.WriteLine(msg);
//        }
//#endif
//
//        #endregion // IDisposable Members
//    }
//}
