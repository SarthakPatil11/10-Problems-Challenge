using System;
using Shape.Helper;
using Shape.Shapes;

namespace Shape
{
    /// <summary>
    /// Progam class it is a driver class that has driver method.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Display method used to display the output.
        /// </summary>
        /// <param name="nSerialNum">
        /// For taking Serial number of object.
        /// </param>
        /// <param name="strShapeName">
        /// For taking the Shape name of the object.
        /// </param>
        /// <param name="dblArea">
        /// For taking the shape's Area of the object.
        /// </param>
        /// <param name="dblParimeter">
        /// For taking the shape's Perimeter of the object.
        /// </param>
        public void Display(int nSerialNum, string strShapeName, double dblArea, double dblParimeter)
        {
            Console.WriteLine(Constants.SEPARATOR);
            Console.WriteLine(Constants.SERIAL_NUM + nSerialNum);
            Console.WriteLine(Constants.SHAPE_NAME + strShapeName);
            Console.WriteLine(Constants.AREA + dblArea);
            Console.WriteLine(Constants.PERIMETER + dblParimeter);
            Console.WriteLine(Constants.CONTINUE);
            Console.ReadKey();
        }

        /// <summary>
        /// Main Method (Driver Method) for giving the interface to the user for calculating Area and Perimeter of different shapes.
        /// </summary>
        static void Main()
        {
            Program objProgram = new Program();

            // Infinite while for executing the User choices repetitively utinl user select exit.
            while (true)
            {
                Console.Clear();
                //To take the choice of shape form the user.
                int nChoice = InputHelper.ReadInt(Constants.MAIN_CHOICE);
                //To exicute the code as per the choice between (Rectangle, Oval and Circle).
                switch (nChoice)
                {
                    //Choice Rectangle
                    case 1:
                        //To clear the console.
                        Console.Clear();
                        //To take length and width of the rectangle from the user.
                        float fLength = InputHelper.ReadFloat(Constants.RECT_PROP1);
                        float fWidth = InputHelper.ReadFloat(Constants.RECT_PROP2);
                        //Intitialize the Rectangle as per the length and width.
                        Rectangle objRectangle = new Rectangle(fLength, fWidth);
                        //To get the Serial number of the rectangle.
                        int nRectSerialNum = objRectangle.SerialNumber;
                        //To get the Shape Name of the rectangle.
                        string strRectShapeName = objRectangle.ShowClassName();
                        //To get the area of the rectangle.
                        double dblRectArea = objRectangle.Area();
                        //To get the perimeter of the rectangle.
                        double dblRectParimeter = objRectangle.Perimeter();
                        //TO display the output as per taken parameters.
                        objProgram.Display(nRectSerialNum, strRectShapeName, dblRectArea, dblRectParimeter);
                        break;
                    //Choice Oval
                    case 2:
                        //To clear the console.
                        Console.Clear();
                        //To take Major and Minor axis of the oval from the user.
                        float fMajorAxis = InputHelper.ReadFloat(Constants.OVAL_PROP1);
                        float fMinorAxis = InputHelper.ReadFloat(Constants.OVAL_PROP2);
                        //Intitialize the Rectangle as per the major and minor axis.
                        Oval objOval = new Oval(fMajorAxis, fMinorAxis);
                        //To get the Serial number of the oval.
                        int nOvalSerialNum = objOval.SerialNumber;
                        //To get the Shape Name of the oval.
                        string strOvalShapeName = objOval.ShowClassName();
                        //To get the area of the oval.
                        double dblOvalArea = objOval.Area();
                        //To get the perimeter of the oval.
                        double dblOvalParimeter = objOval.Perimeter();
                        //To display the output as per taken parameters.
                        objProgram.Display(nOvalSerialNum, strOvalShapeName, dblOvalArea, dblOvalParimeter);
                        break;
                    //Choice Circle.
                    case 3:
                        //To clear the console.
                        Console.Clear();
                        //To take redius of the circle from the user.
                        float fRedius = InputHelper.ReadFloat(Constants.CIRCLE_PROP);
                        //Intitialize the Rectangle as per the redius.
                        Circle objCircle = new Circle(fRedius);
                        //To get the Serial number of the circle.
                        int nCircleSerialNum = objCircle.SerialNumber;
                        //To get the Shape Name of the circle.
                        string strCircleShapeName = objCircle.ShowClassName();
                        //To get the area of the circle.
                        double dblCircleArea = objCircle.Area();
                        //To get the perimeter of the circle.
                        double dblCircleParimeter = objCircle.Perimeter();
                        //To display the output as per taken parameters.
                        objProgram.Display(nCircleSerialNum, strCircleShapeName, dblCircleArea, dblCircleParimeter);
                        break;
                    //Choice Exit.
                    case 4:
                        return;
                    //Default choice for handling if user entered the wrong choice.
                    default:
                        Console.WriteLine(Constants.WRONG_CHOICE);
                        break;
                }
            }
        }
    }
}
