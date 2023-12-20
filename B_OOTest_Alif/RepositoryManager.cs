using System;
using System.Collections.Generic;

namespace B_OOTest_Alif
{
    public class RepositoryManager
    {
        private Dictionary<string, Tuple<string, int>> repository;
        private bool isInitialized = false;

        // Initialize the repository for use
        public void Initialize()
        {
            if (isInitialized)
            {
                throw new InvalidOperationException("Repository has already been initialized.");
            }

            repository = new Dictionary<string, Tuple<string, int>>();
            isInitialized = true;
        }

        // Store an item to the repository.
        // Parameter itemType is used to differentiate JSON or XML.
        // 1 = itemContent is a JSON string.
        // 2 = itemContent is an XML string.
        public void Register(string itemName, string itemContent, int itemType)
        {
            if (repository == null)
            {
                throw new InvalidOperationException("Repository not initialized. Call Initialize() first.");
            }

            if (repository.ContainsKey(itemName))
            {
                throw new ArgumentException($"Item with name '{itemName}' already exists in the repository.");
            }

            // Validate itemContent based on itemType
            ValidateItemContent(itemContent, itemType);

            // Store the item in the repository
            repository[itemName] = Tuple.Create(itemContent, itemType);
        }

        // Retrieve an item from the repository.
        public string Retrieve(string itemName)
        {
            if (repository == null)
            {
                throw new InvalidOperationException("Repository not initialized. Call Initialize() first.");
            }

            if (repository.TryGetValue(itemName, out var item))
            {
                return item.Item1; // itemContent
            }

            throw new KeyNotFoundException($"Item with name '{itemName}' not found in the repository.");
        }

        // Retrieve the type of the item (JSON or XML).
        public int GetType(string itemName)
        {
            if (repository == null)
            {
                throw new InvalidOperationException("Repository not initialized. Call Initialize() first.");
            }

            if (repository.TryGetValue(itemName, out var item))
            {
                return item.Item2; // itemType
            }

            throw new KeyNotFoundException($"Item with name '{itemName}' not found in the repository.");
        }

        // Remove an item from the repository.
        public void Deregister(string itemName)
        {
            if (repository == null)
            {
                throw new InvalidOperationException("Repository not initialized. Call Initialize() first.");
            }

            if (!repository.Remove(itemName))
            {
                throw new KeyNotFoundException($"Item with name '{itemName}' not found in the repository.");
            }
        }

        // Placeholder for the validation logic
        private void ValidateItemContent(string itemContent, int itemType)
        {
            // You can implement the validation logic based on itemType here.
            // For example, check JSON or XML validity, or any other specific validation.

            // Placeholder: Display a message for demonstration purposes
            Console.WriteLine($"Validation for itemType {itemType} is not implemented in this placeholder.");
        }
    }
}
