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
        public static PushButton? FamilyManagerShowButton { get; private set; }
        public static PushButton? FamilyManagerHideButton { get; private set; }

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
                IconImageName = "wallTag_icon_32x32.png",
                TooltipImageName = "wallTag_tooltip_320x320.png",
                SmallImageName = "wallTag_icon_16x16.png"
            };

            // Create button from provided data.
            var TagWallLayersButton = RevitPushButton.Create(TagWallLayersButtonData);

            #endregion

            #region family manager

            var familyManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = "Show",
                Panel = familyManagerCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = FamilyManagerShowCommand.GetPath(),
                IconImageName = "familyManagerShow_icon_32x32.png",
                TooltipImageName = "familyManagerShow_tooltip_320x320.png",
                SmallImageName = "familyManagerShow_icon_16x16.png"
            };

            FamilyManagerShowButton = RevitPushButton.Create(familyManagerShowButtonData);

            FamilyManagerShowButton.Enabled = false;

            var familyManagerHideButtonData = new RevitPushButtonDataModel
            {
                Label = "Hide",
                Panel = familyManagerCommandsPanel,
                ToolTip = "This is some sample tooltip text, replace it with real one later,...",
                CommandNamespacePath = FamilyManagerHideCommand.GetPath(),
                IconImageName = "familyManagerHide_icon_32x32.png",
                TooltipImageName = "familyManagerHide_tooltip_320x320.png",
                SmallImageName = "familyManagerHide_icon_16x16.png"
            };

            FamilyManagerHideButton = RevitPushButton.Create(familyManagerHideButtonData);

            FamilyManagerHideButton.Enabled = false;

            #endregion
        }

        #endregion
    }
}
