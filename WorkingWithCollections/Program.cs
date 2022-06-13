using static System.Console;

static void Output(string title, IEnumerable<string> collection)
{
    WriteLine(title);
    foreach(string item in collection)
    {
        WriteLine($"   {item}");
    }
}

static void WorkingWithLists()
{
    // simple syntax for creating a list and adding 3 items
    List<string> cities = new List<string>();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");

    /* Alternative syntax
    List<string> cities = new();
    cities.AddRange(new[] {"London", "Paris", "Milan" });
     */

    Output("initial list", cities);

    WriteLine($"The first city is {cities[0]}");
    WriteLine($"The last city is {cities[cities.Count - 1]}.");

    cities.Insert(0, "Sydney");

    Output("After inserting Sydney at index 0", cities);

    cities.RemoveAt(1);
    cities.Remove("Milan");

    Output("After removing two cities", cities);
}

WorkingWithLists();

static void WorkingWithDictionnaries()
{
    Dictionary<string, string> keywords = new();

    // add using named parameters
    keywords.Add(key: "int", value: "32-bit integer data type");

    // add using poitional parameters
    keywords.Add("long", "64-bit integer data type");
    keywords.Add("float", "Single precision floating point number");

    Output("Dicionnay keys:", keywords.Keys);
    Output("Dicionnay values:", keywords.Values);

    WriteLine("Keywords and thier definitions");
    foreach(KeyValuePair<string, string> item in keywords)
    {
        WriteLine($"   {item.Key}:{item.Value}");
    }
    string key = "long";
    WriteLine($"The definition of {key} is {keywords[key]}");   
}

WorkingWithDictionnaries(); 