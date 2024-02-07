namespace Shape.Shapes
{
    /// <summary>
    /// Abstarct Shape class.
    /// </summary>
    abstract class Shape
    {
        //Serial number of object.
        private int m_nSerialNumber;

        /// <summary>
        /// Propery for serial number of object.
        /// </summary>
        public int SerialNumber
        {
            get { return m_nSerialNumber; }
            set { m_nSerialNumber = value; }
        }

        /// <summary>
        /// Abstarct method for calculating area.
        /// </summary>
        /// <returns>
        /// Returns double value.
        /// </returns>
        public abstract double Area();

        /// <summary>
        /// Abstarct method for calculating perimeter.
        /// </summary>
        /// <returns>
        /// Returns double value.
        /// </returns>
        public abstract double Perimeter();

        /// <summary>
        /// Abstarct method for display current class name.
        /// </summary>
        /// <returns>
        /// Name of the Class
        /// </returns>
        public virtual string ShowClassName()
        {
            return this.GetType().Name;
        }
    }
}
