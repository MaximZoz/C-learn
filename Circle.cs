partial class Program
{
    static void Main(string[] args)
    {
        // Circle c = new Circle(X: 5, Y: 5, R: 5);
        // c.Print();
        Console.ReadKey();
    }
}

class Circle
{
    //public int x, y, r;
    public double

            X,
            Y,
            R;

    private float s;

    public float S
    {
        get
        {
            return s;
        }
        set
        {
        }
    }

    private float p;

    public float P
    {
        get
        {
            return p;
        }
        set
        {
        }
    }

    public Circle(int X, int Y, int R)
    {
        this.X = (double) X;
        this.Y = (double) Y;
        this.R = (double) R;
        s = (float) getPloshshad();
        p = (float) getPerimetr();
    }

    public void Print() => Console.WriteLine($"периметр: {p}  площадь: {s}");

    double getPloshshad()
    {
        double ploshshad;
        ploshshad = (Math.PI * R) * R;
        return ploshshad;
    }

    double getPerimetr()
    {
        double perimetr = (Math.PI * R) * 2;
        return perimetr;
    }
}
