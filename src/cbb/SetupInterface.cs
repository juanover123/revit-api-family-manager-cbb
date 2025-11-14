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

            // Create the ribbon panels.
            var annotateCommandsPanel = app.CreateRibbonPanel(tabName, "Annotation Commands");
            var familyManagerCommandsPanel = app.CreateRibbonPanel(tabName, "Family Manager Commands");

            #region annotate panel

            // Populate button data model.
            var TagWallLayersButtonData = new RevitPushButtonDataModel
            {
                Label = "Tag Wall\nLayers",
                Panel = annotateCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = TagWallLayersCommand.GetPath(),
                IconImageName = "wallTag_icon_96x96.png",
                TooltipImageName = "wallTag_tooltip_320x320.png",
                SmallImageName = "wallTag_icon_32x32.png"
            };

            // Create button from provided data.
            var TagWallLayersButton = RevitPushButton.Create(TagWallLayersButtonData);

            #endregion

            #region family manager

            var familyManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = "Show Family\nManager",
                Panel = familyManagerCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = FamilyManagerShowCommand.GetPath(),
                IconImageName = "familyManagerShow_icon_96x96.png",
                TooltipImageName = "familyManagerShow_tooltip_320x320.png",
                SmallImageName = "familyManagerShow_icon_32x32.png"
            };

            var familyManagerShowButton = RevitPushButton.Create(familyManagerShowButtonData);

            var familyManagerHideButtonData = new RevitPushButtonDataModel
            {
                Label = "Hide Family\nManager",
                Panel = familyManagerCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = FamilyManagerHideCommand.GetPath(),
                IconImageName = "familyManagerHide_icon_96x96.png",
                TooltipImageName = "familyManagerHide_tooltip_320x320.png",
                SmallImageName = "familyManagerHide_icon_32x32.png"
            };

            var familyManagerHideButton = RevitPushButton.Create(familyManagerHideButtonData);

            #endregion
        }

        #endregion
    }
}
