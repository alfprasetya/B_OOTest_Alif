using System;
using B_OOTest_Alif;

class Program
{
    static void Main()
    {
        // Create an instance of the FormulatrixRepositoryManager
        var repositoryManager = new RepositoryManager();

        try
        {
            // Attempt to retrieve an item before initializing the repository (expecting an exception)
            Console.WriteLine("Item X Content: " + repositoryManager.Retrieve("itemX"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        // Initialize the repository
        repositoryManager.Initialize();

        // Attempt to deregister an item that doesn't exist (expecting an exception)
        try
        {
            repositoryManager.Deregister("nonexistentItem");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        // Attempt to get the type of an item that doesn't exist (expecting an exception)
        try
        {
            int itemType = repositoryManager.GetType("nonexistentItem");
            Console.WriteLine("Item Type: " + itemType);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        // Attempt to register an item with invalid content (expecting an exception)
        try
        {
            repositoryManager.Register("invalidItem", "invalidContent", 1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        // Register additional items
        repositoryManager.Register("item4", "{\"key4\":\"value4\"}", 1);
        repositoryManager.Register("item5", "<root><element>value5</element></root>", 2);

        // Retrieve and display content and type of the new items
        Console.WriteLine("Item 4 Content: " + repositoryManager.Retrieve("item4"));
        Console.WriteLine("Item 4 Type: " + (repositoryManager.GetType("item4") == 1 ? "JSON" : "XML"));
        Console.WriteLine();

        Console.WriteLine("Item 5 Content: " + repositoryManager.Retrieve("item5"));
        Console.WriteLine("Item 5 Type: " + (repositoryManager.GetType("item5") == 1 ? "JSON" : "XML"));
        Console.WriteLine();

        // Deregister all items
        repositoryManager.Deregister("item1");
        repositoryManager.Deregister("item3");
        repositoryManager.Deregister("item4");
        repositoryManager.Deregister("item5");

        // Attempt to retrieve content and type of deregistered items (expecting exceptions)
        try
        {
            Console.WriteLine("Item 1 Content: " + repositoryManager.Retrieve("item1"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        try
        {
            Console.WriteLine("Item 3 Content: " + repositoryManager.Retrieve("item3"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        try
        {
            Console.WriteLine("Item 4 Content: " + repositoryManager.Retrieve("item4"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        try
        {
            Console.WriteLine("Item 5 Content: " + repositoryManager.Retrieve("item5"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}
