using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace cbb.core
{
    /// <summary>
    /// A view model for the main application page.
    /// </summary>

    public partial class FamilyManagerMainPageViewModel : ObservableObject
    {
        #region obsevable properties

        /// <summary>
        /// Gets or sets the current page of the application.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        [ObservableProperty]
        private ApplicationPageType _currentPage = ApplicationPageType.Family;

        #endregion

        #region commands

        /// <summary>
        /// Executes the Family Button action.
        /// (Generates the ICommand property: FamilyBtnCommand)
        /// </summary>
        [RelayCommand]
        private void FamilyBtn()
        {
            CurrentPage = ApplicationPageType.Family;
            Message.Display("Family button clicked!", WindowType.Information);
        }

        /// <summary>
        /// Executes the Preferences Button action.
        /// (Generates the ICommand property: PreferencesBtnCommand)
        /// </summary>
        [RelayCommand]
        private void PreferencesBtn()
        {
            CurrentPage = ApplicationPageType.Preferences;
            Message.Display("Preferences button clicked!", WindowType.Information);
        }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyManagerMainPageViewModel"/> class.
        /// </summary>
        public FamilyManagerMainPageViewModel()
        {
        }

        #endregion



    }
}
