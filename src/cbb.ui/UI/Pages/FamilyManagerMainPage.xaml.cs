namespace cbb.ui
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using Autodesk.Revit.UI;

    using core;

    /// <summary>
    /// Interaction logic for FamilyManagerMainPage.xaml
    /// </summary>
    public partial class FamilyManagerMainPage : Page, IDisposable, IDockablePaneProvider
    {
        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="FamilyManagerMainPage"/> class.
        /// </summary>
        public FamilyManagerMainPage()
        {
            InitializeComponent();

            // Set data context for main application page..
            DataContext = new FamilyManagerMainPageViewModel();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Perfdorm application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
        }

        /// <summary>
        /// Setups the dockable pane.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;

            // Set initial state of the dockable pane in Revit UI.
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
                TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
            };
        }

        #endregion
    }
}
