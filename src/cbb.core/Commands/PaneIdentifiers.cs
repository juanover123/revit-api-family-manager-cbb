namespace cbb.core
{
    using System;

    /// <summary>
    /// Guid container that hilds all pane identifiers used in the application.
    /// </summary>
    public static class PaneIdentifiers
    {
        #region public properties

        /// <summary>
        /// The family manager pane identifier.
        /// </summary>
        /// <returns></returns>
        public static Guid GetFamilyManagerPaneId()
        {
            return new Guid("D1F5E8C3-3C6B-4F2A-9D7B-8F1E6C3A9B2E");
        }
        


        #endregion
    }
}
