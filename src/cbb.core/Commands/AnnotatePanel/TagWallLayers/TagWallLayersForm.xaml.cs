namespace cbb.core
{
    using Autodesk.Revit.UI;
    using Autodesk.Revit.DB;

    using System.Windows;
    using System.Collections.Generic;

    /// <summary>
    /// Tag wall layers data aquisition form. Interaction logic for TagWallLayersForm.xaml
    /// </summary>
    public partial class TagWallLayersForm : Window
    {
        #region private members

        /// <summary>
        /// The private reference to the <see cref="UIDocument"/> instance."/>
        /// </summary>
        private UIDocument? uidoc = null;

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor
        /// Initializes a new instance of the <see cref="TagWallLayersForm"/> class.
        /// </summary>
        /// <param name="uIDocument"></param>
        public TagWallLayersForm(UIDocument uIDocument)
        {
            InitializeComponent();

            uidoc = uIDocument;
        }

        #endregion

        #region events

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            this.Close();
        }

        /// <summary>
        /// Handles the click event of the CancelButton control, setting the dialog result to <see langword="false"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the TagWallLayersForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Instance containing the event data.</param>
        private void TagWallLayersForm_Loaded(object sender, RoutedEventArgs e)
        {
            textNoteTypeListPopulate();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get the information from the user using the form.
        /// </summary>
        /// <returns></returns>
        public TagWallLayersCommandData GetInformation()
        {
            // Information gathered from window.
            var information = new TagWallLayersCommandData()
            {
                Function = functionCheckBox.IsChecked ?? false,
                Name = nameCheckBox.IsChecked ?? false,
                Thickness = thicknessCheckBox.IsChecked ?? false,
                TextTypeId = (ElementId)textNoteElementTypeComboBox.SelectedValue
            };

            return information;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Populates the text note type list combo box with all available text note types in the document.
        /// </summary>
        private void textNoteTypeListPopulate()
        {
            var doc = uidoc.Document;

            // Get all Text Element Types in the document.
            var allTextElementTypes = new FilteredElementCollector(doc)
                .OfClass(typeof(TextElementType));

            var list = new List<KeyValuePair<string, ElementId>>();

            foreach (var item in allTextElementTypes)
            {
                list.Add(new KeyValuePair<string, ElementId>(item.Name, item.Id));
            }

            textNoteElementTypeComboBox.ItemsSource = list;
            textNoteElementTypeComboBox.DisplayMemberPath = "Key";
            textNoteElementTypeComboBox.SelectedValuePath = "Value";
            textNoteElementTypeComboBox.SelectedIndex = 0;
        }

        #endregion
    }
}
