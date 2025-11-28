namespace cbb.core
{
    using System.ComponentModel;

    /// <summary>
    /// A base view model functionality for all view models.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        #endregion

        #region public methods

        /// <summary>
        /// Call this method to raise <see cref="PropertyChanged"/> event"/>
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
