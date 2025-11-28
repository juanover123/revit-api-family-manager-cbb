using System.Windows.Input;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace cbb.core
{
    /// <summary>
    /// A view model for the main application page.
    /// </summary>
    /// /// <seealso cref="cbb.core.BaseViewModel"/>
    public class FamilyManagerMainPageViewModel : BaseViewModel
    {
        #region public properties

        /// <summary>
        /// Gets or sets the current page of the application.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        public ApplicationPageType CurrentPage { get; set; } = ApplicationPageType.Family;

        #endregion

        #region commands

        /// <summary>
        /// Gets or sets the family page as current.
        /// </summary>
        /// <value>
        /// The family button command.
        /// </value>
        public ICommand FamilyBtnCommand { get; set; }

        /// <summary>
        /// Gets or sets the preferences page as current.
        /// </summary>
        /// <value>
        /// The preferences button command.
        /// </value>
        public ICommand PreferencesBtnCommand { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyManagerMainPageViewModel"/> class.
        /// </summary>
        public FamilyManagerMainPageViewModel()
        {
            FamilyBtnCommand = new RouteCommands(FamilyBtnCommandExecute);
            PreferencesBtnCommand = new RouteCommands(PreferencesBtnCommandExecute);
        }

        #endregion

        #region private methods
        
        private void FamilyBtnCommandExecute()
        {
            // test code to see if button command works
            Message.Display("Family button clicked!", WindowType.Information);
        }

        private void PreferencesBtnCommandExecute()
        {
            // test code to see if button command works
            Message.Display("Preferences button clicked!", WindowType.Information);
        }

        #endregion


    }
}
