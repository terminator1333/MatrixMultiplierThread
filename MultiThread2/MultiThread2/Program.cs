using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MultiThread2
{
    class Program
    {
        static void Main(string[] args)
        {

            MTMergeSort m = new MTMergeSort();

            string[] strList = {
    "apple", "banana", "orange", "grape", "melon", "peach", "pear", "plum", "kiwi", "lemon",
    "lime", "mango", "apricot", "blueberry", "blackberry", "strawberry", "raspberry", "watermelon", "pineapple", "papaya",
    "cherry", "fig", "date", "pomegranate", "dragonfruit", "lychee", "nectarine", "coconut", "cantaloupe", "tangerine",
    "mandarin", "grapefruit", "kumquat", "avocado", "tomato", "pumpkin", "cucumber", "zucchini", "carrot", "potato",
    "onion", "garlic", "leek", "spinach", "kale", "lettuce", "arugula", "cabbage", "broccoli", "cauliflower",
    "peas", "green beans", "asparagus", "artichoke", "celery", "beetroot", "radish", "turnip", "sweet potato", "butternut squash",
    "parsnip", "chili", "pepper", "basil", "oregano", "thyme", "rosemary", "sage", "mint", "parsley",
    "dill", "cilantro", "tarragon", "bay leaf", "fennel", "chive", "marjoram", "lavender", "lemon balm", "ginger",
    "turmeric", "cinnamon", "nutmeg", "clove", "cardamom", "allspice", "vanilla", "cocoa", "chocolate", "coffee",
    "tea", "matcha", "green tea", "black tea", "herbal tea", "iced tea", "milk", "cream", "butter", "cheese",
    "yogurt", "egg", "bread", "bagel", "croissant", "brioche", "muffin", "scone", "pita", "naan",
    "tortilla", "pizza", "pasta", "spaghetti", "lasagna", "macaroni", "fettuccine", "penne", "ravioli", "gnocchi",
    "focaccia", "biscuit", "cracker", "cookie", "brownie", "pie", "cake", "cheesecake", "donut", "cupcake",
    "ice cream", "gelato", "sorbet", "pudding", "jelly", "candy", "chocolate bar", "gum", "marshmallow", "fruitcake",
    "popcorn", "pretzel", "chips", "nachos", "salsa", "guacamole", "hummus", "pesto", "mustard", "ketchup",
    "mayonnaise", "barbecue sauce", "hot sauce", "soy sauce", "sriracha", "teriyaki sauce", "vinegar", "olive oil", "vegetable oil",
    "canola oil", "coconut oil", "peanut butter", "almond butter", "hazelnut spread", "honey", "maple syrup", "jam", "marmalade",
    "syrup", "molasses", "salt", "pepper", "paprika", "cayenne pepper", "cumin", "chili powder", "turmeric", "garam masala",
    "curry powder", "ginger powder", "onion powder", "garlic powder", "oregano", "thyme", "bay leaf", "baking soda", "baking powder",
    "flour", "sugar", "brown sugar", "cornstarch", "baking chocolate", "dark chocolate", "milk chocolate", "white chocolate", "cocoa powder",
    "coconut flakes", "marzipan", "fruit juice", "water", "soda", "sparkling water", "energy drink", "wine", "beer", "cocktail",
    "whiskey", "vodka", "rum", "gin", "tequila", "champagne", "martini", "mojito", "margarita", "mimosa",
    "old fashioned", "manhattan", "cosmopolitan", "bloody mary", "mule", "daquiri", "piña colada", "sangria", "pina colada", "long island iced tea",
    "apple cider", "pear cider", "fruit punch", "lemonade", "limeade", "iced coffee", "milkshake", "smoothie", "protein shake", "bubble tea",
    "kombucha", "iced latte", "hot chocolate", "latte", "cappuccino", "espresso", "americano", "flat white", "macchiato", "mocha",
    "cortado", "cold brew", "drip coffee", "pour over", "french press", "percolator", "turkish coffee", "greek coffee", "espresso martini", "cafe au lait",
    "gelato", "pistachio gelato", "tiramisu", "baklava", "crème brûlée", "macaron", "profiterole", "eclair", "sufganiyah", "babka",
    "knafeh", "lokum", "cannoli", "zabaglione", "churro", "pastel de nata", "palmiers", "pavlova", "meringue", "shortbread",
    "gingerbread", "sablé", "flan", "creme caramel", "panettone", "stollen", "fruit tart", "chocolate mousse", "lemon tart", "lime pie",
    "carrot cake", "banana bread", "zucchini bread", "pound cake", "angel food cake", "coffee cake", "chocolate chip cookies", "oatmeal cookies", "snickerdoodle",
    "peanut butter cookies", "ginger cookies", "sugar cookies", "linzer cookies", "macadamia nut cookies", "biscotti", "fortune cookie", "spice cookies",
    "whoopie pie", "s'mores", "jelly beans", "gummy bears", "licorice", "marzipan", "chocolate truffle", "caramel", "toffee", "fudge",
    "taffy", "gummi worms", "hard candy", "cotton candy", "candy cane", "lollipop", "sour candy", "chocolate covered pretzels", "fruit chews",
    "mint chocolate", "lemon drops", "jawbreakers", "rock candy", "chocolate covered almonds", "dark chocolate truffle", "white chocolate truffle", "candied ginger",
    "syrup", "toffee", "butterscotch", "honeycomb", "chocolate covered cherries", "caramel apple", "nougat", "coconut macaroons", "crunch bar", "kettle corn",
    "caramel corn", "bacon", "sausage", "chicken", "steak", "hamburger", "hot dog", "bratwurst", "meatballs", "grilled cheese", "fajita",
    "burrito", "taco", "enchilada", "quesadilla", "tamale", "nachos", "guacamole", "salsa", "sour cream", "cilantro", "lime", "jalapeno",
    "chorizo", "tostada", "ceviche", "paella", "empanada", "samosa", "spring roll", "egg roll", "dumpling", "gyoza", "shumai", "bao",
    "bánh mì", "banh xeo", "pho", "ramen", "sushi", "tempura", "teriyaki", "yakitori", "katsu", "gyudon", "okonomiyaki", "takoyaki", "kimbap",
    "kimchi", "banchan", "bibimbap", "japchae", "hot pot", "fondue", "shabu-shabu", "sukiyaki", "risotto", "cacciatore", "bolognese", "carbonara",
    "alfredo", "puttanesca", "arrabbiata", "pesto", "marinara", "pomodoro", "puttanesca", "ragù", "pasta primavera", "lasagna", "gnocchi", "frittata",
    "polenta", "caprese", "antipasto", "bruschetta", "panini", "focaccia", "ciabatta", "grissini", "prosciutto", "salami", "mortadella", "cacciatore",
    "bresaola", "caponata", "panzanella", "insalata", "minestrone", "pasta e fagioli", "ribollita", "zuppa toscana", "vichyssoise", "gazp", "yassir", "villain","thunder","terrain"};

            List<string> lst = new List<string>(m.MergeSort(strList));

            for(int i =0; i< lst.Count; i++)
            {
                Console.WriteLine(lst[i]);
            }


            Console.WriteLine(strList.Length);
            Console.ReadLine();  // Keeps the console window open until you press Enter
        }
    }
    class MTMergeSort
    {

        public static string sortString(string str) //A function for quickly sorting a string
        {
            char[] chrArr = str.ToCharArray(); //turning the string into an array of chars
            Array.Sort(chrArr); //using the static function of the class array to sort the array of chars

            string sorted = new string(chrArr); //creating a new string, and inserting the array of sorted chars

            return sorted; //returning the sorted string
        }


        public static void ThreadStringsSort(int begin, int end, List<string> sortedList, string[] strList)
        {
            for ( int i = begin; i < end; i++)
            {
                sortedList.Add(sortString(strList[i]));
            }
        }

        public static void ThreadSortMerge(List<string> sortedList, string[] strList, int nMin)

        {
            int factor = strList.Length / nMin; //The factor. The amount of threads that we need


            int remainder = strList.Length % nMin; //Incase the division has a remainder, we need one more thread and it will be in charge of the last 'remainder' ones


            int amount = remainder == 0 ? factor : factor + 1; //the amount of threads we need. Incase the remainder is 0, we need 'factor' threads, else, 'factor' threads plus 1

            Thread []threads = new Thread[amount]; //creating the amount of needed threads

            for(int i = 0; i < factor; i++) //going through the amount of known threads that we need, setting the begin and end indicies for the thread and initialising the thread
            {
                int begin = nMin * i; //the begin index, just nMin * current i
                int end = nMin * (i + 1); //the end index, just adding 1 to i
                threads[i] = new Thread(() => ThreadStringsSort(begin, end, sortedList, strList)); //initialising the string
            }

            if (remainder != 0) //incase the remainder is not 0, add the final words to one extra thread
            {
                int begin = strList.Length - remainder; //begin index for the thread
                int end = strList.Length; //end index

                threads[amount - 1] = new Thread(() => ThreadStringsSort(begin, end, sortedList, strList)); //initialising the thread

            }

            for(int i = 0; i < amount; i++) //Starting all the threads to run parallel to each other
            {
                threads[i].Start();
            }

            for(int i = 0; i < amount; i++) //joining all of them, so the computation wont exceed this part of the program
            {
                threads[i].Join();
            }

        }


        public List<string> MergeSort(string[] strList, int nMin = 16)
        {
            List<string> sortedList = new List<string>(); //initialising the sorted list of strings

            ThreadSortMerge(sortedList, strList, nMin); //applying the static sorting function
            
            return sortedList; //returning the list after sorting each string
        }
    }
}
