namespace cbb.core
{
    using System;

    /// <summary>
    /// The helper functions for converting length units in desired types.
    /// </summary>
    public static class LengthUnitsConverter
    {
        #region public methods

        /// <summary>
        /// Converts the Revit internal value (decimal feet) to the specified display unit.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of unit to convert to.</param>
        /// <param name="decimals">The number of decimal places to round to.</param>
        /// <returns>A double representing the converted and rounded value.</returns>
        public static double ConvertFromInternal(double value, LengthUnitType type, int decimals)
        {
            switch (type)
            {
                case LengthUnitType.Millimeter:
                    return Math.Round(value * 304.8, decimals);
                case LengthUnitType.Centimeter:
                    return Math.Round(value * 30.48, decimals);
                case LengthUnitType.Decimeter:
                    return Math.Round(value * 3.048, decimals);
                case LengthUnitType.Meter:
                    return Math.Round(value * 0.3048, decimals);
                case LengthUnitType.Kilometer:
                    return Math.Round(value * 0.0003048, decimals);
                case LengthUnitType.Inch:
                    return Math.Round(value * 12.0, decimals);
                case LengthUnitType.Foot:
                    return Math.Round(value, decimals);

                default:
                    return Math.Round(value*304.8, decimals);

            }

        }

        public static string GetUnitAbbreviation(LengthUnitType unitType)
        {
            switch (unitType)
            {
                case LengthUnitType.Centimeter:
                    return "cm";
                case LengthUnitType.Meter:
                    return "m";
                case LengthUnitType.Decimeter:
                    return "dm";
                case LengthUnitType.Kilometer:
                    return "km";
                case LengthUnitType.Inch:
                    return "in";
                case LengthUnitType.Foot:
                    return "ft";
                case LengthUnitType.Millimeter:
                default:
                    return "";
            }

            #endregion
        }
    }
}
