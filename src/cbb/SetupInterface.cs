namespace cbb
{
    using Autodesk.Revit.UI;

    using ui;
    using core;

    /// <summary>
    /// Setup whole plugins interface with tabs, panels, buttons,...
    /// </summary>
    public class SetupInterface
    {
        #region

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupInterface"/> class.
        /// </summary>
        public SetupInterface()
        {
        
        }

        /// <summary>
        /// Initializes all interface elements on custom created Revit tab.
        /// </summary>
        public void Initialize(UIControlledApplication app)
        {
            // Create Ribbon tab.
            string tabName = "JuanoverTestBox";
            app.CreateRibbonTab(tabName);

            // Create the annotate commands panel.
            var annotateCommandsPanel = app.CreateRibbonPanel(tabName, "Annotation Commands");

            // Populate button data model.
            var TagWallLayersButtonData = new RevitPushButtonDataModel
            {
                Label = "Tag Wall\nLayers",
                Panel = annotateCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = TagWallLayersCommand.GetPath(),
                IconImageName = "wallTag_icon_32x32.png",
                TooltipImageName = "wallTag_tooltip_320x320.png",
                SmallImageName = "wallTag_icon_16x16.png"
            };

            // Create button from provided data.
            var TagWallLayersButton = RevitPushButton.Create(TagWallLayersButtonData);
        }

        #endregion
    }
}
