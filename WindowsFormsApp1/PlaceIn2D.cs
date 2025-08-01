using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PlaceIn2D : Display3D
    {

        int FOV;
        double Z0;
        Point3D Point;
        public int ResoloutionX = 1200;
        public int ResoloutionY = 800;
        Point3D rotation;
        public PlaceIn2D(Point3D point, Point3D r, int f)
        {
            FOV = f;
            Z0 = (ResoloutionX / 2) / Math.Tan((FOV / 2) * Math.PI / 180);
            rotation.x = r.x; rotation.y = r.y; rotation.z = r.z;
            Point = point;
            Point = Rotate(Point, rotation);
            Point = Point2D(Point);
            Point = CentreScreen(Point);
        }

        public int GetPointX()
        {
            return Convert.ToInt32(Point.x);
        }
        public int GetPointY()
        {
            return Convert.ToInt32(Point.y);
        }
        public int GetPointZ()
        {
            return Convert.ToInt32(Point.z);
        }

        public Point3D Point2D(Point3D original)
        {
            Point3D final;
            final.x = original.x * Z0 / (Z0 + original.z);
            final.y = original.y * Z0 / (Z0 + original.z);
            final.z = original.z;
            return final;
        }

        public Point3D CentreScreen(Point3D original)       // because top left is (0,0) eveything has to be moved across 
        {                                                   // z can stay the same as thats not shown on the 2d screen
            Point3D final;
            final.x = original.x + ResoloutionX / 3 + ResoloutionX / 20;
            final.y = original.y + ResoloutionY / 3 + ResoloutionX / 20;
            final.z = original.z;
            return final;
        }

        public Point3D Rotate(Point3D original, Point3D rotation)
        {
            Point3D final;
            double x = rotation.x;

            final.x = original.x;
            final.y = original.y * Math.Cos(x) - original.z * Math.Sin(x);
            final.z = original.y * Math.Sin(x) + original.z * Math.Cos(x);


            original.x = final.x;
            original.y = final.y;
            original.z = final.z;

            x = rotation.y;

            final.x = original.z * Math.Sin(x) + original.x * Math.Cos(x);
            final.y = original.y;
            final.z = original.z * Math.Cos(x) - original.x * Math.Sin(x);

            original.x = final.x;
            original.y = final.y;
            original.z = final.z;

            x = rotation.z;

            final.x = original.x * Math.Cos(x) - original.y * Math.Sin(x);
            final.y = original.x * Math.Sin(x) + original.y * Math.Cos(x);
            final.z = original.z;

            return final;
        }
    }
}
