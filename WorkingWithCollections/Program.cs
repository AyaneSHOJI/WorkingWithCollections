using static System.Console;
using System.Collections.Immutable;

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

    // p.347 immutable collections

    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Rio");

    Output("Immutable list of cities:", immutableCities);
    Output("New list of cities:", newList);

}

WorkingWithLists();

// p.343
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

// p.344 Working with queues
static void WorkingWithQueues()
{
    Queue<string> coffee = new Queue<string>();

    coffee.Enqueue("Damir"); // front of queue
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina"); // back of queue

    Output("Initial queue from front to back", coffee);

    // server handles next person in queue
    string served = coffee.Dequeue();
    WriteLine($"Served : {served}");

    // server handles next person in queue
    served = coffee.Dequeue();
    WriteLine($"Served : {served}");

    Output("Current queue from front to back", coffee);

    WriteLine($"{coffee.Peek()} is next in line.");

    Output("Current queue from front to back", coffee);
}

WorkingWithQueues();

static void OutputPQ<TElement, TPriority>(string title, IEnumerable<(TElement Element, TPriority Priority)> collection)
{
    WriteLine(title);
    foreach((TElement, TPriority) item in collection)
    {
        WriteLine($"    {item.Item1}:{item.Item2}");    
    }
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();

    // add some people
    // 1 = high priority people in their 70s or poor health
    // 2 = medium priority e.g. middle aged
    // 3 = low priority e.g. teens and twenties
    vaccine.Enqueue("Pamela", 1); // 70s
    vaccine.Enqueue("Rebecca", 3); // teens
    vaccine.Enqueue("Juliet", 2); // 40s
    vaccine.Enqueue("Ian", 1); // 70s

    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    vaccine.Enqueue("Mark", 2); // 40s
    WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);
}

WorkingWithPriorityQueues();

// p.350 indexes, ranges and spans
string name = "Samanth Jones";

// Using Substring
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(startIndex: 0, length:lengthOfFirst);
string lastName = name.Substring(startIndex: name.Length - lengthOfLast, length:lengthOfLast);

WriteLine($"First name : {firstName}, last name : {lastName}");

// using spans
ReadOnlySpan<char> nameAsSpan = name.AsSpan(); // // AsSpan() Summary:
                                               //     Creates a new read-only span over a portion of the target string from a specified
                                               //     position for a specified number of characters.
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..^0]; // carat operator means fromEnd: true

WriteLine($"First name : {firstNameSpan}, last name : {lastNameSpan}");