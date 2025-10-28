namespace cbb.ui
{
    using System;

    using Autodesk.Revit;
    using Autodesk.Revit.UI;

    using core;
    using res;

    /// <summary>
    /// The Revit push button methods.    
    /// </summary>
    public static class RevitPushButton
    {
        #region public methods

        /// <summary>
        ///  Creates the push button based on provided data model from <see cref="RevitPushButtonDataModel"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PushButton Create(RevitPushButtonDataModel data)
        {
            // The button name based on unique identifier.
            var btnDataName = Guid.NewGuid().ToString();

            // Sets the button data.
            var btnData = new PushButtonData(btnDataName,
                                                        data.Label,
                                                        CoreAssembly.GetAssemblyLocation(),
                                                        data.CommandNamespacePath)
            {
                ToolTip = data.ToolTip,
                LargeImage = cbb.res.ResourceImage.GetIcon(data.IconImageName),
                ToolTipImage = cbb.res.ResourceImage.GetIcon(data.TooltipImageName),
                Image = cbb.res.ResourceImage.GetIcon(data.SmallImageName)
            };

            // Return created button and host it on panel provided in required data model..
            return data.Panel.AddItem(btnData) as PushButton;
        }

        #endregion
    }
}
