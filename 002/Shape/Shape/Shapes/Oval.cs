using System;
using Shape.Helper;

namespace Shape.Shapes
{
    /// <summary>
    /// Oval class which is inherited from abstarct class Shape.
    /// </summary>
    class Oval : Shape
    {
        private static int m_nSnum = 0;
        private float m_fMajorAxis, m_fMinorAxis;
        private double m_dblArea, m_dblPerimeter;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Oval() { }

        /// <summary>
        /// Oval constructor for initializing object with the major an minor axis.
        /// </summary>
        /// <param name="fMajorAxis">
        /// For taking the Major axis of oval.
        /// </param>
        /// <param name="fMinorAxis">
        /// For taking the Minor axis of oval.
        /// </param>
        public Oval(float fMajorAxis, float fMinorAxis)
        {
            m_nSnum += 1;
            SerialNumber = m_nSnum;
            m_fMajorAxis = fMajorAxis;
            m_fMinorAxis = fMinorAxis;
        }

        /// <summary>
        /// Overrided Area method for calculating area of oval.
        /// </summary>
        /// <returns>
        /// Area of oval.
        /// </returns>
        public override double Area()
        {
            m_dblArea = Constants.PI * m_fMajorAxis * m_fMinorAxis;
            return m_dblArea;
        }

        /// <summary>
        /// Overrided Perimeter method for calculating perimeter of oval.
        /// </summary>
        /// <returns>
        /// Parimeter of oval.
        /// </returns>
        public override double Perimeter()
        {
            double dblSR1 = Math.Pow(m_fMajorAxis, 2);
            double dblSR2 = Math.Pow(m_fMinorAxis, 2);

            double dblAddedSquredRedius = dblSR1 + dblSR2;
            
            double dblSqrt = Math.Sqrt(dblAddedSquredRedius / 2);

            m_dblPerimeter = (2 * Constants.PI * dblSqrt);
            
            return m_dblPerimeter;
        }

        /// <summary>
        /// Overrided ShowClassName method for returning Oval class name.
        /// </summary>
        /// <returns>
        /// Name of the Oval Class
        /// </returns>
        public override string ShowClassName()
        {
            return this.GetType().Name;
        }
    }
}
