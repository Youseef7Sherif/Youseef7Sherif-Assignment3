// .csproj:
// Contains the project configuration, such as the output type,
// target framework, implicit usings, and nullable settings.

// Program.cs:
// Contains the main source code of the application.
// With top-level statements, it also represents the program's entry point.

// obj/:
// Contains temporary and intermediate files generated during the build process.

// bin/:
// Contains the compiled output of the project (dll).

// A file-scoped namespace applies to the entire file without using
// curly braces, so it removes one level of indentation.

// This project uses the newer .slnx solution format.
// One advantage of the classic .sln format is its wider compatibility
// with older versions of Visual Studio and other tools.


using CSharpBasicsAssignment;

Console.WriteLine("=== PART B: Variables, Types & Casting ===");
RunTypesDemo();

Console.WriteLine("\n=== PART C: Value vs. Reference Types ===");
RunValueVsReferenceDemo();

Console.WriteLine("\n=== PART D: Scope & Operators ===");
ScopeDemo demo = new ScopeDemo();
Console.WriteLine("-------------D1--------------");
demo.MethodOne();
demo.MethodTwo();
demo.MethodScopeDemo();
demo.ForScopeDemo();
Console.WriteLine("-------------D2--------------");
demo.CompoundAssignmentDemo();
Console.WriteLine("-------------D3--------------");
demo.BitwiseDemo();

Console.WriteLine("\n=== PART F: LeetCode 136 - Single Number ===");

int[] nums1 = { 4, 1, 2, 1, 2 };
Console.WriteLine($"Single number: {FindSingleNumber(nums1)}");

int[] nums2 = { 2, 2, 3 };
Console.WriteLine($"Single number: {FindSingleNumber(nums2)}");


void RunTypesDemo()
{
    int myInt = 50;
    long myLong = 100000L;
    double myDouble = 3.5;
    decimal myDecimal = 99.99m;
    bool myBool = true;
    char myChar = 'A';
    string myString = "Hello";
    var myVar = 123.45;

    Console.WriteLine($"int: {myInt}, Type: {myInt.GetType()}");
    Console.WriteLine($"long: {myLong}, Type: {myLong.GetType()}");
    Console.WriteLine($"double: {myDouble}, Type: {myDouble.GetType()}");
    Console.WriteLine($"decimal: {myDecimal}, Type: {myDecimal.GetType()}");
    Console.WriteLine($"bool: {myBool}, Type: {myBool.GetType()}");
    Console.WriteLine($"char: {myChar}, Type: {myChar.GetType()}");
    Console.WriteLine($"string: {myString}, Type: {myString.GetType()}");
    Console.WriteLine($"var: {myVar}, Type: {myVar.GetType()}");

    myLong = myInt;
    myInt = myChar;

    Console.WriteLine($"int to long: {myLong}");
    Console.WriteLine($"char to int: {myInt}");

    // No cast is required because these conversions are implicit and safe:
    // long can represent all int values, and char can be converted to its integer value in Asci code.

    myInt = (int)myDouble;
    int convertResult = Convert.ToInt32(myDouble);
    Console.WriteLine($"double to int (cast): {myInt}");
    Console.WriteLine($"double to int (Convert): {convertResult}");

    // (int) truncates the fractional part, while Convert.ToInt32 rounds to the nearest integer.

    Console.WriteLine($"intDivision of 5/2: {5 / 2}");
    Console.WriteLine($"doubleDivision of 5/2: {5.0 / 2}");

    // Integer division discards the fractional part, while double division preserves it.

    object boxedInt = 50;
    int unboxedInt = (int)boxedInt;
    Console.WriteLine($"object: {boxedInt}, Type: {boxedInt.GetType()}");
    Console.WriteLine($"unboxed int: {unboxedInt}, Type: {unboxedInt.GetType()}");


    int parsedString = int.Parse("42");
    bool tryParseResult = int.TryParse("abc", out int result);
    Console.WriteLine($"Parsed string: {parsedString}");
    Console.WriteLine($"TryParse succeeded: {tryParseResult}");

    if (!tryParseResult)
        Console.WriteLine("Parsing failed because the string is not a valid integer.");

    else
        Console.WriteLine($"TryParse result: {result}");


    float floatValue = 12.5f;
    //decimal decimalValue = floatValue;
    decimal decimalValue = (decimal)floatValue;
    Console.WriteLine($"float to decimal: {decimalValue}");
    // float to decimal requires an explicit cast because decimal has different
    // precision/range characteristics, so C# does not allow the implicit conversion.
}

