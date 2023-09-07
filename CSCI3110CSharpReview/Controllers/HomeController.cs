using CSCI3110CSharpReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CSCI3110CSharpReview.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult HelloWorld()
    {
        return Content("Hello, World!");
    }

    public IActionResult Hello(string? id)
    {
        var name = "World";
        if (id != null)
        {
            name = id;
        }
        return Content($"Hello, {name}!");
    }

    enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

    public IActionResult EnumDemo()
    {
        Days today = Days.Monday;
        int dayNumber = (int)today;
        string model = $"{today} is day number #{dayNumber}. ";

        foreach (string item in Enum.GetNames(typeof(Months)))
        {
            model += item + " ";
        }

        return Content(model);
    }

    public IActionResult ClassDemo()
    {
        Employee e = new()
        {
            Name = "Jeff"
        };
        Manager m = new()
        {
            Name = "Evelyn"
        };

        string model = e.Talk();
        model += " ";
        model += m.Talk();

        return Content(model);
    }

    public IActionResult InterfaceDemo()
    {
        IGetArea r = new Rectangle { Length = 20, Width = 10 };
        return Content($"The area of the shape is {r.GetArea()}");
    }

    public IActionResult ArrayDemo()
    {
        // Declare a single-dimensional array  
        int[] array1 = new int[5];

        string a1str = String.Join(",", array1);

        // Declare and set array element values 
        int[] array2 = new int[] { 1, 3, 5, 7, 9 };

        string a2str = String.Join(",", array2);

        // Alternative syntax 
        int[] array3 = { 1, 2, 3, 4, 5, 6 };

        string a3str = String.Join(",", array3);

        // Declare a two-dimensional array 
        int[,] multiDimensionalArray1 = new int[2, 3];

        // Declare and set array element values 
        int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        // Declare a jagged array 
        int[][] jaggedArray = new int[6][];

        // Set the values of the first array in the jagged array structure
        jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

        return Content($"Array 1 [{a1str}] Array 2 [{a2str}] Array 3 [{a3str}]");
    }

    public IActionResult ImplicitTypeDemo()
    {
        // i is compiled as an int 
        var i = 5;

        // s is compiled as a string 
        var s = "Hello";

        // a is compiled as int[] 
        var a = new[] { 0, 1, 2 };

        // list is compiled as List<int>                              
        var list = new List<int>();

        return Content(
            $"i = {i}, s = {s}, a = [{String.Join(",", a)}], list = [{String.Join(",", list)}]");
    }

    public IActionResult AnonymousDemo()
    {
        var o = new { Amount = 108, Message = "Hello" };

        var ojson = JsonSerializer.Serialize(o);

        var v = new { Key = 42, Value = "Hello" };

        var vjson = JsonSerializer.Serialize(v);

        var anonArray =
            new[] {
                new { name = "apple", diam = 4 },
                new { name = "grape", diam = 1 }
            };

        var ajson = JsonSerializer.Serialize(anonArray);

        return Content($"o = {ojson}, v = {vjson}, anonArray = {ajson}");
    }

    public IActionResult LINQDemo()
    {
        var products = new[]
        {
          new {Color = "Red", Price=1.3m},
          new {Color = "Blue", Price=2.45m},
          new {Color = "Pink", Price=0.89m}
        };

        var productQuery =
           from prod in products
           select new { prod.Color, prod.Price };

        var model = "";
        foreach (var p in productQuery)
        {
            model += $"Color={p.Color}, Price={p.Price}\n";
        }

        return Content(model);
    }

    public IActionResult LambdaDemo()
    {
        var products = new[]
        {
          new {Id = 1, Color = "Red", Price=1.3m},
          new {Id = 3, Color = "Blue", Price=2.45m},
          new {Id = 4, Color = "Pink", Price=0.89m}
        };

        var product = products.FirstOrDefault(p => p.Id == 3);
        // Note the use of the null-conditional operator
        var model = $"Id={product?.Id} Color={product?.Color}, Price={product?.Price}";
        return Content(model);
    }

    public IActionResult NullableTypesDemo(int? id)
    {
        var model = "";
        int? x = id;
        if (x.HasValue)
        {
            model = "x=" + Convert.ToString(x.Value);
        }
        else
        {
            model = "x=Undefined";
        }

        int? c = id;

        // d = c, unless c is null, in which case d = -1. 
        int d = c ?? -1;

        int? e = id;
        int? f = id;

        // g = e or f, unless e and f are both null, in which case g = -1.
        int g = e ?? f ?? -1;

        return Content($"model = '{model}' c = '{c}' d = '{d}' g = '{g}'");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}