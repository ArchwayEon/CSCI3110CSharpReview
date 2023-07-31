namespace CSCI3110CSharpReview.Models;

public class Employee
{
    public string Name { get; set; } = String.Empty; // Property

    public virtual string Talk()
    {
        return Name + ": blah blah blah!";
    }
}

public class Manager : Employee
{
    public override string Talk()
    {
        return Name + ": GET BACK TO WORK!";
    }
}