void RunValueVsReferenceDemo()
{

    Point p1 = new Point { X = 1, Y = 2 };
    Point p2 = p1;
    p2.X = 99;
    Console.WriteLine($"p1: {p1.X} , p2: {p2.X}");
    // Point is a value type, so assigning p1 to p2 copies the entire value.
    // Therefore, p1 and p2 are independent copies.
    Order o1 = new Order
    {
        OrderId = 1001,
        CustomerName = "Youssef",
        Quantity = 3,
        UnitPrice = 200.5m,
        TotalPrice = 0m,
        IsPaid = false,
        DiscountPercent = 10.5,
        ShippingCity = "Cairo",
        Priority = 'H',
        ItemCode = 123456789L
    };
    o1.CalculateTotal();
    Order o2 = o1;
    o2.IsPaid = true;
    Console.WriteLine($"o1: IsPaid={o1.IsPaid}, o2: IsPaid={o2.IsPaid}");
    // Order is a reference type, so assigning o1 to o2 copies the reference,
    // not the object itself. Both variables refer to the same object on the heap.
    object boxedOrder = o1;
    Order o3 = (Order)boxedOrder;
    Console.WriteLine(object.ReferenceEquals(o1, o3));
    o2.PrintSummary();

    // A value type stores its actual value, and assigning one value-type variable to another creates an independent copy of that value.
    // A reference type variable stores a reference to an object, so assigning it to another variable copies the reference and both variables point to the same object in heap.
    // Reference-type objects are stored on the heap, while local variables and value-type data are commonly associated with stack storage.
    // Storing a reference type in an object variable does not create a new object; it only stores the same reference using the base object type.
}
int FindSingleNumber(int[] nums)
{
    int result = 0;
    foreach (int num in nums)
    {
        result^=num;
    }
    return result;
      // XOR-ing a number with itself produces 0, and XOR-ing any number with 0 returns that number.
     // Therefore, all numbers that appear twice cancel each other out, leaving only the number that appears once.
    // x ^ x = 0
   // x ^ 0 = x
}
class ScopeDemo
{
    private int _fieldValue = 100;
    public void MethodOne()
    {
        Console.WriteLine(_fieldValue);
    }

    public void MethodTwo()
    {
        Console.WriteLine(_fieldValue);
    }

    public void MethodScopeDemo()
    {
        int localValue = 50;

        Console.WriteLine(localValue);
    }
    public void ForScopeDemo()
    {
        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;
            Console.WriteLine(insideLoop);
        }
        // Console.WriteLine(i);
        // Console.WriteLine(insideLoop);
        // Compile error: i and insideLoop are only accessible inside the for-loop block.
    }
    public void CompoundAssignmentDemo()
    {
        int total = 100;

        total += 5;
        Console.WriteLine($"After += : {total}");

        total -= 10;
        Console.WriteLine($"After -= : {total}");

        total *= 2;
        Console.WriteLine($"After *= : {total}");

        total /= 5;
        Console.WriteLine($"After /= : {total}");

        total %= 3;
        Console.WriteLine($"After %= : {total}");

        // total += 5 is equivalent to: total = total + 5;
    }
    public void BitwiseDemo()
    {
        int a = 12;
        int b = 10;
        Console.WriteLine($"a & b = {a & b}");
        Console.WriteLine($"a | b = {a | b}");
        Console.WriteLine($"a ^ b = {a ^ b}");

        // 12 = 1100
        // 10 = 1010
        //
        // AND:  1100 & 1010 = 1000 = 8
        // OR:   1100 | 1010 = 1110 = 14
        // XOR:  1100 ^ 1010 = 0110 = 6
        // & performs bitwise AND on integer bits, while && performs logical AND.
        // With &&, if the left condition is false, the right condition is not evaluated because of short-circuiting.
    }
}

 