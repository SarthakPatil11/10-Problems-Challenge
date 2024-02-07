using Shape.Helper;

namespace Shape.Shapes
{
    /// <summary>
    /// Circle class which is inherited from abstarct class Oval.
    /// </summary>
    class Circle : Oval
    {
        private static int m_nSnum = 0;
        private float m_fRedius;
        private double m_dblArea, m_dblPerimeter;

        /// <summary>
        /// Circle constructor for initializing object with the redius.
        /// </summary>
        /// <param name="fRedius">
        /// For taking the Redius of circle.
        /// </param>
        public Circle(float fRedius) : base()
        {
            m_nSnum += 1;
            SerialNumber = m_nSnum;
            m_fRedius = fRedius;
        }

        /// <summary>
        /// Overrided Area method for calculating area of circle.
        /// </summary>
        /// <returns>
        /// Area of circle.
        /// </returns>
        public override double Area()
        {
            m_dblArea = Constants.PI * (m_fRedius * m_fRedius);
            return m_dblArea;
        }

        /// <summary>
        /// Overrided Perimeter method for calculating perimeter of circle.
        /// </summary>
        /// <returns>
        /// Perimeter of circle.
        /// </returns>
        public override double Perimeter()
        {
            m_dblPerimeter = 2 * Constants.PI * m_fRedius;
            return m_dblPerimeter;
        }

        /// <summary>
        /// Overrided ShowClassName method for returning Circle class name.
        /// </summary>
        /// <returns>
        /// Name of the Circle Class.
        /// </returns>
        public override string ShowClassName()
        {
            return this.GetType().Name;
        }
    }
}
