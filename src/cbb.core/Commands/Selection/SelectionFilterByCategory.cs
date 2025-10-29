namespace cbb.core
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    /// <summary>
    /// Selection filter based on the user provided category name.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.Selection.ISelectionFilter" />
    public class SelectionFilterByCategory : ISelectionFilter
    {
        #region private members

        // Private variable to hold category name.
        private string mCategory = "";

        #endregion

        #region constructor

        /// <summary>
        /// default constructor.
        /// Initializes a new instance of the <see cref="SelectionFilterByCategory"/> class.
        /// </summary>
        /// <param name="category">The category of element, such as Walls, Floors,...</param>
        public SelectionFilterByCategory(string category)
        {
            mCategory = category;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Allows the element selection if provided category is equal to selected one.
        /// </summary>
        /// <param name="elem">The element to evaluate. Must not be null.</param>
        /// <returns><see langword="true"/> if the element's category matches the specified category; otherwise, <see
        /// langword="false"/>.</returns>
        public bool AllowElement(Element elem)
        {
            if (elem.Category != null && elem.Category.Name.Equals(mCategory))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows the reference.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>"
        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }

        #endregion
    }
}
