namespace CSCI3110CSharpReview.Models;

public interface IGetArea
{
    double GetArea();
}

public class Rectangle : IGetArea
{
    public double Length { get; set; }
    public double Width { get; set; }

    public double GetArea()
    {
        return Length * Width;
    }
}
