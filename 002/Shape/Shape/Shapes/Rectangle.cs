namespace Shape.Shapes
{
    /// <summary>
    /// Rectangle class which is inherited from abstarct class Shape.
    /// </summary>
    class Rectangle : Shape
    {
        private static int m_nSnum = 0;
        private float m_fLength, m_fWidth;
        private double m_dblArea, m_dblPerimeter;

        /// <summary>
        /// Rectangle constructor for initializing object with the length, width and the serial number.
        /// </summary>
        /// <param name="fLength">
        /// For taking the length of the reactangle.
        /// </param>
        /// <param name="fWidth">
        /// For taking the width of the reactangle.
        /// </param>
        public Rectangle(float fLength, float fWidth)
        {
            m_nSnum += 1;
            SerialNumber = m_nSnum;
            m_fLength = fLength;
            m_fWidth = fWidth;
        }

        /// <summary>
        /// Overrided Area method for calculating area of reactangle.
        /// </summary>
        /// <returns>
        /// Area of reactangle.
        /// </returns>
        public override double Area()
        {
            m_dblArea = m_fLength * m_fWidth;
            return m_dblArea;
        }

        /// <summary>
        /// Overrided Perimeter method for calculating perimeter of reactangle.
        /// </summary>
        /// <returns>
        /// Perimeter of reactangle.
        /// </returns>
        public override double Perimeter()
        {
            m_dblPerimeter = 2 * (m_fLength + m_fWidth);
            return m_dblPerimeter;
        }

        /// <summary>
        /// Overrided ShowClassName method for displaying Rectangle class name.
        /// </summary>
        /// <returns>
        /// Name of the Rectangle Class
        /// </returns>
        public override string ShowClassName()
        {
            return this.GetType().Name;
        }
    }
}
